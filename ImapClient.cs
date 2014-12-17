using System;
using System.Windows.Forms;
using ComponentPro.Net;

namespace ImapClient
{
    public partial class ImapClient : Form
    {
        /// <summary>
        /// Defines connection states.
        /// </summary>
        enum ConnectionState
        {
            NotConnected,
            Connecting,
            Ready,
            Disconnecting
        }

        private readonly bool _exception; // Incidates whether a licensing exception has occurred. 
        private bool _messagesDelete;

        private LoginInfo _settings; // Login information.
        private ConnectionState _state; // Current connection state.

        private int _disableCount;

        private string _currentFolder = string.Empty; // Selected folder name.

        public ImapClient()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception exc)
            {
                if (exc is ComponentPro.Licensing.Mail.UltimateLicenseException)
                {
                    MessageBox.Show(exc.Message, "Error");
                    _exception = true;
                    return;
                }

                throw;
            }

            //#if DEBUG
            //ComponentPro.Diagnostics.XTrace.Level = System.Diagnostics.TraceEventType.Transfer;
            //ComponentPro.Diagnostics.XTrace.AutoFlush = true;
            //// Add the UltimateTextWriterTraceListener listener to write to a file.
            //ComponentPro.Diagnostics.XTrace.Listeners.Add(new ComponentPro.Diagnostics.UltimateTextWriterTraceListener("log.log"));
            //#endif

#if !Framework4_5
            this.client.ListFoldersCompleted += this.client_ListFoldersCompleted;
            this.client.DownloadImapMessageCompleted += client_DownloadImapMessageCompleted;
            this.client.ListMessagesCompleted += this.client_ListMessagesCompleted;
            this.client.ConnectCompleted += this.client_ConnectCompleted;
            this.client.ListProcessing += this.client_ListProcessing;
            this.client.DisconnectCompleted += this.client_DisconnectCompleted;
            this.client.AuthenticateCompleted += this.client_AuthenticateCompleted;
#endif
        }

        /// <summary>
        /// Handles the form's Load event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Close the application if an exception occurred.
            if (_exception)
                this.Close();

            // Load settings from the Registry.
            _settings = LoginInfo.LoadConfig();
        }

        /// <summary>
        /// Handles the form's Closed event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnClosed(EventArgs e)
        {
            // Make sure to close the IMAP session before leaving.
            if (tsbLogout.Visible)
            {
                // Close the connection.
                Disconnect();

                // Wait for the completion.
                while (_state != ConnectionState.NotConnected)
                {
                    System.Threading.Thread.Sleep(50);
                    // Wake up the GUI.
                    System.Windows.Forms.Application.DoEvents();
                }
            }

            // And save the settings.
            _settings.SaveConfig();

            base.OnClosed(e);
        }

        /// <summary>
        /// Closes the connection and release used resources.
        /// </summary>
#if Framework4_5
        async void Disconnect()
#else
        private void Disconnect()
#endif
        {
            // Disable the session timeout timer.
            sessionTimeoutTimer.Enabled = false;

            if (_messagesDelete)
            {
                _messagesDelete = false;
                SetStatusText("Applying changes...");
                client.Purge();
            }

            // Set Disconnecting state.
            _state = ConnectionState.Disconnecting;
            SetStatusText("Disconnecting...");

#if Framework4_5
            try
            {
                // Asynchronously disconnect.
                await client.DisconnectAsync();
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
                SetStatusText("Ready");
            }

            // Set disconnected state.
            SetDisconnectedState();
#else
            // Asynchronously disconnect.
            client.DisconnectAsync();
#endif
        }

        /// <summary>
        /// Logins to the IMAP server.
        /// </summary>
#if Framework4_5
        private async void Connect()
#else
        private void Connect()
#endif
        {
            // Set timeout.
            client.Timeout = _settings.Timeout;

            WebProxyEx proxy = new WebProxyEx();
            client.Proxy = proxy;
            // Setup proxy.
            if (_settings.ProxyServer.Length > 0 && _settings.ProxyPort > 0)
            {
                proxy.Server = _settings.ProxyServer;
                proxy.Port = _settings.ProxyPort;
                proxy.UserName = _settings.ProxyUserName;
                proxy.Password = _settings.ProxyPassword;
                proxy.ProxyType = _settings.ProxyType;
                proxy.Domain = _settings.ProxyDomain;
                proxy.AuthenticationMethod = _settings.ProxyAuthenticationMethod;
            }

            SetStatusText("Connecting to {0}:{1}...", _settings.Server, _settings.Port);
            _state = ConnectionState.Connecting;
            // Disable controls.
            EnableDialog(false);
            
#if Framework4_5
            try
            {
                // Connect to the IMAP server.
                await client.ConnectAsync(_settings.Server, _settings.Port, _settings.SecurityMode);
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
                Disconnect();
                return;
            }

            Authenticate();
#else
            // Connect to the IMAP server.
            client.ConnectAsync(_settings.Server, _settings.Port, _settings.SecurityMode);
#endif
        }
        
        private void EnableDialogImm(bool enable)
        {
            listView.Enabled = enable;
            treeView.Enabled = enable;
            EnableContextMenus(enable);
            toolbarMain.Enabled = enable;

            Util.EnableCloseButton(this, enable);
        }

        private void EnableProgress(bool enable, int maxValue)
        {
            _cancelling = false;
            toolStripStatusLabel.Visible = !enable;
            toolStripProgressBar.Visible = enable;
            toolStripProgressBar.Value = 0;
            toolStripProgressBar.Maximum = maxValue;
            toolStripProgressCancelButton.Visible = enable;
            toolStripProgressLabel.Text = string.Empty;
            toolStripProgressLabel.Visible = enable;

            EnableDialog(!enable);
        }

        private void EnableDialog(bool enable)
        {
            if (enable)
            {
                if (_disableCount > 0)
                {
                    _disableCount--;
                    if (_disableCount == 0)
                    {
                        EnableDialogImm(true);
                        SetStatusText("Ready");
                    }
                }
            }
            else
            {
                if (_disableCount == 0)
                {
                    EnableDialogImm(false);
                }
                _disableCount++;
            }
        }

        /// <summary>
        /// Sets the status text.
        /// </summary>
        /// <param name="str">The new status text.</param>
        private void SetStatusText(string str)
        {
            toolStripStatusLabel.Text = str;
        }

        /// <summary>
        /// Sets the status text.
        /// </summary>
        /// <param name="str">The new status format text.</param>
        /// <param name="parameters">The parameters.</param>
        private void SetStatusText(string str, params object[] parameters)
        {
            toolStripStatusLabel.Text = string.Format(str, parameters);
        }

        private void tsbPurge_Click(object sender, EventArgs e)
        {
            PurgeMessages();
        }

        private void toolStripProgressCancelButton_ButtonClick(object sender, EventArgs e)
        {
            // Cancel operation.
            _cancelling = true;
            client.Cancel();
        }

        private void openContextMenuItem_Click(object sender, EventArgs e)
        {
            tsbOpen_Click(sender, null);
        }

        private void deleteContextMenuItem_Click(object sender, EventArgs e)
        {
            tsbDelete_Click(sender, null);
        }

        private void undeleteContextMenuItem_Click(object sender, EventArgs e)
        {
            tsbUndelete_Click(sender, null);
        }

        private void saveMessageAsContextMenuItem_Click(object sender, EventArgs e)
        {
            tsbSaveAs_Click(sender, null);
        }

        private void newFolderContextMenuItem_Click(object sender, EventArgs e)
        {
            NewFolder();
        }

        private void deleteFolderContextMenuItem_Click(object sender, EventArgs e)
        {
            DeleteFolder();
        }

        private void renameContextMenuItem_Click(object sender, EventArgs e)
        {
            treeView.SelectedNode.BeginEdit();
        }

        private void pasteMessagesContextMenuItem_Click(object sender, EventArgs e)
        {
            PasteMessage(_currentFolder);
        }

        private void purgeDeletedMessagesContextMenuItem_Click(object sender, EventArgs e)
        {
            PurgeMessages();
        }

        private void sessionTimeoutTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // Check connection state.
                if (!client.IsBusy && _state == ConnectionState.Ready && !client.IsConnected)
                {
                    SetDisconnectedState();
                }
            }
            catch
            {
                // Close the connection if it's is closed by the server.
                Disconnect();
            }
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tsbCopy_Click(sender, null);
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tsbPaste_Click(sender, null);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbCopy_Click(sender, null);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbPaste_Click(sender, null);
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            CopyMessage();
        }

        private void tsbPaste_Click(object sender, EventArgs e)
        {
            PasteMessage(_currentFolder);
        }

        private void uploadLocalMessagesContextMenuItem_Click(object sender, EventArgs e)
        {
            UploadMessage();
        }

        private void uploadMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UploadMessage();
        }

        private void tsbUpload_Click(object sender, EventArgs e)
        {
            UploadMessage();
        }
    }
}
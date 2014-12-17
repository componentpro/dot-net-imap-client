using System;
using System.ComponentModel;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using ComponentPro;
using ImapClient.Security;
using ComponentPro.Net.Mail;
using ComponentPro.Security.Certificates;

namespace ImapClient
{
    public partial class ImapClient
    {
        private bool _cancelling; // User has cancelled the operation?

        /// <summary>
        /// Sets disconnected state.
        /// </summary>
        private void SetDisconnectedState()
        {
            // Clear folder list and message list.
            listView.Items.Clear();
            treeView.Nodes.Clear();

            // Set state to not connected.
            _state = ConnectionState.NotConnected;
            // Enable and disable controls.
            EnableDialog(true);

            toolStripProgressBar.Visible = false;
            toolStripProgressCancelButton.Visible = false;
            toolStripProgressLabel.Visible = false;
            tsbLogin.Visible = true;
            tsbLogout.Visible = false;
            tsbRefresh.Enabled = false; 
            //refreshToolStripMenuItem.Enabled = false;
            //loginToolStripMenuItem.Text = "&Login...";

            EnableContextMenus(false);

            //newMailboxToolStripMenuItem.Enabled = false;
            //renameMailboxToolStripMenuItem.Enabled = false;
            //deleteMaillboxToolStripMenuItem.Enabled = false;

            _currentFolder = string.Empty;

            // Make sure all toolbar buttons' states are updated. 
            listView_SelectedIndexChanged(null, null);

            SetStatusText("Ready");
        }

        void EnableContextMenus(bool enable)
        {
            listViewContextMenuStrip.Enabled = enable;
            treeViewContextMenuStrip.Enabled = enable;
        }

        private void Reconnect(Exception exc)
        {
            if (exc != null)
                Util.ShowError(exc);

            treeView.Nodes.Clear();
            listView.Items.Clear();
            // Disconnect and login again.
            client.Disconnect();
            
            Connect();
        }

        /// <summary>
        /// Refreshes the folder tree view.
        /// </summary>
        private void RefreshFolderList()
        {
            RefreshFolderList(_currentFolder);
        }

        /// <summary>
        /// Refreshes the folder tree view.
        /// </summary>
        /// <param name="folder">The folder name.</param>
        async void RefreshFolderList(string folder)
        {
            if (folder == null)
                return;

            // Disable controls.
            EnableDialog(false);

            if (folder.Length == 0)
                SetStatusText("Retrieving root folder list...");
            else
                SetStatusText("Retrieving folder list under {0}...", folder);

            FolderCollection col;
            try
            {
                // Asynchronously get folder list.
                col = await client.ListFoldersAsync(folder, false, false);
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
                EnableDialog(true);
                return;
            }

            ShowFolderList(col);
        }

        void ShowFolderList(FolderCollection col)
        {
            TreeNode node;
            bool selectNode = false;
            // Select the right node.
            if (_currentFolder.Length == 0)
            {
                node = treeView.Nodes[0];
            }
            else
            {
                node = treeView.SelectedNode;

                if (node == null)
                {
                    node = treeView.Nodes[0];
                    selectNode = true;
                }
            }

            // Clear child nodes.
            node.Nodes.Clear();

            // Loop through the retrieved list.
            foreach (Folder i in col)
            {
                // Add selectable node only.
                if (i.Selectable)
                {
                    TreeNode n = node.Nodes.Add(i.ShortName);
                    n.ImageIndex = 1;
                    n.SelectedImageIndex = 1;
                    n.Tag = i.Name;
                }
            }
            // Make it expanded.
            node.Expand();

            if (selectNode)
            {
                // Select the current folder.
                SelectFolder(_currentFolder);
            }

            if (_currentFolder.Length > 0)
            {
                // Refresh the message list accordingly.
                RefreshMessageList();
            }

            EnableDialog(true);
        }


        /// <summary>
        /// Selects a folder.
        /// </summary>
        /// <param name="folder">The folder name. It can be 'folder1/folder11/folder111'</param>
        private void SelectFolder(string folder)
        {
            // Split the provided folder path by '/' character.
            string[] arr = folder.Split('/');
            int i = 0;
            TreeNodeCollection nodes = treeView.Nodes[0].Nodes;

            foreach (string shortname in arr)
            {
                foreach (TreeNode node in nodes)
                {
                    if (shortname == node.Text)
                    {
                        i++;
                        if (i == arr.Length)
                        {
                            _noFireBeforeSelectEvent = true;
                            treeView.SelectedNode = node;
                            _noFireBeforeSelectEvent = false;

                            client.Select(folder);
                        }
                        else if (!node.Checked) // Folder list is not parsed.
                        {
                            // Then retrieve a list of child folder for this node.
                            FolderCollection col = client.ListFolders((string)node.Tag);
                            foreach (Folder item in col)
                            {
                                // Add selectable folder only.
                                if (item.Selectable)
                                {
                                    TreeNode n = node.Nodes.Add(item.ShortName);
                                    n.ImageIndex = 1;
                                    n.SelectedImageIndex = 1;
                                    n.Tag = item.Name;
                                }
                            }
                            node.Expand();
                            node.Checked = true;
                            nodes = node.Nodes;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Refreshes the message list.
        /// </summary>
        async void RefreshMessageList()
        {
            SetStatusText("Retrieving message list...");
            
            // Wake up GUI.
            Application.DoEvents();
            
            // Enable progress bar control.
            EnableProgress(true, client.GetFolderInfo(_currentFolder).TotalMessages);
            
            ImapMessageCollection col;

            try
            {
                // Asynchronously get message list.
                col = await client.ListMessagesAsync(ImapEnvelopeParts.UniqueId);
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
                EnableProgress(false, 0);
                return;
            }

            ShowMessageList(col);
        }


        async void DownloadImapMessage(MessageListInfo info)
        {
        Retry:

            ImapMessage m = info.List[info.Index];

            if (_cancelling)
                return;

            ImapMessage msg = null;
            try
            {
                // Retrieve message information.
                msg = await client.DownloadImapMessageAsync(m.UniqueId, ImapEnvelopeParts.Envelope);
            }
            catch (Exception ex)
            {
                if (!HandleException(ex))
                    return;
            }

            ShowMessage(msg, info);

            if (_state == ConnectionState.Disconnecting)
            {
                Disconnect();
                return;
            }

            if (!_cancelling && info.Index < info.List.Count)
                goto Retry;

            EnableProgress(false, 0);
            // Update the state.
            listView_SelectedIndexChanged(null, null);
        }
        
        bool HandleException(Exception ex)
        {
            ImapException ie = ex as ImapException;
            if (ie == null || ie.Status != MailClientExceptionStatus.OperationCancelled)
            {
                Util.ShowError(ie);
                EnableProgress(false, 0);
                // Update the state.
                listView_SelectedIndexChanged(null, null);
                return false;
            }

            return true;
        }

        bool ShowMessage(ImapMessage msg, MessageListInfo info)
        {
            info.Index++;

            if (msg != null)
            {
                // If From property is empty then use the Sender property.
                string from = msg.From.ToString();
                if (from.Length == 0 && msg.Sender != null)
                    from = msg.Sender.ToString();
                string[] arr = new string[]
                    {
                        from, msg.Subject, msg.Date != null ? msg.Date.ToString() : "1/1/1900",
                        (msg.Flags & ImapMessageFlags.Deleted) != 0 ? "Delete" : string.Empty, Util.FormatSize(msg.Size)
                    };
                ListViewItem item = new ListViewItem(arr);
                if ((msg.Flags & ImapMessageFlags.Seen) == 0)
                {
                    // New message.
                    item.Font = new Font(item.Font, item.Font.Style | FontStyle.Bold);
                    item.ImageIndex = 2;
                }
                else
                    // Seen message.
                    item.ImageIndex = 3;
                item.Tag = new ListItemTagInfo(msg.MessageInboxIndex, msg.UniqueId, msg.ReceivedDate, msg.Size);

                // Add to the list.
                listView.Items.Add(item);
                // Update the status text.
                toolStripProgressLabel.Text = string.Format("{0}/{1} message(s) retrieved", info.Index, info.List.Count);
            }
            else
            {
                toolStripProgressBar.Maximum--;
            }

            if (info.Index < toolStripProgressBar.Maximum)
                toolStripProgressBar.Value = info.Index;

            return info.Index < info.List.Count;
        }


        class MessageListInfo
        {
            public int Index;
            public ImapMessageCollection List;
        }
        
        void ShowMessageList(ImapMessageCollection col)
        {
            // Clear the message list.
            listView.Items.Clear();

            // Update the progress bar control.
            toolStripProgressBar.Maximum = col.Count;
            toolStripProgressBar.Value = 0;

            MessageListInfo info = new MessageListInfo();
            info.List = col;
            
            if (info.List.Count > 0)
                DownloadImapMessage(info);
            else
            {
                EnableProgress(false, 0);
                // Update the state.
                listView_SelectedIndexChanged(null, null);
            }
        }

        #region Event handlers

        /// <summary>
        /// Handles the client's ListProcessing event.
        /// </summary>
        /// <param name="sender">The client object.</param>
        /// <param name="e"></param>
        private void client_ListProcessing(object sender, ImapListProcessingEventArgs e)
        {
            // If the message list is being processed and the number of processed lines is valid.
            if (e.ListType == ImapListProcessingType.MessageList && toolStripProgressBar.Maximum > e.ProcessedLines && e.ProcessedLines > 0)
            {
                // Update the progress bar and progress status.
                toolStripProgressBar.Value = e.ProcessedLines;
                toolStripProgressLabel.Text = string.Format("{0}/{1} message(s) processed", e.ProcessedLines, toolStripProgressBar.Maximum);
            }
        }



        async void SelectDefaultFolder()
        {
            // If disconnecting
            if (_state == ConnectionState.Disconnecting)
            {
                Disconnect();
                return;
            }

            // Add the user name as the root node.
            TreeNode node = treeView.Nodes.Add(_settings.UserName);
            // Set root node image.
            node.ImageIndex = 0;
            // Selected image as well.
            node.SelectedImageIndex = 0;
            // Use Checked property as the node is Loaded state.
            node.Checked = true;
            //loginToolStripMenuItem.Text = "&Logout";

            // Select the default folder.
            await client.SelectAsync("INBOX");

            // Refresh the folder list.
            RefreshFolderList(string.Empty);

            // Set Ready state.
            SetStatusText("Ready");
            _state = ConnectionState.Ready;
            // Hide progress bar.
            toolStripProgressBar.Visible = false;
            toolStripProgressCancelButton.Visible = false;
            toolStripProgressLabel.Visible = false;
            tsbLogin.Visible = false;
            tsbLogout.Visible = true;
            tsbRefresh.Enabled = true;
            //refreshToolStripMenuItem.Enabled = true;

            EnableContextMenus(true);

            // Focus to the tree view.
            treeView.Focus();

            // Update states of the toolbar buttons.
            listView_SelectedIndexChanged(null, null);

            // Start the session timeout timer.
            sessionTimeoutTimer.Enabled = true;
            sessionTimeoutTimer.Interval = 1000;

            EnableDialog(true);
        }


        async void Authenticate()
        {
            if (_state == ConnectionState.Disconnecting)
            {
                Disconnect();
                return;
            }
            SetStatusText("Logging in as {0}...", _settings.UserName);

            try
            {
                // Asynchronously login to the IMAP server.
                await client.AuthenticateAsync(_settings.UserName, _settings.Password, _settings.Method);
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
                Disconnect();
                return;
            }

            SelectDefaultFolder();
        }

        /// <summary>
        /// Handles the client's Progress event.
        /// </summary>
        /// <param name="sender">The IMAP client object.</param>
        /// <param name="e">The event arguments.</param>
        void client_Progress(object sender, ImapProgressEventArgs e)
        {
            if (e.Length > 0 && (e.State == MailClientTransferState.Downloading || e.State == MailClientTransferState.Uploading))
            {
                // Update the status text.
                toolStripProgressLabel.Text = string.Format(e.State == MailClientTransferState.Downloading ? "{0}/{1} downloaded" : "{0}/{1} uploaded", Util.FormatSize(e.BytesTransferred), Util.FormatSize(e.Length));

                toolStripProgressBar.Value = (int)e.Percentage;
                // Wake up GUI.
                Application.DoEvents();
            }
        }

        #endregion

        #region Folder

        /// <summary>
        /// Deletes the selected folder.
        /// </summary>
        private void DeleteFolder()
        {
            string folder = _currentFolder;

            EnableDialog(false);

            try
            {
                SetStatusText("Deleting folder {0}...", folder);
                Application.DoEvents();
                client.DeleteFolder(folder);

                ////if (folder == _currentFolder)
                ////{
                //    _currentFolder = (string)treeView.SelectedNode.Parent.Tag;
                //    if (_currentFolder == null)
                //        _currentFolder = string.Empty;
                ////}

                treeView.SelectedNode.Parent.Checked = false;   // Reset folder list downloaded state.
                treeView.SelectedNode = treeView.SelectedNode.Parent;

                //RefreshFolderList();
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
            }
            finally
            {
                EnableDialog(true);
            }
        }

        /// <summary>
        /// Creates a new folder.
        /// </summary>
        private void NewFolder()
        {
            try
            {
                // Create a new TreeNode.
                TreeNode node = new TreeNode();
                // Get the parent node.
                TreeNode parentNode = treeView.SelectedNode;
                parentNode.Nodes.Add(node);
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
                // Expand the parent node.
                parentNode.Expand();
                // Begin edit folder name.
                node.BeginEdit();
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
            }
        }

        /// <summary>
        /// Purges all messages that are marked as delete.
        /// </summary>
        private void PurgeMessages()
        {
            try
            {
                // Purge messages.
                client.Purge();
                // Refresh the message list.
                RefreshMessageList();
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
            }
        }

        #endregion

        #region Message

        /// <summary>
        /// Uploads message from local file.
        /// </summary>
        private void UploadMessage()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Email files (*.eml)|*.eml|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            // Show open file dialog to select file to upload.
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    EnableProgress(true, 100);
                    Application.DoEvents();

                    // Upload the selected message file.
                    client.UploadMessage(_currentFolder, dlg.FileName);
                    RefreshMessageList();
                }
                catch (Exception exc)
                {
                    Reconnect(_cancelling ? null : exc);
                }
                finally
                {
                    EnableProgress(false, 0);
                }
            }
        }

        /// <summary>
        /// Deletes selected messages.
        /// </summary>
        private void DeleteMessages()
        {
            // Show a confirmation message box.
            if (MessageBox.Show(string.Format("Are you sure you want to delete {0} message(s)?", listView.SelectedItems.Count), "Imap Client Demo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            // Enable progress bar, and disable other controls.
            EnableProgress(true, listView.SelectedItems.Count);
            try
            {
                int value = 0;
                foreach (ListViewItem item in listView.SelectedItems)
                {
                    // User has cancelled the operation?
                    if (_cancelling)
                        break;
                    Application.DoEvents();
                    // Delete a message.
                    client.DeleteMessage(((ListItemTagInfo)item.Tag).SequenceNumber);
                    _messagesDelete = true;
                    item.SubItems[3].Text = "Delete";
                    item.Font = new Font(item.Font, item.Font.Style | FontStyle.Strikeout);
                    toolStripProgressBar.Value = ++value;
                    toolStripProgressLabel.Text = string.Format("{0}/{1} message(s) deleted", value, listView.SelectedItems.Count);
                }
            }
            catch (Exception exc)
            {
                Reconnect(exc);
            }
            finally
            {
                EnableProgress(false, 0);
            }
        }

        /// <summary>
        /// Undeletes messages.
        /// </summary>
        private void UndeleteMessages()
        {
            // Enable progress bar and disable other controls.
            EnableProgress(true, listView.SelectedItems.Count);
            try
            {
                int value = 0;
                foreach (ListViewItem item in listView.SelectedItems)
                {
                    // User has cancelled the operation.
                    if (_cancelling)
                        break;
                    // Wake up GUI.
                    Application.DoEvents();
                    // Undelete the selected messages.
                    client.UndeleteMessage(((ListItemTagInfo)item.Tag).SequenceNumber);
                    item.SubItems[3].Text = string.Empty;
                    item.Font = new Font(item.Font, (item.Font.Style | FontStyle.Strikeout) ^ FontStyle.Strikeout);
                    // Update the progress bar and progress status.
                    toolStripProgressBar.Value = ++value;
                    toolStripProgressLabel.Text = string.Format("{0}/{1} message(s) undeleted", value, listView.SelectedItems.Count);
                }
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
            }
            finally
            {
                EnableProgress(false, 0);
            }
        }

        string _copyFolder;
        ImapMessageSet _copyInfo;
        /// <summary>
        /// Copies messages
        /// </summary>
        private void CopyMessage()
        {
            // Create a new ImapMessageIdSet that contains information about the messages being copied.
            _copyInfo = new ImapMessageSet();
            // Add selected messages to the message set;
            foreach (ListViewItem item in listView.SelectedItems)
            {
                _copyInfo.Add(((ListItemTagInfo)item.Tag).UniqueId);
            }
            // Save the selected folder.
            _copyFolder = _currentFolder;
        }

        /// <summary>
        /// Pastes the copied messages to the specified destination folder.
        /// </summary>
        /// <param name="destFolder">The destination folder that stores the copied messages.</param>
        public void PasteMessage(string destFolder)
        {
            // Select the previously selected folder.
            client.Select(_copyFolder);
            // Copy messages.
            client.CopyMessage(_copyInfo, destFolder);
            // Select the current working folder.
            client.Select(_currentFolder);

            // Refresh the message list.
            RefreshMessageList();
        }

        #endregion

        #region Certificate

        /// <summary>
        /// Returns all issues of the given certificate.
        /// </summary>
        private static string GetCertProblem(CertificateVerificationStatus status, int code, ref bool showAddTrusted)
        {
            switch (status)
            {
                case CertificateVerificationStatus.TimeNotValid:
                    return "Server's certificate has expired or is not valid yet.";

                case CertificateVerificationStatus.Revoked:
                    return "Server's certificate has been revoked.";

                case CertificateVerificationStatus.UnknownCA:
                    return "Server's certificate was issued by an unknown authority.";

                case CertificateVerificationStatus.RootNotTrusted:
                    showAddTrusted = true;
                    return "Server's certificate was issued by an untrusted authority.";

                case CertificateVerificationStatus.IncompleteChain:
                    return "Server's certificate does not chain up to a trusted root authority.";

                case CertificateVerificationStatus.Malformed:
                    return "Server's certificate is malformed.";

                case CertificateVerificationStatus.CNNotMatch:
                    return "Server hostname does not match the certificate.";

                case CertificateVerificationStatus.UnknownError:
                    return string.Format("Error {0:x} encountered while validating server's certificate.", code);

                default:
                    return status.ToString();
            }
        }

        void client_CertificateReceived(object sender, ComponentPro.Security.CertificateReceivedEventArgs e)
        {
            CertValidator dlg = new CertValidator();

            CertificateVerificationStatus status = e.Status;

            CertificateVerificationStatus[] values = (CertificateVerificationStatus[])Enum.GetValues(typeof(CertificateVerificationStatus));

            StringBuilder sbIssues = new StringBuilder();
            bool showAddTrusted = false;
            for (int i = 0; i < values.Length; i++)
            {
                // Matches the validation status?
                if ((status & values[i]) == 0)
                    continue;

                // The issue is processed.
                status ^= values[i];

                sbIssues.AppendFormat("{0}\r\n", GetCertProblem(values[i], e.ErrorCode, ref showAddTrusted));
            }

            dlg.Certificate = e.ServerCertificates[0];
            dlg.Issues = sbIssues.ToString();
            dlg.ShowAddToTrustedList = showAddTrusted;

            dlg.ShowDialog();

            e.AddToTrustedRoot = dlg.AddToTrustedList;
            e.Accept = dlg.Accepted;
        }

        private void client_CertificateRequired(object sender, ComponentPro.Security.CertificateRequiredEventArgs e)
        {
            // If the client cert file is specified.
            if (!string.IsNullOrEmpty(_settings.Cert))
            {
                // Load Certificate.
                PasswordPrompt passdlg = new PasswordPrompt();
                // Ask for cert's passpharse
                if (passdlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    X509Certificate2 clientCert = new X509Certificate2(_settings.Cert, passdlg.Password);
                    e.Certificates = new X509Certificate2Collection(clientCert);
                    return;
                }

                // Password has not been provided.
            }
            CertProvider dlg = new CertProvider();
            dlg.ShowDialog();
            // Get the selected certificate.
            e.Certificates = new X509Certificate2Collection(dlg.SelectedCertificate);
        }

        #endregion
    }
}

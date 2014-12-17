using System;
using System.Windows.Forms;
using ComponentPro.Net.Mail;
using System.IO;

namespace ImapClient
{
    public partial class MessageViewer : Form
    {
        readonly Imap _client;
        readonly string _uniqueId;
        MailMessage _msg;
        private bool _abort;

        public MessageViewer()
        {
            InitializeComponent();
        }

        public MessageViewer(Imap client, string uniqueId)
        {
            InitializeComponent();

            _client = client;
            _uniqueId = uniqueId;
        }

        /// <summary>
        /// Handles the form's Load event.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Disable the X button.
            Util.EnableCloseButton(this, false);
        }

        /// <summary>
        /// Handles the form's Shown event.
        /// </summary>
        /// <param name="e">The even arguments.</param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            try
            {
                _client.Progress += _client_Progress;

                // Create a new memory stream to store the downloaded message.
                MemoryStream mem = new MemoryStream();
                // Get message data to the newly created memory stream.
                _client.DownloadMessage(_uniqueId, mem);
                // Create a new message from the memory stream.
                mem.Seek(0, SeekOrigin.Begin);
                // Get raw data;
                byte[] rawData = mem.ToArray();
                
                _msg = new MailMessage(mem);

                // Fill from, to, cc.
                txtFrom.Text = _msg.From.ToString();
                txtTo.Text = _msg.To.ToString();
                txtCc.Text = _msg.Cc.ToString();

                // Fill subject.
                txtSubject.Text = _msg.Subject;

                saveAsToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                selectAllToolStripMenuItem.Enabled = true;
                Util.EnableCloseButton(this, true);

                // Fill the attachment list.
                if (_msg.Attachments.Count > 0)
                    foreach (Attachment at in _msg.Attachments)
                    {
                        cbxAttachment.Items.Add(at.FileName);
                    }

                if (cbxAttachment.Items.Count > 0)
                {
                    cbxAttachment.SelectedIndex = 0;
                    saveAttachmentsToolStripMenuItem.Enabled = true;
                }
                else
                {
                    cbxAttachment.Enabled = false;
                    saveAttachmentsToolStripMenuItem.Enabled = false;
                }

                // Fill body plain text version.
                txtBody.Text = _msg.BodyText.Replace("\n", "\r\n");
                // Fill body HTML version.
                txtHtml.Text = _msg.BodyHtml.Replace("\n", "\r\n");

                HeaderCollection headers = _msg.Headers;

                // Show all message header
                for (int i = 0; i < headers.Count; i++)
                {
                    Header header = headers[i];

                    // add name column
                    ListViewItem item = new ListViewItem(header.Name);

                    // add header raw content column
                    item.SubItems.Add(header.Raw);

                    // show unparsed (corrupted) headers in red				
                    if (header.Unparsable)
                        item.ForeColor = System.Drawing.Color.Red;

                    // add row to the ListView				
                    lvwHeaders.Items.Add(item);
                }

                // Fill raw message.
                string rawtext = System.Text.Encoding.Default.GetString(rawData, 0, Math.Min(rawData.Length, 500000));
                txtRawText.Text = rawtext;
            }
            catch (Exception exc)
            {                
                if (!_abort)
                    Util.ShowError(exc);
                else
                    this.DialogResult = DialogResult.Abort;

                this.Close();
            }
            finally
            {
                // Unregister the Progress event handler.
                _client.Progress -= _client_Progress;
                toolStripProgressLabel.Visible = false;
                toolStripProgressBar.Visible = false;
                toolStripProgressCancelButton.Visible = false;
                toolStripStatusLabel.Visible = true;
            }            
        }

        /// <summary>
        /// Handles the client's Progress event.
        /// </summary>
        /// <param name="sender">The imap client object.</param>
        /// <param name="e">The event arguments.</param>
        void _client_Progress(object sender, ImapProgressEventArgs e)
        {
            if (e.Length > 0 && (e.State == MailClientTransferState.Downloading || e.State == MailClientTransferState.Uploading))
            {
                toolStripProgressLabel.Text = string.Format("{0}/{1} downloaded", Util.FormatSize(e.BytesTransferred), Util.FormatSize(e.Length));
                toolStripProgressBar.Value = (int) e.Percentage;
                Application.DoEvents();
            }
        }

        /// <summary>
        /// Shows Save as dialog and save the message to the specified file.
        /// </summary>
        private void SaveMessageAs()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            try
            {
                dlg.OverwritePrompt = true;
                dlg.Filter = "Email files (*.eml)|*.eml|All files (*.*)|*.*";
                dlg.FilterIndex = 1;
                dlg.Title = "Save the mail as";
                // Show the Save File As dialog.
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;                
            }
            catch
            {
                MessageBox.Show(dlg.FileName + " is not an email file", "Error");
            }

            SaveMessageAs(dlg.FileName);
        }

        /// <summary>
        /// Saves the current message as a file.
        /// </summary>
        /// <param name="fileName"></param>
        private void SaveMessageAs(string fileName)
        {
            try
            {
                _msg.Save(fileName);
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
            }
        }

        /// <summary>
        /// Saves attachments to a specific folder.
        /// </summary>
        private void SaveAttachmentAs(string folder)
        {
            try
            {
                foreach (Attachment att in _msg.Attachments)
                {
                    att.Save(Path.Combine(folder, att.FileName));
                }
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
            }
        }

        /// <summary>
        /// Saves attachments to a specific folder. A browing folder dialog will be shown.
        /// </summary>
        private void SaveAttachmentAs()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                return;

            string path = folderBrowserDialog.SelectedPath;
            SaveAttachmentAs(path);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtBody.SelectAll();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveMessageAs();
        }

        private void saveAttachmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAttachmentAs();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtBody.Copy();
        }

        private void toolStripProgressCancelButton_ButtonClick(object sender, EventArgs e)
        {
            // Cancel the operation.
            _abort = true;
            _client.Cancel();            
        }
    }
}
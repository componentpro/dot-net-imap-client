using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentPro.Net;
using ComponentPro.Net.Mail;
using ComponentPro.Security.Certificates;
using ImapClient.Security;

namespace ImapClient
{
    public partial class ImapClient
    {
        #region Toolbar

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            RefreshFolderList();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            // Delete folder or message?
            if (treeView.Focused)
            {
                DeleteFolder();
            }
            else
            {
                DeleteMessages();
            }
        }

        private void tsbUndelete_Click(object sender, EventArgs e)
        {
            UndeleteMessages();
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            client.Progress -= client_Progress;
            MessageViewer form = new MessageViewer(client, ((ListItemTagInfo)listView.SelectedItems[0].Tag).UniqueId);
            // Show the MessageViewer form.
            DialogResult r = form.ShowDialog();
            client.Progress += client_Progress;
            if (r == DialogResult.Abort)
            {
                // Reconnect to the Imap server if the opening operation has been aborted.
                Reconnect(null);
            }
        }

        private void tsbSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sav = new SaveFileDialog();
            sav.Filter = "Email files (*.eml)|*.eml|All files (*.*)|*.*";
			sav.FilterIndex = 1;
            sav.Title = "Save the mail as";
            
            // Show the Save File as dialog.
            if (sav.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    EnableProgress(true, 100);
                    Application.DoEvents();

                    // Get unique Id string.
                    string uniqueId = ((ListItemTagInfo)listView.SelectedItems[0].Tag).UniqueId;
                    client.Progress += client_Progress;
                    client.DownloadMessage(uniqueId, sav.FileName);
                }
                catch (Exception exc)
                {
                    Reconnect(_cancelling ? null : exc);
                }
                finally
                {
                    client.Progress -= client_Progress;
                    EnableProgress(false, 0);
                }
            }
        }

        private void tsbLogin_Click(object sender, EventArgs e)
        {
            // Show the Login form.
            Login form = new Login(_settings);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Connect();
            }
        }

        private void tsbLogout_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        #endregion
    }
}
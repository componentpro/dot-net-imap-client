using System;
using System.Windows.Forms;
using ComponentPro.Net.Mail;

namespace ImapClient
{
    public partial class ImapClient
    {
        /// <summary>
        /// Handles the folder tree view's AfterLabelEdit event.
        /// </summary>
        /// <param name="sender">The folder tree view object.</param>
        /// <param name="e">The event arguments.</param>
        private void treeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            // Return if not connected.
            if (client.State != MailClientState.Ready)
            {
                _editing = false;
                return;
            }

            // Name has not been changed.
            if (e.Node == null || string.IsNullOrEmpty(e.Label))
            {
                if (e.Node.Tag == null) // New node
                {
                    e.Node.Remove();
                }
                _editing = false;
                return;
            }

            // Contain an invalid character?
            if (e.Label.IndexOf('*') >= 0)
            {
                MessageBox.Show("Invalid folder name", "IMAP Client Demo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.CancelEdit = true;
                if (e.Node.Tag == null) // New node
                {
                    e.Node.Remove();
                }
                _editing = false;
                return;
            }

            // Make sure name is unique.
            foreach (TreeNode node in e.Node.Parent.Nodes)
            {
                if (e.Label == node.Text)
                {
                    if (e.Node != node)
                        e.Node.BeginEdit();
                    _editing = false;
                    return;
                }
            }

            // If this is a new folder.
            if (e.Node.Tag == null)
            {
                try
                {
                    EnableDialog(false);
                    string folder = _currentFolder.Length == 0 ? e.Label : (_currentFolder + "/" + e.Label);
                    client.CreateFolder(folder);
                    e.Node.Tag = folder;
                    client.Select(folder);
                    _currentFolder = folder;
                    listView.Items.Clear(); // Clear items as it is a newly created folder and does not have any new messages.
                    e.Node.Text = e.Label;
                }
                catch (Exception exc)
                {
                    e.CancelEdit = true;
                    Util.ShowError(exc);
                    e.Node.Remove();
                }
                finally
                {
                    _editing = false;
                    EnableDialog(true);
                }
            }
            else // Then rename
            {
                string oldName = (string)e.Node.Tag;
                string path;
                int i = oldName.LastIndexOf("/");
                if (i >= 0)
                    path = oldName.Substring(0, i) + "/" + e.Label;
                else
                    path = e.Label;

                try
                {
                    client.Select("INBOX");
                    _currentFolder = "INBOX";
                    client.RenameFolder(oldName, path);
                    e.Node.Tag = path;
                    _currentFolder = path;
                    client.Select(_currentFolder);
                    RefreshFolderList();
                }
                catch (Exception exc)
                {
                    e.CancelEdit = true;
                    Util.ShowError(exc);
                }
                finally
                {
                    _editing = false;
                }
            }
        }

        private bool _editing;
        /// <summary>
        /// Handles the folder tree view's BeforeLabelEdit event.
        /// </summary>
        /// <param name="sender">The folder tree view object.</param>
        /// <param name="e">The event arguments.</param>
        private void treeView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            // Cannot rename the root node.
            if (e.Node.Parent == null)
                e.CancelEdit = true;
            else
                _editing = true;
        }

        /// <summary>
        /// Handles the folder tree view's MouseDown event.
        /// </summary>
        /// <param name="sender">The folder tree view object.</param>
        /// <param name="e">The event arguments.</param>
        private void treeView_MouseDown(object sender, MouseEventArgs e)
        {
            // Show Context Menu.
            if (e.Button == MouseButtons.Right)
            {
                // Set selected box to one at location of click
                if (treeView.SelectedNode != treeView.GetNodeAt(e.X, e.Y))
                    treeView.SelectedNode = treeView.GetNodeAt(e.X, e.Y);

                //Show context menu
                //treeViewContextMenuStrip.Show();
            }
        }

        bool _noFireBeforeSelectEvent;
        /// <summary>
        /// Handles the folder tree view's BeforeSelect event.
        /// </summary>
        /// <param name="sender">The folder tree view object.</param>
        /// <param name="e">The event arguments.</param>
        private void treeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (_editing)
                return;

            try
            {
                if (!_noFireBeforeSelectEvent)
                {
                    if (e.Node.Parent != null)
                    {
                        _currentFolder = (string)e.Node.Tag;
                        client.Select(_currentFolder);
                        if (e.Node.Checked)
                        {
                            RefreshMessageList();
                        }
                        else
                        {
                            RefreshFolderList();
                            e.Node.Checked = true;
                        }
                        deleteFolderContextMenuItem.Enabled = true; 
                        renameContextMenuItem.Enabled = true; 
                        pasteContextMenuItem.Enabled = _copyInfo != null && _copyInfo.Count > 0; pasteMessagesTreeViewContextMenuItem.Enabled = _copyInfo != null && _copyInfo.Count > 0;
                        uploadLocalMessagesContextMenuItem.Enabled = true; 
                        uploadMessageToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        _currentFolder = string.Empty;
                        listView.Items.Clear();

                        if (!e.Node.Checked)
                        {
                            client.Select("INBOX");
                            RefreshFolderList();
                            e.Node.Checked = true;
                        }

                        deleteFolderContextMenuItem.Enabled = false; 
                        renameContextMenuItem.Enabled = false; 
                        pasteContextMenuItem.Enabled = false; pasteMessagesTreeViewContextMenuItem.Enabled = false;
                        uploadLocalMessagesContextMenuItem.Enabled = false; 
                        uploadMessageToolStripMenuItem.Enabled = true;

                        listView_SelectedIndexChanged(null, null);
                    }
                }
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
            }
        }

        /// <summary>
        /// Handles the folder tree view's KeyDown event.
        /// </summary>
        /// <param name="sender">The folder tree view object.</param>
        /// <param name="e">The event arguments.</param>
        private void treeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && treeView.SelectedNode.Parent != null)
            {
                treeView.SelectedNode.BeginEdit();
            }
        }
    }
}
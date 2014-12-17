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
        private int _lastColumnToSort;
        private SortOrder _lastSortOrder;
        
        /// <summary>
        /// Handles the message list view's SelectedIndexChanged event.
        /// </summary>
        /// <param name="sender">The message list view object.</param>
        /// <param name="e">The event arguments.</param>
        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool enable = listView.Focused && listView.SelectedItems.Count > 0;
            bool undoable = enable && (listView.SelectedItems.Count > 1 || listView.SelectedItems[0].SubItems[3].Text == "Delete");

            // Enable/disable toolbar buttons accordingly.
            tsbDelete.Enabled = enable && (listView.SelectedItems.Count > 1 || listView.SelectedItems[0].SubItems[3].Text != "Delete");
            tsbUndelete.Enabled = undoable;
            tsbOpen.Enabled = enable;
            tsbSaveAs.Enabled = enable;
            tsbCopy.Enabled = enable;
            tsbPaste.Enabled = _copyInfo != null && _copyInfo.Count > 0 && !string.IsNullOrEmpty(_currentFolder);
            tsbUpload.Enabled = _currentFolder.Length > 0;

            // Enable/disable menu items accordingly.
            deleteContextMenuItem.Enabled = tsbDelete.Enabled;
            undeleteContextMenuItem.Enabled = undoable;
            openContextMenuItem.Enabled = enable;
            saveMessageAsContextMenuItem.Enabled = enable;
            copyToolStripMenuItem.Enabled = enable; copyContextMenuItem.Enabled = enable;
            pasteMessagesTreeViewContextMenuItem.Enabled = tsbPaste.Enabled; pasteToolStripMenuItem.Enabled = tsbPaste.Enabled; pasteContextMenuItem.Enabled = tsbPaste.Enabled;

            purgeDeletedMessagesContextMenuItem.Enabled = _currentFolder.Length > 0; tsbPurge.Enabled = _currentFolder.Length > 0;
            uploadLocalMessagesContextMenuItem.Enabled = _currentFolder.Length > 0; 
            uploadMessageToolStripMenuItem.Enabled = _currentFolder.Length > 0;
        }

        /// <summary>
        /// Handles the message list view's DoubleClick event.
        /// </summary>
        /// <param name="sender">The list view control.</param>
        /// <param name="e">The event arguments.</param>
        private void listView_DoubleClick(object sender, EventArgs e)
        {
            tsbOpen_Click(sender, null);
        }

        /// <summary>
        /// Handles the message list view's ColumnClick event.
        /// </summary>
        /// <param name="sender">The list view control.</param>
        /// <param name="e">The event arguments.</param>
        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Return if no messages found.
            if (listView.Items.Count == 0)
                return;

            SortOrder sortOrder;
            if (_lastColumnToSort == e.Column)
            {
                if (_lastSortOrder == SortOrder.Ascending)
                    sortOrder = SortOrder.Descending;
                else
                    sortOrder = SortOrder.Ascending;
            }
            else
                sortOrder = SortOrder.Ascending;

            switch (e.Column)
            {
                case 0:
                case 1:
                case 3:
                    listView.ListViewItemSorter = new ListViewItemNameSorter(e.Column, sortOrder); // Sort by subitem's text.
                    break;

                case 2:
                    listView.ListViewItemSorter = new ListViewItemDateSorter(e.Column, sortOrder); // Sort by date time.
                    break;

                case 4:
                    listView.ListViewItemSorter = new ListViewItemSizeSorter(e.Column, sortOrder); // Sort by size.
                    break;
            }

            _lastColumnToSort = e.Column;
            _lastSortOrder = sortOrder;
        }
    }
}
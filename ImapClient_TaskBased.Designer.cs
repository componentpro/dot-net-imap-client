using System.Drawing;
using System.Windows.Forms;

namespace ImapClient
{
    partial class ImapClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImapClient));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripProgressCancelButton = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripProgressLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripButton();
            this.tsbPurge = new System.Windows.Forms.ToolStripButton();
            this.tsbLogin = new System.Windows.Forms.ToolStripButton();
            this.tsbLogout = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbUndelete = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveAs = new System.Windows.Forms.ToolStripButton();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbPaste = new System.Windows.Forms.ToolStripButton();
            this.tsbUpload = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeView = new System.Windows.Forms.TreeView();
            this.treeViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newFolderContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFolderContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteMessagesTreeViewContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purgeDeletedMessagesContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadLocalMessagesContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.listView = new System.Windows.Forms.ListView();
            this.chFrom = new System.Windows.Forms.ColumnHeader();
            this.chSubject = new System.Windows.Forms.ColumnHeader();
            this.chReceived = new System.Windows.Forms.ColumnHeader();
            this.chStatus = new System.Windows.Forms.ColumnHeader();
            this.chSize = new System.Windows.Forms.ColumnHeader();
            this.listViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undeleteContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMessageAsContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sessionTimeoutTimer = new System.Windows.Forms.Timer(this.components);
            this.client = new ComponentPro.Net.Mail.Imap();
            this.toolbarMain = new System.Windows.Forms.ToolStrip();
            this.statusStrip.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.treeViewContextMenuStrip.SuspendLayout();
            this.listViewContextMenuStrip.SuspendLayout();
            this.toolbarMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar,
            this.toolStripProgressCancelButton,
            this.toolStripProgressLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 447);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(728, 22);
            this.statusStrip.TabIndex = 131;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel.Text = "Ready";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(200, 16);
            this.toolStripProgressBar.Visible = false;
            // 
            // toolStripProgressCancelButton
            // 
            this.toolStripProgressCancelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripProgressCancelButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripProgressCancelButton.Image")));
            this.toolStripProgressCancelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripProgressCancelButton.Name = "toolStripProgressCancelButton";
            this.toolStripProgressCancelButton.Size = new System.Drawing.Size(32, 20);
            this.toolStripProgressCancelButton.Text = "Cancel Downloading";
            this.toolStripProgressCancelButton.Visible = false;
            this.toolStripProgressCancelButton.ButtonClick += new System.EventHandler(this.toolStripProgressCancelButton_ButtonClick);
            // 
            // toolStripProgressLabel
            // 
            this.toolStripProgressLabel.Name = "toolStripProgressLabel";
            this.toolStripProgressLabel.Size = new System.Drawing.Size(10, 17);
            this.toolStripProgressLabel.Text = " ";
            this.toolStripProgressLabel.Visible = false;
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Enabled = false;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem1_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Enabled = false;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem1_Click);
            // 
            // tsbPurge
            // 
            this.tsbPurge.AutoSize = false;
            this.tsbPurge.Enabled = false;
            this.tsbPurge.Image = ((System.Drawing.Image)(resources.GetObject("tsbPurge.Image")));
            this.tsbPurge.Name = "tsbPurge";
            this.tsbPurge.Size = new System.Drawing.Size(49, 49);
            this.tsbPurge.Text = "Purge";
            this.tsbPurge.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPurge.ToolTipText = "Purge all messages marked as deleted";
            this.tsbPurge.Click += new System.EventHandler(this.tsbPurge_Click);
            // 
            // tsbLogin
            // 
            this.tsbLogin.AutoSize = false;
            this.tsbLogin.Image = ((System.Drawing.Image)(resources.GetObject("tsbLogin.Image")));
            this.tsbLogin.Name = "tsbLogin";
            this.tsbLogin.Size = new System.Drawing.Size(55, 49);
            this.tsbLogin.Text = "Connect";
            this.tsbLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbLogin.Click += new System.EventHandler(this.tsbLogin_Click);
            // 
            // tsbLogout
            // 
            this.tsbLogout.Image = ((System.Drawing.Image)(resources.GetObject("tsbLogout.Image")));
            this.tsbLogout.Name = "tsbLogout";
            this.tsbLogout.Size = new System.Drawing.Size(63, 49);
            this.tsbLogout.Text = "Disconnect";
            this.tsbLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbLogout.Visible = false;
            this.tsbLogout.Click += new System.EventHandler(this.tsbLogout_Click);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.AutoSize = false;
            this.tsbRefresh.Enabled = false;
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(55, 49);
            this.tsbRefresh.Text = "Refresh";
            this.tsbRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.AutoSize = false;
            this.tsbDelete.Enabled = false;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(55, 49);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbOpen
            // 
            this.tsbOpen.AutoSize = false;
            this.tsbOpen.Enabled = false;
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(55, 49);
            this.tsbOpen.Text = "Open";
            this.tsbOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbOpen.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // tsbUndelete
            // 
            this.tsbUndelete.Enabled = false;
            this.tsbUndelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbUndelete.Image")));
            this.tsbUndelete.Name = "tsbUndelete";
            this.tsbUndelete.Size = new System.Drawing.Size(54, 49);
            this.tsbUndelete.Text = "Undelete";
            this.tsbUndelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbUndelete.Click += new System.EventHandler(this.tsbUndelete_Click);
            // 
            // tsbSaveAs
            // 
            this.tsbSaveAs.AutoSize = false;
            this.tsbSaveAs.Enabled = false;
            this.tsbSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveAs.Image")));
            this.tsbSaveAs.Name = "tsbSaveAs";
            this.tsbSaveAs.Size = new System.Drawing.Size(55, 49);
            this.tsbSaveAs.Text = "Save As";
            this.tsbSaveAs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSaveAs.Click += new System.EventHandler(this.tsbSaveAs_Click);
            // 
            // tsbCopy
            // 
            this.tsbCopy.Enabled = false;
            this.tsbCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsbCopy.Image")));
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(86, 49);
            this.tsbCopy.Text = "Copy Messages";
            this.tsbCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCopy.Click += new System.EventHandler(this.tsbCopy_Click);
            // 
            // tsbPaste
            // 
            this.tsbPaste.Enabled = false;
            this.tsbPaste.Image = ((System.Drawing.Image)(resources.GetObject("tsbPaste.Image")));
            this.tsbPaste.Name = "tsbPaste";
            this.tsbPaste.Size = new System.Drawing.Size(88, 49);
            this.tsbPaste.Text = "Paste Messages";
            this.tsbPaste.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPaste.Click += new System.EventHandler(this.tsbPaste_Click);
            // 
            // tsbUpload
            // 
            this.tsbUpload.AutoSize = false;
            this.tsbUpload.Enabled = false;
            this.tsbUpload.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpload.Image")));
            this.tsbUpload.Name = "tsbUpload";
            this.tsbUpload.Size = new System.Drawing.Size(55, 49);
            this.tsbUpload.Text = "Upload";
            this.tsbUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbUpload.Click += new System.EventHandler(this.tsbUpload_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 52);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.listView);
            this.splitContainer.Size = new System.Drawing.Size(728, 395);
            this.splitContainer.SplitterDistance = 241;
            this.splitContainer.TabIndex = 136;
            // 
            // treeView
            // 
            this.treeView.ContextMenuStrip = this.treeViewContextMenuStrip;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.ImageIndex = 1;
            this.treeView.ImageList = this.imageList;
            this.treeView.LabelEdit = true;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(241, 395);
            this.treeView.TabIndex = 0;
            this.treeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView_AfterLabelEdit);
            this.treeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseDown);
            this.treeView.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView_BeforeLabelEdit);
            this.treeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_BeforeSelect);
            this.treeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView_KeyDown);
            // 
            // treeViewContextMenuStrip
            // 
            this.treeViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFolderContextMenuItem,
            this.deleteFolderContextMenuItem,
            this.renameContextMenuItem,
            this.pasteMessagesTreeViewContextMenuItem,
            this.purgeDeletedMessagesContextMenuItem,
            this.uploadLocalMessagesContextMenuItem});
            this.treeViewContextMenuStrip.Name = "treeViewContextMenuStrip";
            this.treeViewContextMenuStrip.Size = new System.Drawing.Size(204, 136);
            // 
            // newFolderContextMenuItem
            // 
            this.newFolderContextMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newFolderContextMenuItem.Image")));
            this.newFolderContextMenuItem.Name = "newFolderContextMenuItem";
            this.newFolderContextMenuItem.Size = new System.Drawing.Size(203, 22);
            this.newFolderContextMenuItem.Text = "New Folder";
            this.newFolderContextMenuItem.Click += new System.EventHandler(this.newFolderContextMenuItem_Click);
            // 
            // deleteFolderContextMenuItem
            // 
            this.deleteFolderContextMenuItem.Enabled = false;
            this.deleteFolderContextMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteFolderContextMenuItem.Image")));
            this.deleteFolderContextMenuItem.Name = "deleteFolderContextMenuItem";
            this.deleteFolderContextMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteFolderContextMenuItem.Size = new System.Drawing.Size(203, 22);
            this.deleteFolderContextMenuItem.Text = "Delete Folder";
            this.deleteFolderContextMenuItem.Click += new System.EventHandler(this.deleteFolderContextMenuItem_Click);
            // 
            // renameContextMenuItem
            // 
            this.renameContextMenuItem.Enabled = false;
            this.renameContextMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("renameContextMenuItem.Image")));
            this.renameContextMenuItem.Name = "renameContextMenuItem";
            this.renameContextMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.renameContextMenuItem.Size = new System.Drawing.Size(203, 22);
            this.renameContextMenuItem.Text = "Rename Folder";
            this.renameContextMenuItem.Click += new System.EventHandler(this.renameContextMenuItem_Click);
            // 
            // pasteMessagesTreeViewContextMenuItem
            // 
            this.pasteMessagesTreeViewContextMenuItem.Enabled = false;
            this.pasteMessagesTreeViewContextMenuItem.Name = "pasteMessagesTreeViewContextMenuItem";
            this.pasteMessagesTreeViewContextMenuItem.Size = new System.Drawing.Size(203, 22);
            this.pasteMessagesTreeViewContextMenuItem.Text = "Paste Messages";
            this.pasteMessagesTreeViewContextMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteMessagesTreeViewContextMenuItem.Click += new System.EventHandler(this.pasteMessagesContextMenuItem_Click);
            // 
            // purgeDeletedMessagesContextMenuItem
            // 
            this.purgeDeletedMessagesContextMenuItem.Enabled = false;
            this.purgeDeletedMessagesContextMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("purgeDeletedMessagesContextMenuItem.Image")));
            this.purgeDeletedMessagesContextMenuItem.Name = "purgeDeletedMessagesContextMenuItem";
            this.purgeDeletedMessagesContextMenuItem.Size = new System.Drawing.Size(203, 22);
            this.purgeDeletedMessagesContextMenuItem.Text = "Purge Deleted Messages";
            this.purgeDeletedMessagesContextMenuItem.Click += new System.EventHandler(this.purgeDeletedMessagesContextMenuItem_Click);
            // 
            // uploadLocalMessagesContextMenuItem
            // 
            this.uploadLocalMessagesContextMenuItem.Enabled = false;
            this.uploadLocalMessagesContextMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("uploadLocalMessagesContextMenuItem.Image")));
            this.uploadLocalMessagesContextMenuItem.Name = "uploadLocalMessagesContextMenuItem";
            this.uploadLocalMessagesContextMenuItem.Size = new System.Drawing.Size(203, 22);
            this.uploadLocalMessagesContextMenuItem.Text = "Upload Local Message...";
            this.uploadLocalMessagesContextMenuItem.Click += new System.EventHandler(this.uploadLocalMessagesContextMenuItem_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Mailbox.ico");
            this.imageList.Images.SetKeyName(1, "Folder.ico");
            this.imageList.Images.SetKeyName(2, "UnreadMail.ico");
            this.imageList.Images.SetKeyName(3, "OpenedMail.ico");
            // 
            // listView
            // 
            this.listView.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFrom,
            this.chSubject,
            this.chReceived,
            this.chStatus,
            this.chSize});
            this.listView.ContextMenuStrip = this.listViewContextMenuStrip;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(483, 395);
            this.listView.SmallImageList = this.imageList;
            this.listView.TabIndex = 136;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            // 
            // chFrom
            // 
            this.chFrom.Text = "From";
            this.chFrom.Width = 100;
            // 
            // chSubject
            // 
            this.chSubject.Text = "Subject";
            this.chSubject.Width = 180;
            // 
            // chReceived
            // 
            this.chReceived.Text = "Received";
            this.chReceived.Width = 100;
            // 
            // chStatus
            // 
            this.chStatus.Text = "Status";
            this.chStatus.Width = 120;
            // 
            // chSize
            // 
            this.chSize.Text = "Size";
            // 
            // listViewContextMenuStrip
            // 
            this.listViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openContextMenuItem,
            this.deleteContextMenuItem,
            this.undeleteContextMenuItem,
            this.saveMessageAsContextMenuItem,
            this.copyContextMenuItem,
            this.pasteContextMenuItem,
            this.uploadMessageToolStripMenuItem});
            this.listViewContextMenuStrip.Name = "listViewContextMenuStrip";
            this.listViewContextMenuStrip.Size = new System.Drawing.Size(203, 158);
            // 
            // openContextMenuItem
            // 
            this.openContextMenuItem.Enabled = false;
            this.openContextMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openContextMenuItem.Image")));
            this.openContextMenuItem.Name = "openContextMenuItem";
            this.openContextMenuItem.Size = new System.Drawing.Size(202, 22);
            this.openContextMenuItem.Text = "Open...";
            this.openContextMenuItem.Click += new System.EventHandler(this.openContextMenuItem_Click);
            // 
            // deleteContextMenuItem
            // 
            this.deleteContextMenuItem.Enabled = false;
            this.deleteContextMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteContextMenuItem.Image")));
            this.deleteContextMenuItem.Name = "deleteContextMenuItem";
            this.deleteContextMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteContextMenuItem.Size = new System.Drawing.Size(202, 22);
            this.deleteContextMenuItem.Text = "Delete";
            this.deleteContextMenuItem.Click += new System.EventHandler(this.deleteContextMenuItem_Click);
            // 
            // undeleteContextMenuItem
            // 
            this.undeleteContextMenuItem.Enabled = false;
            this.undeleteContextMenuItem.Name = "undeleteContextMenuItem";
            this.undeleteContextMenuItem.Size = new System.Drawing.Size(202, 22);
            this.undeleteContextMenuItem.Text = "Undelete";
            this.undeleteContextMenuItem.Click += new System.EventHandler(this.undeleteContextMenuItem_Click);
            // 
            // saveMessageAsContextMenuItem
            // 
            this.saveMessageAsContextMenuItem.Enabled = false;
            this.saveMessageAsContextMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveMessageAsContextMenuItem.Image")));
            this.saveMessageAsContextMenuItem.Name = "saveMessageAsContextMenuItem";
            this.saveMessageAsContextMenuItem.Size = new System.Drawing.Size(202, 22);
            this.saveMessageAsContextMenuItem.Text = "Save Message As...";
            this.saveMessageAsContextMenuItem.Click += new System.EventHandler(this.saveMessageAsContextMenuItem_Click);
            // 
            // copyContextMenuItem
            // 
            this.copyContextMenuItem.Enabled = false;
            this.copyContextMenuItem.Name = "copyContextMenuItem";
            this.copyContextMenuItem.Size = new System.Drawing.Size(202, 22);
            this.copyContextMenuItem.Text = "Copy";
            this.copyContextMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteContextMenuItem
            // 
            this.pasteContextMenuItem.Enabled = false;
            this.pasteContextMenuItem.Name = "pasteContextMenuItem";
            this.pasteContextMenuItem.Size = new System.Drawing.Size(202, 22);
            this.pasteContextMenuItem.Text = "Paste";
            this.pasteContextMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // uploadMessageToolStripMenuItem
            // 
            this.uploadMessageToolStripMenuItem.Enabled = false;
            this.uploadMessageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("uploadMessageToolStripMenuItem.Image")));
            this.uploadMessageToolStripMenuItem.Name = "uploadMessageToolStripMenuItem";
            this.uploadMessageToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.uploadMessageToolStripMenuItem.Text = "Upload Local Message...";
            this.uploadMessageToolStripMenuItem.Click += new System.EventHandler(this.uploadMessageToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 52);
            // 
            // sessionTimeoutTimer
            // 
            this.sessionTimeoutTimer.Tick += new System.EventHandler(this.sessionTimeoutTimer_Tick);
            // 
            // client
            // 
            this.client.CertificateReceived += new ComponentPro.Security.CertificateReceivedEventHandler(this.client_CertificateReceived);
            this.client.CertificateRequired += new ComponentPro.Security.CertificateRequiredEventHandler(this.client_CertificateRequired);
            this.client.Progress += new ComponentPro.Net.Mail.ImapProgressEventHandler(this.client_Progress);
            // 
            // toolbarMain
            // 
            this.toolbarMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolbarMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLogin,
            this.tsbLogout,
            this.tsbRefresh,
            this.toolStripSeparator3,
            this.tsbOpen,
            this.tsbUpload,
            this.tsbSaveAs,
            this.tsbDelete,
            this.tsbPurge,
            this.tsbUndelete,
            this.tsbCopy,
            this.tsbPaste});
            this.toolbarMain.Location = new System.Drawing.Point(0, 0);
            this.toolbarMain.Name = "toolbarMain";
            this.toolbarMain.Size = new System.Drawing.Size(728, 52);
            this.toolbarMain.TabIndex = 137;
            // 
            // ImapClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 469);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolbarMain);
            this.Controls.Add(this.statusStrip);
            this.Name = "ImapClient";
            this.Text = "Ultimate IMAP Client Demo";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.treeViewContextMenuStrip.ResumeLayout(false);
            this.listViewContextMenuStrip.ResumeLayout(false);
            this.toolbarMain.ResumeLayout(false);
            this.toolbarMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripProgressLabel;
        private System.Windows.Forms.ToolStripSplitButton toolStripProgressCancelButton;
        private System.Windows.Forms.ToolStripButton tsbLogin;
        private System.Windows.Forms.ToolStripButton tsbLogout;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbUndelete;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbPurge;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader chFrom;
        private System.Windows.Forms.ColumnHeader chSubject;
        private System.Windows.Forms.ColumnHeader chReceived;
        private ComponentPro.Net.Mail.Imap client;
        private System.Windows.Forms.ToolStripButton tsbSaveAs;
        private System.Windows.Forms.ContextMenuStrip listViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undeleteContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMessageAsContextMenuItem;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ColumnHeader chStatus;
        private System.Windows.Forms.ContextMenuStrip treeViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem newFolderContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteFolderContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameContextMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem pasteMessagesTreeViewContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purgeDeletedMessagesContextMenuItem;
        private System.Windows.Forms.Timer sessionTimeoutTimer;
        private System.Windows.Forms.ToolStripButton copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteContextMenuItem;
        private System.Windows.Forms.ToolStripButton pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.ToolStripButton tsbPaste;
        private System.Windows.Forms.ToolStripMenuItem uploadLocalMessagesContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbUpload;
        private System.Windows.Forms.ColumnHeader chSize;
        private System.Windows.Forms.ToolStrip toolbarMain;
    }
}


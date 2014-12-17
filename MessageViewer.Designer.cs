using System.Drawing;
using System.Windows.Forms;
using Control=System.Windows.Forms.Control;

namespace ImapClient
{
    partial class MessageViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageViewer));
            this.lblAttachment = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.tabBody = new System.Windows.Forms.TabControl();
            this.tabPageText = new System.Windows.Forms.TabPage();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.tabPageHtml = new System.Windows.Forms.TabPage();
            this.txtHtml = new System.Windows.Forms.TextBox();
            this.tabPageHeaders = new System.Windows.Forms.TabPage();
            this.lvwHeaders = new System.Windows.Forms.ListView();
            this.headerName = new System.Windows.Forms.ColumnHeader();
            this.headerValue = new System.Windows.Forms.ColumnHeader();
            this.tabPageRaw = new System.Windows.Forms.TabPage();
            this.txtRawText = new System.Windows.Forms.RichTextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.cbxAttachment = new System.Windows.Forms.ComboBox();
            this.txtCc = new System.Windows.Forms.TextBox();
            this.lblCc = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripButton();
            this.saveAttachmentsToolStripMenuItem = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripButton();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripProgressLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressCancelButton = new System.Windows.Forms.ToolStripSplitButton();
            this.toolbarMain = new System.Windows.Forms.ToolStrip();
            this.tabBody.SuspendLayout();
            this.tabPageText.SuspendLayout();
            this.tabPageHtml.SuspendLayout();
            this.tabPageHeaders.SuspendLayout();
            this.tabPageRaw.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolbarMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAttachment
            // 
            this.lblAttachment.Location = new System.Drawing.Point(6, 148);
            this.lblAttachment.Name = "lblAttachment";
            this.lblAttachment.Size = new System.Drawing.Size(64, 14);
            this.lblAttachment.TabIndex = 107;
            this.lblAttachment.Text = "Attachment:";
            // 
            // txtTo
            // 
            this.txtTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTo.BackColor = System.Drawing.Color.White;
            this.txtTo.Location = new System.Drawing.Point(78, 72);
            this.txtTo.Name = "txtTo";
            this.txtTo.ReadOnly = true;
            this.txtTo.Size = new System.Drawing.Size(548, 20);
            this.txtTo.TabIndex = 2;
            // 
            // tabBody
            // 
            this.tabBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabBody.Controls.Add(this.tabPageText);
            this.tabBody.Controls.Add(this.tabPageHtml);
            this.tabBody.Controls.Add(this.tabPageHeaders);
            this.tabBody.Controls.Add(this.tabPageRaw);
            this.tabBody.Location = new System.Drawing.Point(7, 172);
            this.tabBody.Name = "tabBody";
            this.tabBody.SelectedIndex = 0;
            this.tabBody.Size = new System.Drawing.Size(619, 351);
            this.tabBody.TabIndex = 132;
            // 
            // tabPageText
            // 
            this.tabPageText.Controls.Add(this.txtBody);
            this.tabPageText.Location = new System.Drawing.Point(4, 22);
            this.tabPageText.Name = "tabPageText";
            this.tabPageText.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageText.Size = new System.Drawing.Size(611, 325);
            this.tabPageText.TabIndex = 0;
            this.tabPageText.Text = "Plain Text";
            // 
            // txtBody
            // 
            this.txtBody.BackColor = System.Drawing.Color.White;
            this.txtBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBody.Location = new System.Drawing.Point(3, 3);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.ReadOnly = true;
            this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBody.Size = new System.Drawing.Size(605, 319);
            this.txtBody.TabIndex = 9;
            // 
            // tabPageHtml
            // 
            this.tabPageHtml.Controls.Add(this.txtHtml);
            this.tabPageHtml.Location = new System.Drawing.Point(4, 22);
            this.tabPageHtml.Name = "tabPageHtml";
            this.tabPageHtml.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHtml.Size = new System.Drawing.Size(611, 325);
            this.tabPageHtml.TabIndex = 1;
            this.tabPageHtml.Text = "HTML";
            // 
            // txtHtml
            // 
            this.txtHtml.BackColor = System.Drawing.Color.White;
            this.txtHtml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHtml.Location = new System.Drawing.Point(3, 3);
            this.txtHtml.Multiline = true;
            this.txtHtml.Name = "txtHtml";
            this.txtHtml.ReadOnly = true;
            this.txtHtml.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtHtml.Size = new System.Drawing.Size(605, 319);
            this.txtHtml.TabIndex = 10;
            // 
            // tabPageHeaders
            // 
            this.tabPageHeaders.Controls.Add(this.lvwHeaders);
            this.tabPageHeaders.Location = new System.Drawing.Point(4, 22);
            this.tabPageHeaders.Name = "tabPageHeaders";
            this.tabPageHeaders.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHeaders.Size = new System.Drawing.Size(611, 325);
            this.tabPageHeaders.TabIndex = 2;
            this.tabPageHeaders.Text = "Headers";
            // 
            // lvwHeaders
            // 
            this.lvwHeaders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headerName,
            this.headerValue});
            this.lvwHeaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwHeaders.FullRowSelect = true;
            this.lvwHeaders.GridLines = true;
            this.lvwHeaders.Location = new System.Drawing.Point(3, 3);
            this.lvwHeaders.Name = "lvwHeaders";
            this.lvwHeaders.Size = new System.Drawing.Size(605, 319);
            this.lvwHeaders.TabIndex = 1;
            this.lvwHeaders.UseCompatibleStateImageBehavior = false;
            this.lvwHeaders.View = System.Windows.Forms.View.Details;
            // 
            // headerName
            // 
            this.headerName.Text = "Name";
            this.headerName.Width = 200;
            // 
            // headerValue
            // 
            this.headerValue.Text = "Value";
            this.headerValue.Width = 400;
            // 
            // tabPageRaw
            // 
            this.tabPageRaw.Controls.Add(this.txtRawText);
            this.tabPageRaw.Location = new System.Drawing.Point(4, 22);
            this.tabPageRaw.Name = "tabPageRaw";
            this.tabPageRaw.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRaw.Size = new System.Drawing.Size(611, 325);
            this.tabPageRaw.TabIndex = 3;
            this.tabPageRaw.Text = "Raw Message";
            // 
            // txtRawText
            // 
            this.txtRawText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRawText.Location = new System.Drawing.Point(3, 3);
            this.txtRawText.Name = "txtRawText";
            this.txtRawText.ReadOnly = true;
            this.txtRawText.Size = new System.Drawing.Size(605, 319);
            this.txtRawText.TabIndex = 1;
            this.txtRawText.Text = "";
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.BackColor = System.Drawing.Color.White;
            this.txtSubject.Location = new System.Drawing.Point(78, 120);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.ReadOnly = true;
            this.txtSubject.Size = new System.Drawing.Size(548, 20);
            this.txtSubject.TabIndex = 5;
            // 
            // lblSubject
            // 
            this.lblSubject.Location = new System.Drawing.Point(6, 124);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(62, 14);
            this.lblSubject.TabIndex = 125;
            this.lblSubject.Text = "Subject:";
            // 
            // cbxAttachment
            // 
            this.cbxAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxAttachment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAttachment.FormattingEnabled = true;
            this.cbxAttachment.Location = new System.Drawing.Point(78, 144);
            this.cbxAttachment.Name = "cbxAttachment";
            this.cbxAttachment.Size = new System.Drawing.Size(548, 21);
            this.cbxAttachment.TabIndex = 6;
            // 
            // txtCc
            // 
            this.txtCc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCc.BackColor = System.Drawing.Color.White;
            this.txtCc.Location = new System.Drawing.Point(78, 96);
            this.txtCc.Name = "txtCc";
            this.txtCc.ReadOnly = true;
            this.txtCc.Size = new System.Drawing.Size(548, 20);
            this.txtCc.TabIndex = 3;
            // 
            // lblCc
            // 
            this.lblCc.Location = new System.Drawing.Point(6, 100);
            this.lblCc.Name = "lblCc";
            this.lblCc.Size = new System.Drawing.Size(62, 14);
            this.lblCc.TabIndex = 117;
            this.lblCc.Text = "Cc:";
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(6, 75);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(62, 14);
            this.lblTo.TabIndex = 103;
            this.lblTo.Text = "To:";
            // 
            // txtFrom
            // 
            this.txtFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFrom.BackColor = System.Drawing.Color.White;
            this.txtFrom.Location = new System.Drawing.Point(78, 48);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.ReadOnly = true;
            this.txtFrom.Size = new System.Drawing.Size(548, 20);
            this.txtFrom.TabIndex = 1;
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(6, 52);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(64, 14);
            this.lblFrom.TabIndex = 102;
            this.lblFrom.Text = "From:";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem.Image")));
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(81, 36);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // saveAttachmentsToolStripMenuItem
            // 
            this.saveAttachmentsToolStripMenuItem.Enabled = false;
            this.saveAttachmentsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAttachmentsToolStripMenuItem.Image")));
            this.saveAttachmentsToolStripMenuItem.Name = "saveAttachmentsToolStripMenuItem";
            this.saveAttachmentsToolStripMenuItem.Size = new System.Drawing.Size(131, 36);
            this.saveAttachmentsToolStripMenuItem.Text = "Save Attachments";
            this.saveAttachmentsToolStripMenuItem.Click += new System.EventHandler(this.saveAttachmentsToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Enabled = false;
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(68, 36);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Enabled = false;
            this.selectAllToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("selectAllToolStripMenuItem.Image")));
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(86, 36);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar,
            this.toolStripProgressLabel,
            this.toolStripProgressCancelButton});
            this.statusStrip.Location = new System.Drawing.Point(0, 529);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(633, 22);
            this.statusStrip.TabIndex = 131;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel.Text = "Ready";
            this.toolStripStatusLabel.Visible = false;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(200, 16);
            // 
            // toolStripProgressLabel
            // 
            this.toolStripProgressLabel.Name = "toolStripProgressLabel";
            this.toolStripProgressLabel.Size = new System.Drawing.Size(104, 17);
            this.toolStripProgressLabel.Text = "0 bytes downloaded";
            // 
            // toolStripProgressCancelButton
            // 
            this.toolStripProgressCancelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripProgressCancelButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripProgressCancelButton.Image")));
            this.toolStripProgressCancelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripProgressCancelButton.Name = "toolStripProgressCancelButton";
            this.toolStripProgressCancelButton.Size = new System.Drawing.Size(32, 20);
            this.toolStripProgressCancelButton.Text = "Cancel Downloading";
            this.toolStripProgressCancelButton.ButtonClick += new System.EventHandler(this.toolStripProgressCancelButton_ButtonClick);
            // 
            // toolbarMain
            // 
            this.toolbarMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolbarMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem,
            this.saveAttachmentsToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.selectAllToolStripMenuItem});
            this.toolbarMain.Location = new System.Drawing.Point(0, 0);
            this.toolbarMain.Name = "toolbarMain";
            this.toolbarMain.Size = new System.Drawing.Size(633, 39);
            this.toolbarMain.TabIndex = 118;
            // 
            // MessageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 551);
            this.Controls.Add(this.tabBody);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.cbxAttachment);
            this.Controls.Add(this.txtCc);
            this.Controls.Add(this.lblCc);
            this.Controls.Add(this.lblAttachment);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.toolbarMain);
            this.Controls.Add(this.statusStrip);
            this.MinimumSize = new System.Drawing.Size(357, 289);
            this.Name = "MessageViewer";
            this.Text = "Message Viewer";
            this.tabBody.ResumeLayout(false);
            this.tabPageText.ResumeLayout(false);
            this.tabPageText.PerformLayout();
            this.tabPageHtml.ResumeLayout(false);
            this.tabPageHtml.PerformLayout();
            this.tabPageHeaders.ResumeLayout(false);
            this.tabPageRaw.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolbarMain.ResumeLayout(false);
            this.toolbarMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAttachment;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.TextBox txtCc;
        private System.Windows.Forms.Label lblCc;
        private System.Windows.Forms.ComboBox cbxAttachment;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.ToolStripButton saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton saveAttachmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton selectAllToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripProgressLabel;
        private System.Windows.Forms.ToolStripSplitButton toolStripProgressCancelButton;
        private System.Windows.Forms.TabControl tabBody;
        private System.Windows.Forms.TabPage tabPageText;
        private System.Windows.Forms.TabPage tabPageHtml;
        private System.Windows.Forms.TextBox txtHtml;
        private System.Windows.Forms.TabPage tabPageHeaders;
        private System.Windows.Forms.ListView lvwHeaders;
        private System.Windows.Forms.ColumnHeader headerName;
        private System.Windows.Forms.ColumnHeader headerValue;
        private System.Windows.Forms.TabPage tabPageRaw;
        private System.Windows.Forms.RichTextBox txtRawText;
        private ToolStrip toolbarMain;
    }
}


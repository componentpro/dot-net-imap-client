namespace ImapClient
{
    partial class Login
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
            this.txtCertificate = new System.Windows.Forms.TextBox();
            this.btnCertBrowse = new System.Windows.Forms.Button();
            this.lblSec = new System.Windows.Forms.Label();
            this.cbxSec = new System.Windows.Forms.ComboBox();
            this.lblCert = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grbSmtp = new System.Windows.Forms.GroupBox();
            this.cbxMethod = new System.Windows.Forms.ComboBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.grbProxy = new System.Windows.Forms.GroupBox();
            this.txtProxyDomain = new System.Windows.Forms.TextBox();
            this.lblDomain = new System.Windows.Forms.Label();
            this.lblMethod = new System.Windows.Forms.Label();
            this.cbxProxyMethod = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.txtProxyPort = new System.Windows.Forms.TextBox();
            this.lblProxyPort = new System.Windows.Forms.Label();
            this.txtProxyHost = new System.Windows.Forms.TextBox();
            this.lblProxyServer = new System.Windows.Forms.Label();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.txtProxyPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProxyUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grbSmtp.SuspendLayout();
            this.grbProxy.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCertificate
            // 
            this.txtCertificate.Location = new System.Drawing.Point(268, 62);
            this.txtCertificate.Name = "txtCertificate";
            this.txtCertificate.Size = new System.Drawing.Size(144, 21);
            this.txtCertificate.TabIndex = 7;
            // 
            // btnCertBrowse
            // 
            this.btnCertBrowse.Location = new System.Drawing.Point(415, 62);
            this.btnCertBrowse.Name = "btnCertBrowse";
            this.btnCertBrowse.Size = new System.Drawing.Size(26, 20);
            this.btnCertBrowse.TabIndex = 8;
            this.btnCertBrowse.Text = "...";
            this.btnCertBrowse.Click += new System.EventHandler(this.btnCertBrowse_Click);
            // 
            // lblSec
            // 
            this.lblSec.Location = new System.Drawing.Point(298, 17);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(50, 14);
            this.lblSec.TabIndex = 14;
            this.lblSec.Text = "Security:";
            // 
            // cbxSec
            // 
            this.cbxSec.DrawMode = System.Windows.Forms.DrawMode.Normal;
            this.cbxSec.DroppedDown = false;
            this.cbxSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSec.FormatInfo = null;
            this.cbxSec.FormatString = "";
            this.cbxSec.FormattingEnabled = true;
            this.cbxSec.Location = new System.Drawing.Point(349, 14);
            this.cbxSec.Name = "cbxSec";
            this.cbxSec.Size = new System.Drawing.Size(92, 21);
            this.cbxSec.Sorted = false;
            this.cbxSec.TabIndex = 3;
            // 
            // lblCert
            // 
            this.lblCert.Location = new System.Drawing.Point(210, 64);
            this.lblCert.Name = "lblCert";
            this.lblCert.Size = new System.Drawing.Size(68, 18);
            this.lblCert.TabIndex = 9;
            this.lblCert.Text = "Certificate:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(306, 245);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 100;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(384, 245);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 101;
            this.btnCancel.Text = "Cancel";
            // 
            // grbSmtp
            // 
            this.grbSmtp.Controls.Add(this.txtCertificate);
            this.grbSmtp.Controls.Add(this.btnCertBrowse);
            this.grbSmtp.Controls.Add(this.cbxMethod);
            this.grbSmtp.Controls.Add(this.txtUserName);
            this.grbSmtp.Controls.Add(this.txtTimeout);
            this.grbSmtp.Controls.Add(this.lblTimeout);
            this.grbSmtp.Controls.Add(this.lblCert);
            this.grbSmtp.Controls.Add(this.cbxSec);
            this.grbSmtp.Controls.Add(this.lblSec);
            this.grbSmtp.Controls.Add(this.txtPassword);
            this.grbSmtp.Controls.Add(this.lblPassword);
            this.grbSmtp.Controls.Add(this.lblUserName);
            this.grbSmtp.Controls.Add(this.txtPort);
            this.grbSmtp.Controls.Add(this.lblPort);
            this.grbSmtp.Controls.Add(this.txtServer);
            this.grbSmtp.Controls.Add(this.lblServer);
            this.grbSmtp.Location = new System.Drawing.Point(8, 2);
            this.grbSmtp.Name = "grbSmtp";
            this.grbSmtp.Size = new System.Drawing.Size(451, 116);
            this.grbSmtp.TabIndex = 0;
            this.grbSmtp.TabStop = false;
            this.grbSmtp.Text = "Imap";
            // 
            // cbxMethod
            // 
            this.cbxMethod.DrawMode = System.Windows.Forms.DrawMode.Normal;
            this.cbxMethod.DroppedDown = false;
            this.cbxMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMethod.FormatInfo = null;
            this.cbxMethod.FormatString = "";
            this.cbxMethod.FormattingEnabled = true;
            this.cbxMethod.Location = new System.Drawing.Point(210, 38);
            this.cbxMethod.Name = "cbxMethod";
            this.cbxMethod.Size = new System.Drawing.Size(110, 21);
            this.cbxMethod.Sorted = false;
            this.cbxMethod.TabIndex = 6;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(76, 38);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(126, 21);
            this.txtUserName.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(76, 62);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(126, 21);
            this.txtPassword.TabIndex = 5;
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(8, 64);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 23;
            this.lblPassword.Text = "Password:";
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(8, 40);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(63, 13);
            this.lblUserName.TabIndex = 22;
            this.lblUserName.Text = "User Name:";
            // 
            // txtTimeout
            // 
            this.txtTimeout.Location = new System.Drawing.Point(76, 86);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(66, 21);
            this.txtTimeout.TabIndex = 9;
            this.txtTimeout.Text = "60000";
            // 
            // lblTimeout
            // 
            this.lblTimeout.Location = new System.Drawing.Point(8, 88);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(72, 18);
            this.lblTimeout.TabIndex = 21;
            this.lblTimeout.Text = "Timeout(ms):";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(246, 14);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(46, 21);
            this.txtPort.TabIndex = 2;
            this.txtPort.Text = "143";
            // 
            // lblPort
            // 
            this.lblPort.Location = new System.Drawing.Point(210, 18);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(35, 13);
            this.lblPort.TabIndex = 19;
            this.lblPort.Text = "Port:";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(76, 14);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(126, 21);
            this.txtServer.TabIndex = 1;
            // 
            // lblServer
            // 
            this.lblServer.Location = new System.Drawing.Point(8, 16);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(82, 18);
            this.lblServer.TabIndex = 18;
            this.lblServer.Text = "Imap Server:";
            // 
            // grbProxy
            // 
            this.grbProxy.Controls.Add(this.txtProxyDomain);
            this.grbProxy.Controls.Add(this.lblDomain);
            this.grbProxy.Controls.Add(this.lblMethod);
            this.grbProxy.Controls.Add(this.cbxProxyMethod);
            this.grbProxy.Controls.Add(this.lblType);
            this.grbProxy.Controls.Add(this.txtProxyPort);
            this.grbProxy.Controls.Add(this.lblProxyPort);
            this.grbProxy.Controls.Add(this.txtProxyHost);
            this.grbProxy.Controls.Add(this.lblProxyServer);
            this.grbProxy.Controls.Add(this.cbxType);
            this.grbProxy.Controls.Add(this.txtProxyPassword);
            this.grbProxy.Controls.Add(this.label1);
            this.grbProxy.Controls.Add(this.txtProxyUserName);
            this.grbProxy.Controls.Add(this.label2);
            this.grbProxy.Location = new System.Drawing.Point(8, 122);
            this.grbProxy.Name = "grbProxy";
            this.grbProxy.Size = new System.Drawing.Size(451, 118);
            this.grbProxy.TabIndex = 40;
            this.grbProxy.TabStop = false;
            this.grbProxy.Text = "Proxy Settings";
            // 
            // txtProxyDomain
            // 
            this.txtProxyDomain.Location = new System.Drawing.Point(76, 88);
            this.txtProxyDomain.Name = "txtProxyDomain";
            this.txtProxyDomain.Size = new System.Drawing.Size(126, 21);
            this.txtProxyDomain.TabIndex = 49;
            // 
            // lblDomain
            // 
            this.lblDomain.Location = new System.Drawing.Point(8, 90);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(68, 18);
            this.lblDomain.TabIndex = 48;
            this.lblDomain.Text = "Domain:";
            // 
            // lblMethod
            // 
            this.lblMethod.Location = new System.Drawing.Point(211, 66);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(68, 18);
            this.lblMethod.TabIndex = 17;
            this.lblMethod.Text = "Method:";
            // 
            // cbxProxyMethod
            // 
            this.cbxProxyMethod.DrawMode = System.Windows.Forms.DrawMode.Normal;
            this.cbxProxyMethod.DroppedDown = false;
            this.cbxProxyMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProxyMethod.FormatInfo = null;
            this.cbxProxyMethod.FormatString = "";
            this.cbxProxyMethod.FormattingEnabled = true;
            this.cbxProxyMethod.Items.AddRange(new object[] {
            "Basic",
            "Ntlm"});
            this.cbxProxyMethod.Location = new System.Drawing.Point(285, 65);
            this.cbxProxyMethod.Name = "cbxProxyMethod";
            this.cbxProxyMethod.Size = new System.Drawing.Size(127, 21);
            this.cbxProxyMethod.Sorted = false;
            this.cbxProxyMethod.TabIndex = 47;
            this.cbxProxyMethod.SelectedIndexChanged += new System.EventHandler(this.cbx_SelectedIndexChanged);
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(211, 42);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(68, 18);
            this.lblType.TabIndex = 16;
            this.lblType.Text = "Proxy Type:";
            // 
            // txtProxyPort
            // 
            this.txtProxyPort.Location = new System.Drawing.Point(285, 16);
            this.txtProxyPort.Name = "txtProxyPort";
            this.txtProxyPort.Size = new System.Drawing.Size(127, 21);
            this.txtProxyPort.TabIndex = 42;
            // 
            // lblProxyPort
            // 
            this.lblProxyPort.Location = new System.Drawing.Point(211, 18);
            this.lblProxyPort.Name = "lblProxyPort";
            this.lblProxyPort.Size = new System.Drawing.Size(68, 18);
            this.lblProxyPort.TabIndex = 15;
            this.lblProxyPort.Text = "Proxy Port:";
            // 
            // txtProxyHost
            // 
            this.txtProxyHost.Location = new System.Drawing.Point(76, 16);
            this.txtProxyHost.Name = "txtProxyHost";
            this.txtProxyHost.Size = new System.Drawing.Size(126, 21);
            this.txtProxyHost.TabIndex = 41;
            // 
            // lblProxyServer
            // 
            this.lblProxyServer.Location = new System.Drawing.Point(8, 18);
            this.lblProxyServer.Name = "lblProxyServer";
            this.lblProxyServer.Size = new System.Drawing.Size(82, 18);
            this.lblProxyServer.TabIndex = 14;
            this.lblProxyServer.Text = "Proxy Server:";
            // 
            // cbxType
            // 
            this.cbxType.DrawMode = System.Windows.Forms.DrawMode.Normal;
            this.cbxType.DroppedDown = false;
            this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxType.FormatInfo = null;
            this.cbxType.FormatString = "";
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Items.AddRange(new object[] {
            "Never",
            "Socks4",
            "Socks4A",
            "Socks5",
            "HttpConnect"});
            this.cbxType.Location = new System.Drawing.Point(285, 40);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(127, 21);
            this.cbxType.Sorted = false;
            this.cbxType.TabIndex = 46;
            this.cbxType.SelectedIndexChanged += new System.EventHandler(this.cbx_SelectedIndexChanged);
            // 
            // txtProxyPassword
            // 
            this.txtProxyPassword.Location = new System.Drawing.Point(76, 64);
            this.txtProxyPassword.Name = "txtProxyPassword";
            this.txtProxyPassword.PasswordChar = '*';
            this.txtProxyPassword.Size = new System.Drawing.Size(126, 21);
            this.txtProxyPassword.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Password:";
            // 
            // txtProxyUserName
            // 
            this.txtProxyUserName.Location = new System.Drawing.Point(76, 40);
            this.txtProxyUserName.Name = "txtProxyUserName";
            this.txtProxyUserName.Size = new System.Drawing.Size(126, 21);
            this.txtProxyUserName.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "User Name:";
            // 
            // Login
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(466, 277);
            this.Controls.Add(this.grbProxy);
            this.Controls.Add(this.grbSmtp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect";
            this.grbSmtp.ResumeLayout(false);
            this.grbSmtp.PerformLayout();
            this.grbProxy.ResumeLayout(false);
            this.grbProxy.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.ComboBox cbxSec;
        private System.Windows.Forms.Label lblCert;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grbSmtp;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TextBox txtTimeout;
        private System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.ComboBox cbxMethod;
        private System.Windows.Forms.GroupBox grbProxy;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.ComboBox cbxProxyMethod;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtProxyPort;
        private System.Windows.Forms.Label lblProxyPort;
        private System.Windows.Forms.TextBox txtProxyHost;
        private System.Windows.Forms.Label lblProxyServer;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.TextBox txtProxyPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProxyUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCertificate;
        private System.Windows.Forms.Button btnCertBrowse;
        private System.Windows.Forms.TextBox txtProxyDomain;
        private System.Windows.Forms.Label lblDomain;
    }
}
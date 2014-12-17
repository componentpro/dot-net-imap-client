using System;
using System.Windows.Forms;
using ComponentPro.Net;
using ComponentPro.Net.Mail;

namespace ImapClient
{
    public partial class Login : Form
    {
        readonly LoginInfo _info;

        public Login()
        {
            InitializeComponent();

            Util.PopulateEnum(typeof(SecurityMode), cbxSec);
            Util.PopulateEnum(typeof(ImapAuthenticationMethod), cbxMethod);
        }

        public Login(LoginInfo info)
            : this()
        {
            _info = info;

            txtCertificate.Text = info.Cert;

            cbxSec.SelectedItem = info.SecurityMode;

            if (info.Timeout >= 1000)
                txtTimeout.Text = info.Timeout.ToString();

            txtServer.Text = info.Server;
            if (info.Port > 0)
                txtPort.Text = info.Port.ToString();
            txtUserName.Text = info.UserName;
            txtPassword.Text = info.Password;

            cbxMethod.SelectedItem = info.Method;

            txtProxyUserName.Text = info.ProxyUserName;
            txtProxyPassword.Text = info.ProxyPassword;
            txtProxyDomain.Text = info.ProxyDomain;
            txtProxyHost.Text = info.ProxyServer;
            if (info.ProxyPort > 0)
                txtProxyPort.Text = info.ProxyPort.ToString();
            cbxProxyMethod.SelectedIndex = (int)info.ProxyAuthenticationMethod;
            cbxType.SelectedIndex = (int)info.ProxyType;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            _info.SecurityMode = (SecurityMode)cbxSec.SelectedItem;

            if (string.IsNullOrEmpty(txtServer.Text))
            {
                MessageBox.Show("Please enter server name", "Error");
                return;
            }

            _info.Server = txtServer.Text;            

            try
            {
                _info.Timeout = int.Parse(txtTimeout.Text);
            }
            catch (FormatException)
            {
                _info.Timeout = 60000;
                MessageBox.Show("Invalid timeout", "Error");
                return;
            }

            try
            {
                int port = int.Parse(txtPort.Text);
                if (port < 1 || port > 65535)
                {
                    MessageBox.Show("Invalid port, port must be from 1->65535", "Error");
                    return;
                }
                _info.Port = port;
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid port, port must be from 1->65535", "Error");
                return;
            }

            if (txtProxyPort.Text.Length > 0)
                try
                {
                    int port;
                    port = int.Parse(txtProxyPort.Text);
                    if (port < 1 || port > 65535)
                    {
                        MessageBox.Show("Invalid port number, must be between 1 and 65535");
                        return;
                    }
                    _info.ProxyPort = port;
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Invalid port: " + exc.Message);
                    return;
                }

            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Please enter user name");
                return;
            }            

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter password");
                return;
            }

            _info.UserName = txtUserName.Text;
            _info.Password = txtPassword.Text;

            _info.Method = (ImapAuthenticationMethod)cbxMethod.SelectedItem;
            _info.Cert = txtCertificate.Text;

            _info.ProxyServer = txtProxyHost.Text;
            _info.ProxyType = (ProxyType)cbxType.SelectedIndex;
            _info.ProxyAuthenticationMethod = (ProxyHttpConnectAuthMethod)cbxProxyMethod.SelectedIndex;
            _info.ProxyUserName = txtProxyUserName.Text;
            _info.ProxyPassword = txtProxyPassword.Text;
            _info.ProxyDomain = txtProxyDomain.Text;

            this.DialogResult = DialogResult.OK;
        }        

        private void btnCertBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select a certificate file";
            dlg.FileName = txtCertificate.Text;
            dlg.Filter = "All files|*.*";
            dlg.FilterIndex = 1;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtCertificate.Text = dlg.FileName;
            }
        }

        /// <summary>
        /// Handles the combo box proxy type's SelectedIndexChanged event.
        /// </summary>
        /// <param name="sender">The combo box.</param>
        /// <param name="e">The event arguments.</param>
        private void cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool enable = cbxType.SelectedIndex > 0;

            cbxProxyMethod.Enabled = cbxType.SelectedIndex == (int)ProxyType.HttpConnect; // Authentication method is available for HTTP Connect only.
            txtProxyDomain.Enabled = cbxProxyMethod.Enabled && cbxProxyMethod.SelectedIndex == (int)ProxyHttpConnectAuthMethod.Ntlm; // Domain is available for NTLM authentication method only.
            txtProxyUserName.Enabled = enable/* && cbxType.SelectedIndex != (int)ProxyType.SendToProxy*/; // User name and password are ignored with SendToProxy proxy type.
            txtProxyPassword.Enabled = enable/* && cbxType.SelectedIndex != (int)ProxyType.SendToProxy*/;
            txtProxyHost.Enabled = enable; // Proxy host and port are not available in NoProxy type.
            txtProxyPort.Enabled = enable;
        }
    }
}
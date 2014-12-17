using System;
using System.Windows.Forms;

namespace ImapClient
{
    public partial class PasswordPrompt : Form
    {
        public PasswordPrompt()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the entered password.
        /// </summary>
        public string Password
        {
            get
            {
                return txtPassword.Text;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
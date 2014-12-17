using ComponentPro.Net.Mail;
using ComponentPro.Net;

namespace ImapClient
{
    public class LoginInfo
    {
        private SecurityMode _sec;
        private string _cert;
        private bool _tls;
        private bool _ssl;
        private int _suites;
        
        private string _server;
        private int _port;
        private string _userName;
        private string _password;
        private ImapAuthenticationMethod _method;
        private int _timeout;

        #region Proxy

        private string _proxyServer;
        private string _proxyUserName;
        private string _proxyPassword;
        private string _proxyDomain;
        private int _proxyPort;
        private ProxyHttpConnectAuthMethod _proxyAuthenticationMethod;
        private ProxyType _proxyType;

        #endregion

        #region Download Options

        //private ImapMessageListOption _downloadOption = ImapMessageListOption.Envelope;

        #endregion

        public SecurityMode SecurityMode
        {
            get { return _sec; }
            set { _sec = value; }
        }

        public string Cert
        {
            get { return _cert; }
            set { _cert = value; }
        }

        public bool Tls
        {
            get { return _tls; }
            set { _tls = value; }
        }

        public bool Ssl
        {
            get { return _ssl; }
            set { _ssl = value; }
        }

        public int Suites
        {
            get { return _suites; }
            set { _suites = value; }
        }


        public string Server
        {
            get { return _server; }
            set { _server = value; }
        }

        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public ImapAuthenticationMethod Method
        {
            get { return _method; }
            set { _method = value; }
        }

        public int Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }


        #region Proxy

        public string ProxyServer
        {
            get { return _proxyServer; }
            set { _proxyServer = value; }
        }

        public string ProxyUserName
        {
            get { return _proxyUserName; }
            set { _proxyUserName = value; }
        }

        public string ProxyPassword
        {
            get { return _proxyPassword; }
            set { _proxyPassword = value; }
        }

        public string ProxyDomain
        {
            get { return _proxyDomain; }
            set { _proxyDomain = value; }
        }

        public int ProxyPort
        {
            get { return _proxyPort; }
            set { _proxyPort = value; }
        }

        public ProxyHttpConnectAuthMethod ProxyAuthenticationMethod
        {
            get { return _proxyAuthenticationMethod; }
            set { _proxyAuthenticationMethod = value; }
        }

        public ProxyType ProxyType
        {
            get { return _proxyType; }
            set { _proxyType = value; }
        }

        #endregion

        #region Static Methods

        public static LoginInfo LoadConfig()
        {
            // Load Login Information.
            LoginInfo s = new LoginInfo();

            s._sec = (SecurityMode)Util.GetIntProperty("Security", 0);
            s._cert = (string)Util.GetProperty("Cert", string.Empty);
            s._tls = (string)Util.GetProperty("Tls", "True") == "True";
            s._ssl = (string)Util.GetProperty("Ssl", "True") == "True";
            s._suites = Util.GetIntProperty("Suites", 0);

            s._server = (string)Util.GetProperty("Server", string.Empty);
            s._port = Util.GetIntProperty("Port", 143);
            s._userName = (string)Util.GetProperty("UserName", string.Empty);
            s._password = (string)Util.GetProperty("Password", string.Empty);
            s._method = (ImapAuthenticationMethod)Util.GetIntProperty("Method", 0);
            s._timeout = Util.GetIntProperty("Timeout", 60000);

            #region Proxy

            s._proxyServer = (string)Util.GetProperty("ProxyServer", string.Empty);
            s._proxyUserName = (string)Util.GetProperty("ProxyUserName", string.Empty);
            s._proxyPassword = (string)Util.GetProperty("ProxyPassword", string.Empty);
            s._proxyDomain = (string)Util.GetProperty("ProxyDomain", string.Empty);
            s._proxyPort = Util.GetIntProperty("ProxyPort", 1080);
            s._proxyAuthenticationMethod = (ProxyHttpConnectAuthMethod)Util.GetIntProperty("ProxyAuthenticationMethod", 0);
            s._proxyType = (ProxyType)Util.GetIntProperty("ProxyType", 0);

            #endregion

            return s;
        }

        public void SaveConfig()
        {
            Util.SaveProperty("Security", (int)_sec);
            Util.SaveProperty("Cert", _cert);
            Util.SaveProperty("Tls", _tls);
            Util.SaveProperty("Ssl", _ssl);
            Util.SaveProperty("Suites", _suites);

            Util.SaveProperty("Server", _server);
            Util.SaveProperty("Port", _port);
            Util.SaveProperty("UserName", _userName);
            Util.SaveProperty("Password", _password);
            Util.SaveProperty("Method", _method);
            Util.SaveProperty("Timeout", _timeout);

            #region Proxy

            Util.SaveProperty("ProxyServer", _proxyServer);
            Util.SaveProperty("ProxyUserName", _proxyUserName);
            Util.SaveProperty("ProxyPassword", _proxyPassword);
            Util.SaveProperty("ProxyDomain", _proxyDomain);
            Util.SaveProperty("ProxyPort", _proxyPort);
            Util.SaveProperty("ProxyAuthenticationMethod", (int)_proxyAuthenticationMethod);
            Util.SaveProperty("ProxyType", (int)_proxyType);

            #endregion
        }

        #endregion
    }
}
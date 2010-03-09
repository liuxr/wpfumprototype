using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using SystemsUnion.Security.Client;
using SystemsUnion.Security.Common;
using AxSHDocVw;
using Microsoft.Win32;
using SHDocVw;
using System.Runtime.InteropServices;
using MsHtmHstInterop;
using IDataObject=MsHtmHstInterop.IDataObject;
using IDropTarget=MsHtmHstInterop.IDropTarget;
using DocumentCompleteEventHandler = AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEventHandler;
using DWebBrowserEvents2_BeforeNavigate2EventHandler = AxSHDocVw.DWebBrowserEvents2_BeforeNavigate2EventHandler;
using DWebBrowserEvents2_NewWindow3EventHandler = AxSHDocVw.DWebBrowserEvents2_NewWindow3EventHandler;
using StatusTextChangeEventHandler = AxSHDocVw.DWebBrowserEvents2_StatusTextChangeEventHandler;


namespace WebBrowserCtrl {
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public partial class Form1 : System.Windows.Forms.Form {
        private UCOMIConnectionPoint icp;
        private int cookie = -1;
        private ISecurityService _securitySerivce = null;
        private User _user;
        
        private AxSHDocVw.AxWebBrowser _webBrowser;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Form1() {
            InitializeComponent();
       
            object flags = 0;
            object targetFrame = String.Empty;
            object postData = String.Empty;
            object headers = "Content-Type: application/x-www-form-urlencoded\r\nAccept-Language: de-DE";
            this._webBrowser.Navigate("about:blank", ref flags, ref targetFrame, ref postData, ref headers);
        }
     
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support; do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._webBrowser = new AxSHDocVw.AxWebBrowser();
            this._txbUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._btnGo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._txbUserName = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this._authenticate = new System.Windows.Forms.Button();
            this._txbLanguage = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._webBrowser)).BeginInit();
            this.SuspendLayout();
            // 
            // _webBrowser
            // 
            this._webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._webBrowser.Enabled = true;
            this._webBrowser.Location = new System.Drawing.Point(12, 165);
            this._webBrowser.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_webBrowser.OcxState")));
            this._webBrowser.Size = new System.Drawing.Size(529, 263);
            this._webBrowser.TabIndex = 0;
            // 
            // _txbUrl
            // 
            this._txbUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._txbUrl.Location = new System.Drawing.Point(74, 126);
            this._txbUrl.Name = "_txbUrl";
            this._txbUrl.Size = new System.Drawing.Size(368, 20);
            this._txbUrl.TabIndex = 1;
            this._txbUrl.Text = "http://www.google.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL:";
            // 
            // _btnGo
            // 
            this._btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnGo.Enabled = false;
            this._btnGo.Location = new System.Drawing.Point(458, 124);
            this._btnGo.Name = "_btnGo";
            this._btnGo.Size = new System.Drawing.Size(75, 23);
            this._btnGo.TabIndex = 3;
            this._btnGo.Text = "Go";
            this._btnGo.UseVisualStyleBackColor = true;
            this._btnGo.Click += new System.EventHandler(this._btnGo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Preferred Language";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "User Name:";
            // 
            // _txbUserName
            // 
            this._txbUserName.Enabled = false;
            this._txbUserName.Location = new System.Drawing.Point(78, 30);
            this._txbUserName.Name = "_txbUserName";
            this._txbUserName.Size = new System.Drawing.Size(144, 20);
            this._txbUserName.TabIndex = 7;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(367, 434);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(166, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Show HTTP Request Header";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // _authenticate
            // 
            this._authenticate.Location = new System.Drawing.Point(78, 66);
            this._authenticate.Name = "_authenticate";
            this._authenticate.Size = new System.Drawing.Size(75, 23);
            this._authenticate.TabIndex = 9;
            this._authenticate.Text = "ChangeUser";
            this._authenticate.UseVisualStyleBackColor = true;
            this._authenticate.Click += new System.EventHandler(this._authenticate_Click);
            // 
            // _txbLanguage
            // 
            this._txbLanguage.Enabled = false;
            this._txbLanguage.Location = new System.Drawing.Point(370, 32);
            this._txbLanguage.Name = "_txbLanguage";
            this._txbLanguage.Size = new System.Drawing.Size(163, 20);
            this._txbLanguage.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(553, 463);
            this.Controls.Add(this._txbLanguage);
            this.Controls.Add(this._authenticate);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this._txbUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._btnGo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._txbUrl);
            this.Controls.Add(this._webBrowser);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this._webBrowser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.Run(new Form1());
        }

        private void Form1_Load(object sender, System.EventArgs e) {
            _securitySerivce = ClientSecurityServiceFactory.CreateClientService(); 
            
            //object nullObj = null;
            //object urlObj = "http://www.cs.tut.fi/cgi-bin/run/~jkorpela/lang.cgi";
            //string postDataStr = "key=value";
            //byte[] postData = Encoding.UTF8.GetBytes(postDataStr);
            //object postDataObj = postData;
            //string headersStr = "Accept-Language: de-DE\r\n";
            //object headers = headersStr;
            //_webBrowser.Navigate2(ref urlObj, ref nullObj, ref nullObj, ref nullObj, ref headers);
        }


        private void _authenticate_Click(object sender, EventArgs e) {
            //Authenticate a GS User first
            AuthenticationParameters ap = AuthenticationParameters.CreateInteractiveParameters();
            _securitySerivce.AuthenticateUser(ap);
            if(_securitySerivce.AuthenticatedCredentials!=null) {
                _btnGo.Enabled = true;
                _user = _securitySerivce.AuthenticatedCredentials.User;
                _txbUserName.Text = _user.UserName;
                _txbLanguage.Text = _user.PreferedLanguage;
            }
        }
        
        private string GenerateHTTPRequestHeader() {
            return string.Format("Accept-Language: {0}\r\n", _user.PreferedLanguage);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            if(_securitySerivce!=null) {
                _securitySerivce.Close();
            }
        }

        private void _btnGo_Click(object sender, EventArgs e) {
            object nullObj = null;
            object urlObj = _txbUrl.Text;
            object postDataObj = null;
            string headersStr = GenerateHTTPRequestHeader();
            object headers = headersStr;
            _webBrowser.Navigate2(ref urlObj, ref nullObj, ref nullObj, ref nullObj, ref headers);
        }
    }
}

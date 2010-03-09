using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using AxSHDocVw;
using mshtml;
using SHDocVw;

namespace WebBrowserCtrl {
    public class MyWebBrowser: UserControl, DWebBrowserEvents {
        private UCOMIConnectionPoint icp;
        private int cookie = -1;
		private AxSHDocVw.AxWebBrowser axWebBrowser1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public MyWebBrowser()
		{
			// 
			// Required for Windows Form Designer support
			// 
			InitializeComponent();
			UCOMIConnectionPointContainer icpc = (UCOMIConnectionPointContainer)axWebBrowser1.GetOcx(); // ADDed
 
			Guid g = typeof(DWebBrowserEvents).GUID;
			icpc.FindConnectionPoint(ref g, out icp);
			icp.Advise(this, out cookie);
		}

        public void Navigator(string uRL, ref object flags, ref object targetFrameName, ref object postData, ref object headers) {
            axWebBrowser1.Navigate(uRL);
        }

 
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				// Release event sink
				if (-1 != cookie) icp.Unadvise(cookie);
				        cookie = -1;
                                if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support; do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyWebBrowser));
            this.axWebBrowser1 = new AxSHDocVw.AxWebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.axWebBrowser1)).BeginInit();
            this.SuspendLayout();
            // 
            // axWebBrowser1
            // 
            this.axWebBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axWebBrowser1.Enabled = true;
            this.axWebBrowser1.Location = new System.Drawing.Point(8, 16);
            this.axWebBrowser1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWebBrowser1.OcxState")));
            this.axWebBrowser1.Size = new System.Drawing.Size(448, 240);
            this.axWebBrowser1.TabIndex = 0;
            // 
            // MyWebBrowser
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axWebBrowser1);
            this.Name = "MyWebBrowser";
            this.Size = new System.Drawing.Size(472, 273);
            ((System.ComponentModel.ISupportInitialize)(this.axWebBrowser1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
     

		public void BeforeNavigate(string URL, int Flags, string TargetFrameName, 
			ref object PostData, string Headers, ref bool Cancel)
		{
			//MessageBox.Show("C# DWebBrowser::BeforeNavigate event fired!", "DWebBrowser Event");
		}

		public void PropertyChange(string Property){}

		public void NavigateComplete(string URL){}

		public void WindowActivate(){}

		public void FrameBeforeNavigate(string URL, int Flags, string TargetFrameName, ref object PostData, string Headers, ref bool Cancel){}

		public void NewWindow(string URL, int Flags, string TargetFrameName, ref object PostData, string Headers, ref bool Processed){}

		public void FrameNewWindow(string URL, int Flags, string TargetFrameName, ref object PostData, string Headers, ref bool Processed){}

		public void TitleChange(string Text){}

		public void DownloadBegin(){}

		public void DownloadComplete(){}

		public void WindowMove(){}

		public void WindowResize(){}

		public void Quit(ref bool Cancel){}

		public void ProgressChange(int Progress, int ProgressMax){}

		public void StatusTextChange(string Text){}

		public void CommandStateChange(int Command, bool Enable){}

		public void FrameNavigateComplete(string URL){}

    }
}

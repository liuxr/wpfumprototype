﻿#pragma checksum "..\..\LoadXMLWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A9994362BBF6BA705DA8BD58382E3807"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3603
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace XMLDemo {
    
    
    /// <summary>
    /// LoadXMLWindow
    /// </summary>
    public partial class LoadXMLWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\LoadXMLWindow.xaml"
        internal System.Windows.Controls.RadioButton _urlBtn;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\LoadXMLWindow.xaml"
        internal System.Windows.Controls.RadioButton _streamBtn;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\LoadXMLWindow.xaml"
        internal System.Windows.Controls.RadioButton _stringBtn;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\LoadXMLWindow.xaml"
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\LoadXMLWindow.xaml"
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\LoadXMLWindow.xaml"
        internal System.Windows.Controls.TextBox _inputTbx;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\LoadXMLWindow.xaml"
        internal System.Windows.Controls.Button _openBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/XMLDemo;component/loadxmlwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LoadXMLWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this._urlBtn = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 2:
            this._streamBtn = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 3:
            this._stringBtn = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 4:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this._inputTbx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this._openBtn = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\LoadXMLWindow.xaml"
            this._openBtn.Click += new System.Windows.RoutedEventHandler(this._openBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

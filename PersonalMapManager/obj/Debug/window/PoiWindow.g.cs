﻿#pragma checksum "..\..\..\window\PoiWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EBCCB0875FC5EEBE53C1E8EF5E899104A8985FABF7142B5BD60ECA3E906D2AEA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PersonalMapManager.window;
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
using System.Windows.Shell;


namespace PersonalMapManager.window {
    
    
    /// <summary>
    /// PoiWindow
    /// </summary>
    public partial class PoiWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\window\PoiWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxLatitude;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\window\PoiWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxLongitude;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\window\PoiWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxDescription;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\window\PoiWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonAnnuler;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\window\PoiWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonAppliquer;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\window\PoiWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtunOk;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PersonalMapManager;component/window/poiwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\window\PoiWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TextBoxLatitude = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TextBoxLongitude = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TextBoxDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ButtonAnnuler = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\window\PoiWindow.xaml"
            this.ButtonAnnuler.Click += new System.Windows.RoutedEventHandler(this.ButtonAnnuler_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ButtonAppliquer = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\window\PoiWindow.xaml"
            this.ButtonAppliquer.Click += new System.Windows.RoutedEventHandler(this.ButtonAppliquer_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ButtunOk = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\window\PoiWindow.xaml"
            this.ButtunOk.Click += new System.Windows.RoutedEventHandler(this.ButtunOk_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


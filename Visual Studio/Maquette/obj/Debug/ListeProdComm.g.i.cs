﻿#pragma checksum "..\..\ListeProdComm.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "470F30790D999B03F311B4AE6A1F51CF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Maquette;
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


namespace Maquette {
    
    
    /// <summary>
    /// ListeProdComm
    /// </summary>
    public partial class ListeProdComm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\ListeProdComm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image VG_logo_mini_jpg;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\ListeProdComm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\ListeProdComm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_quitter;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ListeProdComm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_revenir;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\ListeProdComm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridPoint;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\ListeProdComm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ScrollBar scrollBar;
        
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
            System.Uri resourceLocater = new System.Uri("/Maquette;component/listeprodcomm.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ListeProdComm.xaml"
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
            this.VG_logo_mini_jpg = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.btn_quitter = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\ListeProdComm.xaml"
            this.btn_quitter.Click += new System.Windows.RoutedEventHandler(this.btn_quitter_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_revenir = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\ListeProdComm.xaml"
            this.btn_revenir.Click += new System.Windows.RoutedEventHandler(this.btn_revenir_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DataGridPoint = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.scrollBar = ((System.Windows.Controls.Primitives.ScrollBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\GestionFournisseur.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3F95FE2BDC2A51BA59859E63D927F48B"
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
    /// GestionFournisseur
    /// </summary>
    public partial class GestionFournisseur : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\GestionFournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image logo;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\GestionFournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\GestionFournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_quitter;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\GestionFournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbcre;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\GestionFournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbmod;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\GestionFournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbcon;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\GestionFournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_menu;
        
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
            System.Uri resourceLocater = new System.Uri("/Maquette;component/gestionfournisseur.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\GestionFournisseur.xaml"
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
            this.logo = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.btn_quitter = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\GestionFournisseur.xaml"
            this.btn_quitter.Click += new System.Windows.RoutedEventHandler(this.btn_quitter_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.rbcre = ((System.Windows.Controls.RadioButton)(target));
            
            #line 13 "..\..\GestionFournisseur.xaml"
            this.rbcre.Checked += new System.Windows.RoutedEventHandler(this.rbcre_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.rbmod = ((System.Windows.Controls.RadioButton)(target));
            
            #line 14 "..\..\GestionFournisseur.xaml"
            this.rbmod.Checked += new System.Windows.RoutedEventHandler(this.rbmod_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.rbcon = ((System.Windows.Controls.RadioButton)(target));
            
            #line 15 "..\..\GestionFournisseur.xaml"
            this.rbcon.Checked += new System.Windows.RoutedEventHandler(this.rbcon_Checked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_menu = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\GestionFournisseur.xaml"
            this.btn_menu.Click += new System.Windows.RoutedEventHandler(this.btn_menu_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

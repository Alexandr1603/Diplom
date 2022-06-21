﻿#pragma checksum "..\..\..\..\..\Views\Windows\AttractionsWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E7038485DC01E5C84A6241F118D68DFC510A866C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using TA.Desktop.Views.Windows;


namespace TA.Desktop.Views.Windows {
    
    
    /// <summary>
    /// AttractionsWindow
    /// </summary>
    public partial class AttractionsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\..\..\Views\Windows\AttractionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu menu;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\Views\Windows\AttractionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem btnAddAttraction;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\..\Views\Windows\AttractionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem btnEditAttraction;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\Views\Windows\AttractionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem btnDeleteAttraction;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\..\Views\Windows\AttractionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView treeView1;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\..\Views\Windows\AttractionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox AttractionsBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TA.Desktop;V1.0.0.0;component/views/windows/attractionswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Windows\AttractionsWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.menu = ((System.Windows.Controls.Menu)(target));
            return;
            case 2:
            this.btnAddAttraction = ((System.Windows.Controls.MenuItem)(target));
            
            #line 28 "..\..\..\..\..\Views\Windows\AttractionsWindow.xaml"
            this.btnAddAttraction.Click += new System.Windows.RoutedEventHandler(this.btnAddAttraction_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnEditAttraction = ((System.Windows.Controls.MenuItem)(target));
            
            #line 33 "..\..\..\..\..\Views\Windows\AttractionsWindow.xaml"
            this.btnEditAttraction.Click += new System.Windows.RoutedEventHandler(this.btnEditAttraction_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnDeleteAttraction = ((System.Windows.Controls.MenuItem)(target));
            
            #line 38 "..\..\..\..\..\Views\Windows\AttractionsWindow.xaml"
            this.btnDeleteAttraction.Click += new System.Windows.RoutedEventHandler(this.btnDeleteAttraction_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.treeView1 = ((System.Windows.Controls.TreeView)(target));
            
            #line 46 "..\..\..\..\..\Views\Windows\AttractionsWindow.xaml"
            this.treeView1.SelectedItemChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(this.treeView1_SelectedItemChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.AttractionsBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 54 "..\..\..\..\..\Views\Windows\AttractionsWindow.xaml"
            this.AttractionsBox.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.AttractionsBox_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


#pragma checksum "..\..\..\..\..\Views\Windows\ClientsWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FD3C7F68E8B200F7443CFC252AD7124F2BEE4433"
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
    /// ClientsWindow
    /// </summary>
    public partial class ClientsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\..\Views\Windows\ClientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem btnAddClient;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\Views\Windows\ClientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem btnEditClient;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\Views\Windows\ClientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem btnDeleteClient;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\..\Views\Windows\ClientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox clientsBox;
        
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
            System.Uri resourceLocater = new System.Uri("/TA.Desktop;component/views/windows/clientswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Windows\ClientsWindow.xaml"
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
            this.btnAddClient = ((System.Windows.Controls.MenuItem)(target));
            
            #line 24 "..\..\..\..\..\Views\Windows\ClientsWindow.xaml"
            this.btnAddClient.Click += new System.Windows.RoutedEventHandler(this.btnAddClient_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnEditClient = ((System.Windows.Controls.MenuItem)(target));
            
            #line 29 "..\..\..\..\..\Views\Windows\ClientsWindow.xaml"
            this.btnEditClient.Click += new System.Windows.RoutedEventHandler(this.btnEditClient_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnDeleteClient = ((System.Windows.Controls.MenuItem)(target));
            
            #line 34 "..\..\..\..\..\Views\Windows\ClientsWindow.xaml"
            this.btnDeleteClient.Click += new System.Windows.RoutedEventHandler(this.btnDeleteClient_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.clientsBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 41 "..\..\..\..\..\Views\Windows\ClientsWindow.xaml"
            this.clientsBox.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.clientsBox_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


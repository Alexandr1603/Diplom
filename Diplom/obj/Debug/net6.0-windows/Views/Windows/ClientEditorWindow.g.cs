#pragma checksum "..\..\..\..\..\Views\Windows\ClientEditorWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93E46D25A384766DA250FAA22591A6516FE8D3E9"
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
    /// ClientEditorWindow
    /// </summary>
    public partial class ClientEditorWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\..\Views\Windows\ClientEditorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox edSurname;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\Views\Windows\ClientEditorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox edName;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\Views\Windows\ClientEditorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox edPatronomic;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\Views\Windows\ClientEditorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox edPassport;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\Views\Windows\ClientEditorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox edPhone;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\..\Views\Windows\ClientEditorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox edEmail;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\..\Views\Windows\ClientEditorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox edDiscoint;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\..\Views\Windows\ClientEditorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\..\Views\Windows\ClientEditorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
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
            System.Uri resourceLocater = new System.Uri("/TA.Desktop;component/views/windows/clienteditorwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Windows\ClientEditorWindow.xaml"
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
            this.edSurname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.edName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.edPatronomic = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.edPassport = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\..\..\..\Views\Windows\ClientEditorWindow.xaml"
            this.edPassport.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.edPassport_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.edPhone = ((System.Windows.Controls.TextBox)(target));
            
            #line 38 "..\..\..\..\..\Views\Windows\ClientEditorWindow.xaml"
            this.edPhone.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.edPhone_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.edEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.edDiscoint = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\..\..\..\Views\Windows\ClientEditorWindow.xaml"
            this.edDiscoint.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.edPhone_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\..\Views\Windows\ClientEditorWindow.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\..\..\Views\Windows\ClientEditorWindow.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.btnAdd_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\..\Pages\add.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7CE7F77166900DF20DD67B9C8AC552326CAE19E8EA225F25277C5FCB10CF0BFF"
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
using Uslygi.Pages;


namespace Uslygi.Pages {
    
    
    /// <summary>
    /// add
    /// </summary>
    public partial class add : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\Pages\add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TypeComboBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Pages\add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox DurationCombobox;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Pages\add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CountYearTextBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Pages\add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox YearTextBox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Pages\add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button save;
        
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
            System.Uri resourceLocater = new System.Uri("/Uslygi1;component/pages/add.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\add.xaml"
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
            this.TypeComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 22 "..\..\..\Pages\add.xaml"
            this.TypeComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TypeComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DurationCombobox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 23 "..\..\..\Pages\add.xaml"
            this.DurationCombobox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DurationCombobox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CountYearTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.YearTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.save = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Pages\add.xaml"
            this.save.Click += new System.Windows.RoutedEventHandler(this.save_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\..\Custom User Controls\DetailsShortTextBox.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9E20D2FCF15707A61B76A77895574E70"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Commons.ControlLibrary;
using FontAwesome.WPF;
using FontAwesome.WPF.Converters;
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


namespace Commons.ControlLibrary {
    
    
    /// <summary>
    /// DetailsShortTextBox
    /// </summary>
    public partial class DetailsShortTextBox : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Custom User Controls\DetailsShortTextBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Commons.ControlLibrary.DetailsShortTextBox DetailsShortTextBoxUC;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Custom User Controls\DetailsShortTextBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid wrapperGrid;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Custom User Controls\DetailsShortTextBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle border;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Custom User Controls\DetailsShortTextBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border fillerBorder;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Custom User Controls\DetailsShortTextBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock shortTextBox;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Custom User Controls\DetailsShortTextBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Commons.ControlLibrary.CopyButton copyBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/Commons.ControlLibrary;component/custom%20user%20controls/detailsshorttextbox.xa" +
                    "ml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Custom User Controls\DetailsShortTextBox.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.DetailsShortTextBoxUC = ((Commons.ControlLibrary.DetailsShortTextBox)(target));
            return;
            case 2:
            this.wrapperGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.border = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 4:
            this.fillerBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 5:
            this.shortTextBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.copyBtn = ((Commons.ControlLibrary.CopyButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


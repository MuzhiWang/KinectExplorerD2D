﻿#pragma checksum "..\..\UserControl1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B0AF22F1D40972C7A1312668BFEE28DE"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34014
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
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
using System.Windows.Forms.Integration;
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


namespace Northwestern.Samples.Kinect.KinectExplorerD2D {
    
    
    /// <summary>
    /// UserControl1
    /// </summary>
    public partial class UserControl1 : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid1;
        
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
            System.Uri resourceLocater = new System.Uri("/KinectExplorerD2D;component/usercontrol1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UserControl1.xaml"
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
            this.LayoutRoot = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            
            #line 17 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.cbReadOnly_Changed);
            
            #line default
            #line hidden
            
            #line 17 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.cbReadOnly_Changed);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 19 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.cbFreezeColumn_Changed);
            
            #line default
            #line hidden
            
            #line 19 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.cbFreezeColumn_Changed);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 21 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.cbHideColumn_Changed);
            
            #line default
            #line hidden
            
            #line 21 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.cbHideColumn_Changed);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 23 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.cbSelectionMode_Changed);
            
            #line default
            #line hidden
            
            #line 23 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.cbSelectionMode_Changed);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 26 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.cbColReorder_Changed);
            
            #line default
            #line hidden
            
            #line 26 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.cbColReorder_Changed);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 28 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.cbColResize_Changed);
            
            #line default
            #line hidden
            
            #line 28 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.cbColResize_Changed);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 30 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.cbColSort_Changed);
            
            #line default
            #line hidden
            
            #line 30 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.cbColSort_Changed);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 33 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.cbVerticalScroll_Changed);
            
            #line default
            #line hidden
            
            #line 33 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.cbVerticalScroll_Changed);
            
            #line default
            #line hidden
            
            #line 34 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Indeterminate += new System.Windows.RoutedEventHandler(this.cbVerticalScroll_Changed);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 36 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.cbHorizontalScroll_Changed);
            
            #line default
            #line hidden
            
            #line 36 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.cbHorizontalScroll_Changed);
            
            #line default
            #line hidden
            
            #line 37 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Indeterminate += new System.Windows.RoutedEventHandler(this.cbHorizontalScroll_Changed);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 43 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.ComboBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbAltRowBrush_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 49 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.ComboBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbRowBrush_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 55 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.ComboBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbHeaders_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 62 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.ComboBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbGridLines_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 70 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.cbCustomGridLineVert_Changed);
            
            #line default
            #line hidden
            
            #line 71 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.cbCustomGridLineVert_Changed);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 73 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.cbCustomGridLineHorz_Changed);
            
            #line default
            #line hidden
            
            #line 74 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.cbCustomGridLineHorz_Changed);
            
            #line default
            #line hidden
            return;
            case 17:
            this.dataGrid1 = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

﻿#pragma checksum "..\..\..\Window_Block_Game.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D05195E7B941FD7B9D163E1FCF835B17FAD5706D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BLockGame;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace BLockGame {
    
    
    /// <summary>
    /// Window_Block_Game
    /// </summary>
    public partial class Window_Block_Game : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Window_Block_Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Id_Game;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Window_Block_Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox DayComboBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Window_Block_Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameBlockGameTextBox;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Window_Block_Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitButton;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Window_Block_Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox TimeCheckBox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Window_Block_Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StartTimeTextBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Window_Block_Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EndTimeTextBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Window_Block_Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label StartLable;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Window_Block_Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label EndLable;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Window_Block_Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TextTimeInfo;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.7.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BLockGame;component/window_block_game.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Window_Block_Game.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Id_Game = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.DayComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            
            #line 16 "..\..\..\Window_Block_Game.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.NameBlockGameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.ExitButton = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\Window_Block_Game.xaml"
            this.ExitButton.Click += new System.Windows.RoutedEventHandler(this.ExitButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TimeCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 20 "..\..\..\Window_Block_Game.xaml"
            this.TimeCheckBox.Checked += new System.Windows.RoutedEventHandler(this.TimeCheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 20 "..\..\..\Window_Block_Game.xaml"
            this.TimeCheckBox.Unchecked += new System.Windows.RoutedEventHandler(this.TimeCheckBox_Unchecked_1);
            
            #line default
            #line hidden
            return;
            case 7:
            this.StartTimeTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.EndTimeTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.StartLable = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.EndLable = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.TextTimeInfo = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


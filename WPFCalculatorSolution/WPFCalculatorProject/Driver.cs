#pragma checksum "..\..\..\App.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7DC4B4144B4C6F1D093F1E3FFB3F67ADE3E1DBE2"
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Solution/Project:   WPFCalculatorSolution/WPFCalculatorProject
//  File Name:          Driver.cs
//  Description:        Main driver class for calculator
//  Authors:            Bobby Mullins
//  Created:            Sunday, May 21, 2023 | (2023-05-21)
//  Copyright:          N/A
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
using WPFCalculatorProject;


namespace WPFCalculatorProject
{
    /// <summary>
    /// Main driver class for WPF calculator app
    /// </summary>
    public partial class Driver : System.Windows.Application
    {

        /// <summary>
        /// InitializeComponent
        /// </summary>
        public void InitializeComponent()
        {

#line 5 "..\..\..\App.xaml"
            this.StartupUri = new System.Uri("MainWindow.xaml", System.UriKind.Relative);

#line default
#line hidden
        }

        /// <summary>
        /// Application Entry Point.
        /// </summary>
        [System.STAThreadAttribute()]
        public static void Main()
        {
            WPFCalculatorProject.Driver app = new WPFCalculatorProject.Driver();
            app.InitializeComponent();
            app.Run();
        }
    }
}


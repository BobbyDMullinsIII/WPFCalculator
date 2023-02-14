/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Solution/Project:   WPFCalculatorSolution/WPFCalculatorProject
//  File Name:          MainWindows.xaml.cs
//  Description:        MainWindow WPF code file for calculator program
//  Authors:            Bobby Mullins
//  Created:            Thursday, February 9, 2023 | (2023-02-09)
//  Copyright:          N/A
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFCalculatorProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_0_Click(object sender, RoutedEventArgs e)
        {
            MainTextBlock.Text += "0";
        }

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            MainTextBlock.Text += "1";
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            MainTextBlock.Text += "2";
        }

        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            MainTextBlock.Text += "3";
        }

        private void Button_4_Click(object sender, RoutedEventArgs e)
        {
            MainTextBlock.Text += "4";
        }

        private void Button_5_Click(object sender, RoutedEventArgs e)
        {
            MainTextBlock.Text += "5";
        }

        private void Button_6_Click(object sender, RoutedEventArgs e)
        {
            MainTextBlock.Text += "6";
        }

        private void Button_7_Click(object sender, RoutedEventArgs e)
        {
            MainTextBlock.Text += "7";
        }

        private void Button_8_Click(object sender, RoutedEventArgs e)
        {
            MainTextBlock.Text += "8";
        }

        private void Button_9_Click(object sender, RoutedEventArgs e)
        {
            MainTextBlock.Text += "9";
        }

        private void Button_equals_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_plus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_minus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_mult_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_divide_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_del_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_neg_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_dot_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_1over_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_squared_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_sqrt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_percent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_CE_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_C_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

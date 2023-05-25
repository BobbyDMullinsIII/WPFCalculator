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

using System.Windows;

namespace WPFCalculatorProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CalcLogicController controller = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_0_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonType.Zero);
        }

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonType.One);
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonType.Two);
        }

        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonType.Three);
        }

        private void Button_4_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonType.Four);
        }

        private void Button_5_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonType.Five);
        }

        private void Button_6_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonType.Zero);
        }

        private void Button_7_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonType.Zero);
        }

        private void Button_8_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonType.Eight);
        }

        private void Button_9_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonType.Nine);
        }

        private void Button_equals_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonType.Equals);
        }

        private void Button_plus_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonType.Plus);
        }

        private void Button_minus_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonType.Minus);
        }

        private void Button_mult_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonType.Multiply);
        }

        private void Button_divide_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonType.Divide);
        }

        private void Button_del_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonType.Delete);
        }

        private void Button_neg_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonType.Negate);
        }

        private void Button_dot_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonType.Dot);
        }

        private void Button_1over_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonType.OneOver);
        }

        private void Button_squared_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonType.Squared);
        }

        private void Button_sqrt_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonType.SquareRoot);
        }

        private void Button_percent_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonType.Percent);
        }

        private void Button_CE_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonType.ClearEntry);
        }

        private void Button_C_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonType.Clear);
        }

        /// <summary>
        /// Method for sending button press to CalcLogicController class
        /// </summary>
        /// <param name="type">Enum of button that was pressed</param>
        private void ButtonClick(ButtonType type)
        {
            controller.ModifyNumbers(type);
            MainTextBlock.Text = controller.ReturnCurrentNumber();
            PreviousTextBlock.Text = controller.ReturnPreviousNumber();
        }
    }
}

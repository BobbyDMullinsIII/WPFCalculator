/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Solution/Project:   WPFCalculatorSolution/WPFCalculatorProject
//  File Name:          CalcLogicController.cs
//  Description:        Math logic controller class for calculator
//  Authors:            Bobby Mullins
//  Created:            Friday, February 10, 2023 | (2023-02-10)
//  Copyright:          N/A
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalculatorProject
{
    /// <summary>
    /// Class for calculator math logic
    /// </summary>
    public static class CalcLogicController
    {
        //Start empty
        static string previousNumber = "";
        static string currentNumber = "";
        static ButtonType currentMath = ButtonType.Null; //Set to clear when no math logic can been input by user

        public static string ReturnNewNumber(ButtonType pressedButton)
        {
            switch (pressedButton)
            {
                case ButtonType.Zero:
                    return currentNumber += "0";

                case ButtonType.One:
                    return currentNumber += "1";

                case ButtonType.Two:
                    return currentNumber += "2";

                case ButtonType.Three:
                    return currentNumber += "3";

                case ButtonType.Four:
                    return currentNumber += "4";

                case ButtonType.Five:
                    return currentNumber += "5";

                case ButtonType.Six:
                    return currentNumber += "6";

                case ButtonType.Seven:
                    return currentNumber += "7";

                case ButtonType.Eight:
                    return currentNumber += "8";

                case ButtonType.Nine:
                    return currentNumber += "9";

                case ButtonType.Equals:
                    if (currentMath == ButtonType.Null)
                    {
                        return currentNumber;
                    }
                    else
                    {
                        //Insert math method here and put into current number to show user
                        return currentNumber;
                    }

                case ButtonType.Plus:
                case ButtonType.Minus:
                case ButtonType.Multiply:
                case ButtonType.Divide:
                    currentMath = pressedButton;
                    if (string.IsNullOrEmpty(previousNumber))
                    {
                        previousNumber = currentNumber;
                        currentNumber = "";
                    }
                    else
                    {
                        //Insert math method here and put into previous number
                    }

                    return currentNumber;

                case ButtonType.Delete:
                    //Remove last number character in current number
                    currentNumber = currentNumber.Remove(currentNumber.Length - 1, 1);
                    return currentNumber;

                case ButtonType.Negate:
                    //Flips string to and from negative and positive
                    if (currentNumber.Contains("-"))
                    {
                        currentNumber = currentNumber.Remove(0);
                    }
                    else
                    {
                        currentNumber = currentNumber.Insert(0, "-");
                    }
                    return currentNumber;

                case ButtonType.Dot:
                    //Adds decimal to string only if one already is not in it
                    if (currentNumber.Contains(".") == false)
                    {
                        currentNumber += ".";
                    }
                    return currentNumber;

                case ButtonType.OneOver:
                    //Not Done
                    return currentNumber += "NULL";

                case ButtonType.Squared:
                    //Not Done
                    return currentNumber += "NULL";

                case ButtonType.SquareRoot:
                    //Not Done
                    return currentNumber += "NULL";

                case ButtonType.Percent:
                    //Not Done
                    return currentNumber += "NULL";

                case ButtonType.ClearEntry:
                    //Completely resets calculator entry if entry is cleared
                    previousNumber = "";
                    currentNumber = "";
                    currentMath = ButtonType.Null;
                    return currentNumber;

                case ButtonType.Clear:
                    //Only clears current number
                    currentNumber = "";
                    return currentNumber;
            }
        }

    }//end CalcLogicController class
}

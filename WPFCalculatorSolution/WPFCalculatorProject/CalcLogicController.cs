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
        public static string previousNumber = "";
        public static string currentNumber = "";

        public static ButtonType currentMath = ButtonType.Null; //Set to clear when no math logic can been input by user
        public static bool writeLocked = false; //Determines whether calculator should be locke to current number until cleared

        /// <summary>
        /// Method for returning new numbers to calculator based on input
        /// </summary>
        /// <param name="pressedButton">Enum representation of button that was pressed on calculator</param>
        /// <returns>Current main number that should be displayed on the calculator</returns>
        public static string ReturnNewNumber(ButtonType pressedButton)
        {
            if (writeLocked == true && pressedButton != ButtonType.Clear && pressedButton != ButtonType.ClearEntry)
            { 
                //Do nothing if writelocked and clear buttons were not pressed
            }
            else
            {
                switch (pressedButton)
                {
                    case ButtonType.Zero:
                        currentNumber += "0";
                        break;

                    case ButtonType.One:
                        currentNumber += "1";
                        break;

                    case ButtonType.Two:
                        currentNumber += "2";
                        break;

                    case ButtonType.Three:
                        currentNumber += "3";
                        break;

                    case ButtonType.Four:
                        currentNumber += "4";
                        break;

                    case ButtonType.Five:
                        currentNumber += "5";
                        break;

                    case ButtonType.Six:
                        currentNumber += "6";
                        break;

                    case ButtonType.Seven:
                        currentNumber += "7";
                        break;

                    case ButtonType.Eight:
                        currentNumber += "8";
                        break;

                    case ButtonType.Nine:
                        currentNumber += "9";
                        break;

                    case ButtonType.Equals:
                        if (currentMath != ButtonType.Null 
                            && string.IsNullOrEmpty(currentNumber) == false 
                            && string.IsNullOrEmpty(previousNumber) == false)
                        {
                            switch (currentMath)
                            {
                                case ButtonType.Plus:
                                    double plusNum = Convert.ToDouble(previousNumber) + Convert.ToDouble(currentNumber);
                                    currentNumber = plusNum.ToString();
                                    break;

                                case ButtonType.Minus:
                                    double minusNum = Convert.ToDouble(previousNumber) - Convert.ToDouble(currentNumber);
                                    currentNumber = minusNum.ToString();
                                    break;

                                case ButtonType.Multiply:
                                    double multNum = Convert.ToDouble(previousNumber) * Convert.ToDouble(currentNumber);
                                    currentNumber = multNum.ToString();
                                    break;

                                case ButtonType.Divide:
                                    double divideNum = Convert.ToDouble(previousNumber) / Convert.ToDouble(currentNumber);
                                    currentNumber = divideNum.ToString();
                                    break;
                            }

                            writeLocked = true;
                        }
                        break;

                    case ButtonType.Plus:
                        currentMath = pressedButton;
                        previousNumber = currentNumber;
                        currentNumber = "";
                        break;

                    case ButtonType.Minus:
                        currentMath = pressedButton;
                        previousNumber = currentNumber;
                        currentNumber = "";
                        break;

                    case ButtonType.Multiply:
                        currentMath = pressedButton;
                        previousNumber = currentNumber;
                        currentNumber = "";
                        break;

                    case ButtonType.Divide:
                        currentMath = pressedButton;
                        previousNumber = currentNumber;
                        currentNumber = "";
                        break;

                    case ButtonType.Delete:
                        //Remove last number character in current number
                        if (string.IsNullOrEmpty(currentNumber) == false)
                        {
                            currentNumber = currentNumber.Remove(currentNumber.Length - 1, 1);
                        }
                        break;

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
                        break;

                    case ButtonType.Dot:
                        //Adds decimal to string only if one already is not in it
                        if (currentNumber.Contains(".") == false)
                        {
                            currentNumber += ".";
                        }
                        break;

                    case ButtonType.OneOver:
                        if (string.IsNullOrEmpty(currentNumber) == false)
                        {
                            double oneOverNum = 1 / Convert.ToDouble(currentNumber);
                            currentNumber = oneOverNum.ToString();
                        }
                        break;

                    case ButtonType.Squared:
                        if (string.IsNullOrEmpty(currentNumber) == false)
                        {
                            double squareNum = Math.Pow(Convert.ToDouble(currentNumber), 2);
                            currentNumber += squareNum.ToString();
                        }
                        break;

                    case ButtonType.SquareRoot:
                        if (string.IsNullOrEmpty(currentNumber) == false)
                        {
                            double sqrtNum = Math.Sqrt(Convert.ToDouble(currentNumber));
                            currentNumber += sqrtNum.ToString();
                        }
                        break;

                    case ButtonType.Percent:
                        //Not Done
                        currentNumber = "NULL";
                        break;

                    case ButtonType.ClearEntry:
                        //Completely resets calculator entry if entry is cleared
                        previousNumber = "";
                        currentNumber = "";
                        currentMath = ButtonType.Null;
                        writeLocked = false;
                        break;

                    case ButtonType.Clear:
                        //Only clears current number
                        currentNumber = "";
                        writeLocked = false;
                        break;

                    default:
                        currentNumber = "ERROR IN SWITCH STATEMENT";
                        break;
                }
            }

            return currentNumber;
        }

    }//end CalcLogicController class
}

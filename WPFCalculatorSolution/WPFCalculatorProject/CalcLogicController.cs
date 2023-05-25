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

namespace WPFCalculatorProject
{
    /// <summary>
    /// Class for calculator math logic
    /// </summary>
    public class CalcLogicController
    {
        string previousNumber;
        string currentNumber;
        ButtonType currentMath;

        /// <summary>
        /// Basic constructor for CalcLogicController
        /// </summary>
        public CalcLogicController() 
        {
            //Standard values set to empty or null
            this.previousNumber = "";
            this.currentNumber = "";
            this.currentMath = ButtonType.Null;
        }

        /// <summary>
        /// Method for returning 'previousNumber'
        /// </summary>
        /// <returns>'previousNumber' string</returns>
        public string ReturnPreviousNumber()
        {
            return previousNumber;
        }

        /// <summary>
        /// Method for returning 'currentNumber'
        /// </summary>
        /// <returns>'currentNumber' string</returns>
        public string ReturnCurrentNumber()
        {
            return currentNumber;
        }

        /// <summary>
        /// Method for setting all parameters to standard empty values
        /// </summary>
        public void ResetValues()
        {
            this.previousNumber = "";
            this.currentNumber = "";
            this.currentMath = ButtonType.Null;
        }

        /// <summary>
        /// Method for modifying numbers on calculator based on button input
        /// </summary>
        /// <param name="pressedButton">Enum representation of button that was pressed on calculator</param>
        public void ModifyNumbers(ButtonType pressedButton)
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
                    //Will only work if 'currentMath', 'currentNumber', and 'previousNumber' actually have user-inserted data in them
                    if (currentMath != ButtonType.Null && string.IsNullOrEmpty(currentNumber) == false && string.IsNullOrEmpty(previousNumber) == false)
                    {
                        currentNumber = CalcMathOperation(Convert.ToDouble(previousNumber), Convert.ToDouble(currentNumber), currentMath).ToString();
                    }
                    break;

                case ButtonType.Plus:
                case ButtonType.Minus:
                case ButtonType.Multiply:
                case ButtonType.Divide:
                    MathOperatorLogic(pressedButton);
                    break;

                case ButtonType.Delete:
                    //Remove last number character in current number
                    if (string.IsNullOrEmpty(currentNumber) == false)
                    {
                        currentNumber = currentNumber.Remove(currentNumber.Length - 1, 1);
                    }
                    break;

                case ButtonType.Negate:
                    //Flips 'currentNumber' to and from negative and positive
                    if (currentNumber.Contains('-'))
                    {
                        currentNumber = currentNumber.Remove(0);
                    }
                    else
                    {
                        currentNumber = currentNumber.Insert(0, "-");
                    }
                    break;

                case ButtonType.Dot:
                    //Adds decimal to 'currentNumber' only if one is already not in it
                    if (currentNumber.Contains('.') == false)
                    {
                        currentNumber += ".";
                    }
                    break;

                case ButtonType.OneOver:
                    //Calculates 'currentNumber' to be one over itself
                    if (string.IsNullOrEmpty(currentNumber) == false)
                    {
                        double oneOverNum = 1 / Convert.ToDouble(currentNumber);
                        currentNumber = oneOverNum.ToString();
                    }
                    break;

                case ButtonType.Squared:
                    //Calculates 'currentNumber' to be a square of itself
                    if (string.IsNullOrEmpty(currentNumber) == false)
                    {
                        double squareNum = Math.Pow(Convert.ToDouble(currentNumber), 2);
                        currentNumber += squareNum.ToString();
                    }
                    break;

                case ButtonType.SquareRoot:
                    //Calculates 'currentNumber' to be a square root of itself
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
                    //Completely resets calculator
                    ResetValues();
                    break;

                case ButtonType.Clear:
                    //Only clears current number
                    currentNumber = "";
                    break;

                default:
                    //Default only if an unspecified buttontype gets input somehow
                    currentNumber = "ERROR, DEFAULT IN SWITCH STATEMENT REACHED";
                    break;
            }
        }

        /// <summary>
        /// Method for returning result of math operatin
        /// </summary>
        /// <param name="firstNum">First number to conduct operation</param>
        /// <param name="secondNum">Second number to conduct operation</param>
        /// <param name="currentType">Type of math operation to conduct</param>
        /// <returns>Result of math operation</returns>
        public static double CalcMathOperation(double firstNum, double secondNum, ButtonType currentType)
        {
            return currentType switch
            {
                ButtonType.Plus => firstNum + secondNum,
                ButtonType.Minus => firstNum - secondNum,
                ButtonType.Multiply => firstNum * secondNum,
                ButtonType.Divide => firstNum / secondNum,
                _ => 0.0,
            };
        }

        /// <summary>
        /// Method for logic when pressing math operation buttons
        /// </summary>
        /// <param name="currentType">Type of math operation that was input</param>
        public void MathOperatorLogic(ButtonType currentType)
        {
            if (string.IsNullOrEmpty(previousNumber) == true)
            {
                currentMath = currentType;
                previousNumber = currentNumber;
                currentNumber = "";
            }
        }

    }//end CalcLogicController class
}

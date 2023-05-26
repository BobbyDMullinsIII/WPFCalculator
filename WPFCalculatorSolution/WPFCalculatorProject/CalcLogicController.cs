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
                    //Will only work if 'currentMath', 'currentNumber', and 'previousNumber' have input data
                    if (currentMath != ButtonType.Null
                        && string.IsNullOrEmpty(currentNumber) == false
                        && string.IsNullOrEmpty(previousNumber) == false)
                    {
                        double prevNum = Convert.ToDouble(previousNumber);
                        double currNum = Convert.ToDouble(currentNumber);
                        currentNumber = CalcMathOperation(prevNum, currNum, currentMath).ToString();
                    }
                    break;

                case ButtonType.Plus:
                case ButtonType.Minus:
                case ButtonType.Multiply:
                case ButtonType.Divide:
                    //Will return respective value if 'currentNumber' is not empty
                    MathOperatorLogic(pressedButton);
                    break;

                case ButtonType.Delete:
                    //Remove last number character in current number if not empty
                    currentNumber = DeleteLast(currentNumber);
                    break;

                case ButtonType.Negate:
                    //Flips 'currentNumber' to and from negative and positive
                    currentNumber = ToggleNegate(currentNumber);
                    break;

                case ButtonType.Dot:
                    //Adds decimal to 'currentNumber' only if one is already not in it
                    currentNumber = AddDot(currentNumber);
                    break;

                case ButtonType.OneOver:
                case ButtonType.Squared:
                case ButtonType.SquareRoot:
                    //Will return respective value if 'currentNumber' is not empty
                    currentNumber = CalcFractionSquareSqrt(currentNumber, pressedButton);
                    break;

                case ButtonType.Percent:
                    //Not Done
                    currentNumber = "PERCENT NOT DONE";
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
            //Will only conduct operation if 'currentNumber' is not empty
            if (string.IsNullOrEmpty(currentNumber) == false)
            {
                if (string.IsNullOrEmpty(previousNumber) == true)
                {
                    currentMath = currentType;
                    previousNumber = currentNumber;
                    currentNumber = "";
                }
            }
        }

        /// <summary>
        /// Method for returning number in string form after deleting last character
        /// </summary>
        /// <param name="inputStrNum">Input number in string form to delete last character of</param>
        /// <returns>Number string after delete</returns>
        public static string DeleteLast(string inputStrNum)
        {
            //Will only conduct operation if 'inputStrNum' is not empty
            if (string.IsNullOrEmpty(inputStrNum) == false)
            {
                return inputStrNum.Remove(inputStrNum.Length - 1, 1);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Method for returning number in string form after negate
        /// </summary>
        /// <param name="inputStrNum">Input number in string form to negate</param>
        /// <returns>Number string after negate</returns>
        public static string ToggleNegate(string inputStrNum)
        {
            //Will only conduct operation if 'inputStrNum' is not empty
            if (string.IsNullOrEmpty(inputStrNum) == false)
            {
                if (inputStrNum.Contains('-'))
                {
                    return inputStrNum.Remove(0);
                }
                else
                {
                    return inputStrNum.Insert(0, "-");
                }
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Method for returning number in string form after adding dot
        /// </summary>
        /// <param name="inputStrNum">Input number in string form to add dot to</param>
        /// <returns>Number string after adding dot</returns>
        public static string AddDot(string inputStrNum)
        {
            //Will only conduct operation if 'inputStrNum' is not empty and does not contain a dot
            if (inputStrNum.Contains('.') == false && string.IsNullOrEmpty(inputStrNum) == false)
            {
                return inputStrNum + ".";
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Method for returning in string form after fraction, square, or square root
        /// </summary>
        /// <param name="inputStrNum">Input number in string form to do operation on</param>
        /// <param name="currentType">Type of math operation that was input</param>
        /// <returns>'currentNumber' string after math operation</returns>
        public static string CalcFractionSquareSqrt(string inputStrNum, ButtonType currentType)
        {
            //Will only conduct operation if the input number is not empty
            if (string.IsNullOrEmpty(inputStrNum) == false)
            {
                double tempNum = Convert.ToDouble(inputStrNum);

                return currentType switch
                {
                    ButtonType.OneOver => (1 / tempNum).ToString(),
                    ButtonType.Squared => (Math.Pow(tempNum, 2)).ToString(),
                    ButtonType.SquareRoot => (Math.Sqrt(tempNum)).ToString(),
                    _ => "",
                };
            }
            else
            {
                return "";
            }
        }

    }//end CalcLogicController class
}

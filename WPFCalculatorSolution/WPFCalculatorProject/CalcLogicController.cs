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
        string topDisplayStr;  //String for display on top TextBox of calculator
        string previousNumStr; //Actual stored previous number
        string currentNumStr;  //Stored current number
        ButtonType currentMath;//Stored current math operation

        /// <summary>
        /// Basic constructor for CalcLogicController
        /// </summary>
        public CalcLogicController()
        {
            //Standard values set to empty or null
            topDisplayStr = "";
            previousNumStr = "";
            currentNumStr = "";
            currentMath = ButtonType.Null;
        }

        /// <summary>
        /// Method for returning 'topDisplayStr'
        /// </summary>
        /// <returns>'topDisplayStr' string</returns>
        public string ReturnDisplayStr()
        {
            return topDisplayStr;
        }

        /// <summary>
        /// Method for returning 'previousNumStr'
        /// </summary>
        /// <returns>'previousNumStr' string</returns>
        public string ReturnPreviousNumber()
        {
            return previousNumStr;
        }

        /// <summary>
        /// Method for returning 'currentNumStr'
        /// </summary>
        /// <returns>'currentNumStr' string</returns>
        public string ReturnCurrentNumber()
        {
            return currentNumStr;
        }

        /// <summary>
        /// Method for returning 'currentMath'
        /// </summary>
        /// <returns>'currentMath' string</returns>
        public ButtonType ReturnCurrentMath()
        {
            return currentMath;
        }

        /// <summary>
        /// Method for setting all parameters to standard empty values
        /// </summary>
        public void ResetValues()
        {
            topDisplayStr = "";
            previousNumStr = "";
            currentNumStr = "";
            currentMath = ButtonType.Null;
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
                    currentNumStr += "0";
                    break;

                case ButtonType.One:
                    currentNumStr += "1";
                    break;

                case ButtonType.Two:
                    currentNumStr += "2";
                    break;

                case ButtonType.Three:
                    currentNumStr += "3";
                    break;

                case ButtonType.Four:
                    currentNumStr += "4";
                    break;

                case ButtonType.Five:
                    currentNumStr += "5";
                    break;

                case ButtonType.Six:
                    currentNumStr += "6";
                    break;

                case ButtonType.Seven:
                    currentNumStr += "7";
                    break;

                case ButtonType.Eight:
                    currentNumStr += "8";
                    break;

                case ButtonType.Nine:
                    currentNumStr += "9";
                    break;

                case ButtonType.Equals:
                    //Will only work if 'currentMath', 'currentNumber', and 'previousNumber' have input data
                    MathEqualsLogic();
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
                    currentNumStr = DeleteLast(currentNumStr);
                    break;

                case ButtonType.Negate:
                    //Flips 'currentNumber' to and from negative and positive
                    currentNumStr = ToggleNegate(currentNumStr);
                    break;

                case ButtonType.Dot:
                    //Adds decimal to 'currentNumber' only if one is already not in it
                    currentNumStr = AddDot(currentNumStr);
                    break;

                case ButtonType.OneOver:
                case ButtonType.Squared:
                case ButtonType.SquareRoot:
                    //Will return respective value if 'currentNumber' is not empty
                    currentNumStr = CalcFractionSquareSqrt(currentNumStr, pressedButton);
                    break;

                case ButtonType.Percent:
                    //Converts number to percentage equivalent in decimal form
                    currentNumStr = CalcPercentage(currentNumStr);
                    break;

                case ButtonType.ClearEntry:
                    //Only clears current number
                    currentNumStr = "";
                    break;

                case ButtonType.Clear:
                    //Completely resets calculator
                    ResetValues();
                    break;

                default:
                    //Default only if an unspecified buttontype gets input somehow
                    currentNumStr = "ERROR, DEFAULT IN SWITCH STATEMENT REACHED";
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
        /// Method for adding math operator symbol to a string based on ButtonType
        /// </summary>
        /// <param name="inputType">Type of math operation that was input</param>
        /// <returns>Math operator with spaces on each side</returns>
        public static string InsertMathOperator(ButtonType inputType)
        {
            return inputType switch
            {
                ButtonType.Plus => " + ",
                ButtonType.Minus => " - ",
                ButtonType.Multiply => " x ",
                ButtonType.Divide => " ÷ ",
                _ => "Error in 'InsertMathOperator()' method switch statement.",
            };
        }

        /// <summary>
        /// Method for logic when pressing equals button
        /// </summary>
        public void MathEqualsLogic()
        {
            if (currentMath != ButtonType.Null)
            {
                if (string.IsNullOrEmpty(currentNumStr) == false && string.IsNullOrEmpty(previousNumStr) == false)
                {
                    topDisplayStr += currentNumStr;
                    currentNumStr = CalcMathOperation(Convert.ToDouble(previousNumStr), Convert.ToDouble(currentNumStr), currentMath).ToString();
                    previousNumStr = "";
                }
            }
        }

        /// <summary>
        /// Method for logic when pressing math operation buttons
        /// </summary>
        /// <param name="currentType">Type of math operation that was input</param>
        public void MathOperatorLogic(ButtonType currentType)
        {
            //Will only conduct operation if 'currentNumber' is not empty
            if (string.IsNullOrEmpty(currentNumStr) == false)
            {
                if (string.IsNullOrEmpty(previousNumStr) == true)
                {
                    //Puts current number into previous number if previous number is empty
                    previousNumStr = currentNumStr;
                    currentMath = currentType;
                    topDisplayStr = currentNumStr + InsertMathOperator(currentMath);
                    currentNumStr = "";
                }
                else
                {
                    //Logic for extra numbers if two numbers have already been calculated
                    previousNumStr = CalcMathOperation(Convert.ToDouble(previousNumStr), Convert.ToDouble(currentNumStr), currentMath).ToString();
                    currentMath = currentType;
                    topDisplayStr = previousNumStr + InsertMathOperator(currentType);
                    currentNumStr = "";
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
        /// Method for converting a number to a percent and returning it as a decimal number
        /// </summary>
        /// <param name="inputStrNum">Input number in string form to calculate percentage</param>
        /// <returns>Number string after calculating percentage</returns>
        public static string CalcPercentage(string inputStrNum)
        {
            //Will only conduct operation if 'inputStrNum' is not empty
            if (string.IsNullOrEmpty(inputStrNum) == false)
            {
                return (Convert.ToDouble(inputStrNum) / 100.0).ToString();
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

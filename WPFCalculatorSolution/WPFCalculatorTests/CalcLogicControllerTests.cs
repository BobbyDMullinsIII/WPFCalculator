using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace WPFCalculatorTests
{
    [TestClass]
    public class CalcLogicControllerTests
    {
        [TestMethod]
        //Arrange
        [DataRow(1.0, 2.0, ButtonType.Plus, 3.0)]       //1.0 + 2.0 = 3.0
        [DataRow(-1.0, -2.0, ButtonType.Plus, -3.0)]    //-1.0 + -2.0 = -3.0
        [DataRow(1.23184902, 4.2939032, ButtonType.Plus, 5.52575222)]               //1.23184902 + 4.2939032 = 5.52575222
        [DataRow(0.0, 0.0, ButtonType.Plus, 0.0)]       //0.0 + 0.0 = 0.0
        [DataRow(1.0, 2.0, ButtonType.Minus, -1.0)]     //1.0 - 2.0 = -1.0
        [DataRow(12.0, 9.0, ButtonType.Minus, 3.0)]     //12.0 - 9.0 = 3.0
        [DataRow(17.0, -2.0, ButtonType.Minus, 19.0)]   //17.0 - -2.0 = 19.0
        [DataRow(0.0, 0.0, ButtonType.Minus, 0.0)]      //0.0 - 0.0 = 0.0
        [DataRow(1.0, 2.0, ButtonType.Multiply, 2.0)]   //1.0 * 2.0 = 2.0
        [DataRow(10.0, 2.0, ButtonType.Multiply, 20.0)] //10.0 * 2.0 = 20.0
        [DataRow(-1.0, 5.0, ButtonType.Multiply,-5.0)]  //-1.0 * 5.0 = -5.0
        [DataRow(1.23184902, 4.2939032, ButtonType.Multiply, 5.289440448894864)]    //1.23184902 * 4.2939032 = 5.289440448894864
        [DataRow(1.0, 2.0, ButtonType.Divide, 0.5)]     //1.0 / 2.0 = 0.5
        [DataRow(20.0, 2.0, ButtonType.Divide, 10.0)]   //20.0 / 2.0 = 10.0
        [DataRow(15.0, 4.0, ButtonType.Divide, 3.75)]   //15.0 / 4.0 = 3.75
        [DataRow(1.23184902, 4.2939032, ButtonType.Divide, 0.2868832767352557)]     //1.23184902 / 4.2939032 = 0.2868832767352557
        /// <param name="firstNum">First number to conduct operation</param>
        /// <param name="secondNum">Second number to conduct operation</param>
        /// <param name="currentType">Type of math operation to conduct</param>
        /// <param name="expected">Expected result of specified math operation</param>
        public void TestCalcMathOperation(double firstNum, double secondNum, ButtonType currentType, double expected)
        {
            //Act
            double actual = CalcLogicController.CalcMathOperation(firstNum, secondNum, currentType);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        //Arrange
        [DataRow(ButtonType.Plus, " + ")]
        [DataRow(ButtonType.Minus, " - ")]
        [DataRow(ButtonType.Multiply, " x ")]
        [DataRow(ButtonType.Divide, " ÷ ")]
        /// <param name="inputType">Type of math operation that was input</param>
        /// <param name="expected">Expected corresponding math operator with spaces on each side</param>
        public void TestInsertMathOperator(ButtonType inputType, string expected)
        {
            //Act
            string actual = CalcLogicController.InsertMathOperator(inputType);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        //Arrange
        [DataRow("1234", "123")]
        [DataRow("-127867854", "-12786785")]
        [DataRow("asjmoifdjasfm", "asjmoifdjasf")]
        [DataRow("", "")]
        /// <param name="inputStrNum">Input number in string form to delete last character of</param>
        /// <param name="expected">Expected number string after last character deleted</param>
        public void TestDeleteLastChar(string inputStrNum, string expected)
        {
            //Act
            string actual = CalcLogicController.DeleteLastChar(inputStrNum);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        //Arrange
        [DataRow("1234", "-1234")]
        [DataRow("-127867854", "127867854")]
        [DataRow("-1.235235235", "1.235235235")]
        [DataRow("", "")]
        /// <param name="inputStrNum">Input number in string form to negate</param>
        /// <param name="expected">Expected number string after negate</param>
        public void TestToggleNegate(string inputStrNum, string expected)
        {
            //Act
            string actual = CalcLogicController.ToggleNegate(inputStrNum);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        //Arrange
        [DataRow("1234", "1234.")]
        [DataRow("-127867854", "-127867854.")]
        [DataRow("1234.098", "1234.098")]
        [DataRow("", "")]
        /// <param name="inputStrNum">Input number in string form to add dot to</param>
        /// <param name="expected">Expected number string after adding dot if dot is not already present</param>
        public void TestAddDot(string inputStrNum, string expected)
        {
            //Act
            string actual = CalcLogicController.AddDot(inputStrNum);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        //Arrange
        [DataRow("1234", "12.34")]
        [DataRow("-127867854", "-1278678.54")]
        [DataRow("1234.098", "12.34098")]
        [DataRow("", "")]
        /// <param name="inputStrNum">Input number in string form to calculate percentage</param>
        /// <param name="expected">Expected number string after calculating percentage</param>
        public void TestCalcPercentage(string inputStrNum, string expected)
        {
            //Act
            string actual = CalcLogicController.CalcPercentage(inputStrNum);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        //Arrange
        [DataRow("10", ButtonType.OneOver, "0.1")]
        [DataRow("", ButtonType.OneOver, "")]
        [DataRow("10", ButtonType.Squared, "100")]
        [DataRow("", ButtonType.Squared, "")]
        [DataRow("16", ButtonType.SquareRoot, "4")]
        [DataRow("", ButtonType.SquareRoot, "")]
        [DataRow("1234", ButtonType.Null, "")]
        [DataRow("", ButtonType.Null, "")]
        /// <param name="inputStrNum">Input number in string form to do operation on</param>
        /// <param name="currentType">Type of math operation that was input</param>
        /// <param name="expected">Expected number string after math operation</param>
        public void TestCalcFractionSquareSqrt(string inputStrNum, ButtonType currentType, string expected)
        {
            //Act
            string actual = CalcLogicController.CalcFractionSquareSqrt(inputStrNum, currentType);

            //Assert
            Assert.AreEqual(actual, expected);
        }
    }
}

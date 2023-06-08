using System.Windows.Media.Media3D;

namespace WPFCalculatorTests
{
    [TestClass]
    public class CalcLogicControllerTests
    {
        [TestMethod]
        //Arrange
        [DataRow(1.0, 2.0, ButtonType.Plus, 3.0)]
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
        public void TestInsertMathOperator()
        {

        }

        [TestMethod]
        public void TestDeleteLastChar()
        {

        }

        [TestMethod]
        public void TestToggleNegate()
        {

        }

        [TestMethod]
        public void TestAddDot()
        {

        }

        [TestMethod]
        public void TestCalcPercentage()
        {

        }

        [TestMethod]
        public void TestCalcFractionSquareSqrt()
        {

        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestApp.Tests
{
    [TestClass()]
    public class InvestmentCalculatorTests
    {
        [TestMethod()]
        public void GetPayoutAmountTest()
        {
            //arrange
            decimal Investment = 350000M;
            decimal Rate = 4.7M / 12 / 100;
            System.DateTime DateAgreement = new System.DateTime(2022, 3, 14);
            System.DateTime DateCalculation = new System.DateTime(2023, 3, 14);

            decimal expected = 29914.52M;

            //act
            InvestmentCalculator investmentCalculator = new InvestmentCalculator(Investment, Rate, DateAgreement, DateCalculation);

            investmentCalculator.GetPayoutAmount();

            decimal actual = System.Math.Round(investmentCalculator.PaymentAmount, 2);

            //assert
            Assert.AreEqual(expected, actual); 
        }
    }
}
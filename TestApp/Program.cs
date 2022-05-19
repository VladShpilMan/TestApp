using System;
using TestApp;

class MainClass
{
    static void Main()
    {
        Console.Write("Enter the amount of money to invest: ");
        decimal investment = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Enter interest rate: ");
        decimal rate = Convert.ToDecimal(Console.ReadLine());
        rate /= 12 * 100;

        Console.Write("Enter agreement date(YYYY/MM/DD): ");
        DateTime DateAgreement = Convert.ToDateTime(Console.ReadLine());

        Console.Write("Enter сalculation date(YYYY/MM/DD): ");
        DateTime DateCalculation = Convert.ToDateTime(Console.ReadLine());

        InvestmentCalculator investmentCalculator = new InvestmentCalculator(investment, rate, DateAgreement, DateCalculation);

        investmentCalculator.GetPayoutAmount();

        Console.WriteLine(investmentCalculator.ToString());
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    class InvestmentCalculator
    {
        #region Properties
        public decimal Investment { get; private set; }
        private decimal PaymentAmount { get; set; }
        public decimal Rate { get; private set; }
        public DateTime DateAgreement { get; private set; }
        public DateTime DateCalculation { get; private set; }
        #endregion

        public InvestmentCalculator()
        {
            this.Investment = 350000M;
            this.Rate = 4.7M / 12 / 100;
            this.DateAgreement = new DateTime(2022, 3, 14);
            this.DateCalculation = new DateTime(2023, 3, 14);
        }

        public InvestmentCalculator(decimal Investment, decimal Rate, DateTime DateAgreement, DateTime DateCalculation)
        {
            this.Investment = Investment;
            this.Rate = Rate;
            this.DateAgreement = DateAgreement;
            this.DateCalculation = DateCalculation;
        }

        public void GetPayoutAmount()
        {
            if (Investment < 0)
            {
                throw new ArgumentException("Investment can't be less or null", nameof(Investment));
            }

            if (Rate < 0)
            {
                throw new ArgumentException("Interest rate can't be less or null", nameof(Rate));
            }

            PaymentAmount = Investment * (Rate * (decimal)Math.Pow((double)(1 + Rate), GetMonths(DateAgreement, DateCalculation))) / (((decimal)Math.Pow((double)(1 + Rate), GetMonths(DateAgreement, DateCalculation)) - 1));
        }

        private int GetMonths(DateTime start, DateTime end)
        {
            int months = default;

            try
            {
                months = (end.Month + end.Year * 12) - (start.Month + start.Year * 12);

                if (months <= 0) throw new ArgumentException("Wrong dates entered.");

                return months;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message}");

                return default;
            }
        }

        public override string ToString()
        {
            return string.Format($"\nInvestment: {this.Investment}$\n" +
                                 $"Rate: {Math.Round(this.Rate * 1200, 1)}%\n" +
                                 $"Date Agreement: {this.DateAgreement.ToString("MM/dd/yyyy")}\n" +
                                 $"Date Calculation: {this.DateCalculation.ToString("MM/dd/yyyy")}\n" +
                                 "===============\n" +
                                 $"Payment Amount: {Math.Round(this.PaymentAmount, 2)}$"
                                );
        }
    }
}


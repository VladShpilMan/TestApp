using System;

class MainClass
{
    public static int GetMonths(DateTime start, DateTime end)
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

    private static decimal GetPayoutAmount(DateTime dateAgreement, DateTime dateCalculation, decimal X, decimal R)
    {
        if (X < 0)
        {
            throw new ArgumentException("Investment can't be less or null", nameof(X));
        }

        if (R < 0)
        {
            throw new ArgumentException("Interest rate can't be less or null", nameof(R));
        }

        decimal paymentAmount = default;

        double a = (double)(1 + R);

        paymentAmount = X * (R * (decimal)Math.Pow((double)(1 + R), GetMonths(dateAgreement, dateCalculation))) / (((decimal)Math.Pow(a, GetMonths(dateAgreement, dateCalculation)) - 1));

        return Math.Round((decimal)paymentAmount, 2);
    }
    static void Main()
    {
        Console.WriteLine("The payment amount: " + GetPayoutAmount(new DateTime(2022, 3, 14), new DateTime(2023, 3, 14), 350000, 4.7M / 12 / 100));
    }
}

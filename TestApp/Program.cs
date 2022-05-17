using System;

class MainClass
{
    private const int YEAR = 365;

    public static decimal GetDays(DateTime start, DateTime end)
    {
        decimal days = default;

        try
        {
            days = (decimal)(end - start).TotalDays;
                
            if(days <= 0) throw new ArgumentException("Wrong dates entered.");


            return days;
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
            throw new ArgumentException("Interest rate can't be less or null", nameof(X));
        }

        decimal sum = 0M;

        sum = (X * R * GetDays(dateAgreement, dateCalculation)) / (100 * YEAR);

        return Math.Round(sum, 4);
    }
    static void Main()
    {
        Console.WriteLine("The amount of all payments: " + GetPayoutAmount(new DateTime(2022, 3, 14), new DateTime(2022, 5, 14), 350000, 4.7M));
    }
}

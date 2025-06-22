using System;

public class FinancialForecast
{
    // Recursive method
    public static double PredictFutureValueRecursive(double presentValue, double rate, int years)
    {
        if (years == 0)
            return presentValue;
        return PredictFutureValueRecursive(presentValue, rate, years - 1) * (1 + rate);
    }

    // Iterative method
    public static double PredictFutureValueIterative(double presentValue, double rate, int years)
    {
        double value = presentValue;
        for (int i = 0; i < years; i++)
        {
            value *= (1 + rate);
        }
        return value;
    }

    // Main method
    public static void Main(string[] args)
    {
        double presentValue = 10000; // ₹10,000
        double annualRate = 0.05;    // 5% annual growth
        int years = 5;

        Console.WriteLine("Financial Forecasting Tool\n");

        double recursiveResult = PredictFutureValueRecursive(presentValue, annualRate, years);
        Console.WriteLine($"Recursive: Future value after {years} years: ₹{recursiveResult:F2}");

        double iterativeResult = PredictFutureValueIterative(presentValue, annualRate, years);
        Console.WriteLine($"Iterative: Future value after {years} years: ₹{iterativeResult:F2}");
    }
}

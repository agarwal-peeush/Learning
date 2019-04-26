using System;

namespace Learning.DesignPatterns
{
    internal class ConsoleInput
    {
        internal static bool TryReadDecimal(string v, out decimal expenseReportAmount)
        {
            expenseReportAmount = decimal.Zero;

            Console.Write(v);
            var input = Console.ReadLine().Trim();
            
            if (string.IsNullOrEmpty(input))
                return false;

            if (decimal.TryParse(input, out expenseReportAmount))
                return true;

            return false;
        }
    }
}

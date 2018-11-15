using System;
using System.Globalization;

namespace Deposit
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите сумму вклада");
            var amountInputIsCorrect = double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double amount);

            Console.WriteLine("Введите годовую процентную ставку");
            var rateInputIsCorrect = double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double rate);

            Console.WriteLine("Введите срок вклада в месяцах");
            var termInputIsCorrect = double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double term);

            if (!amountInputIsCorrect || !rateInputIsCorrect || !termInputIsCorrect || amount < 0 || rate < 0 || term < 0)
            {
                Console.WriteLine("Введены некорректные данные");
                Console.ReadLine();
                return;
            }

            Console.WriteLine();
            var yield = GetYield(amount, rate, term);

            Console.WriteLine($"Итоговая сумма на счете: {yield:F2}");
            Console.WriteLine($"Прибыль составит: {yield - amount:F2}");
            Console.ReadLine();
        }

        public static double GetYield(double amount, double rate, double term)
        {
            var months = (int)Math.Floor(term);
            var percents = 1 + rate / 1200;
            var result = 1.0;

            for (int i = 0; i < months; ++i)
            {
                result *= percents;
            }

            return amount * result;
        }
    }
}
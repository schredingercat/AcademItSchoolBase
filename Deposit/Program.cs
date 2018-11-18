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
            var termInputIsCorrect = int.TryParse(Console.ReadLine(), out int term);

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

        public static double GetYield(double amount, double rate, int term)
        {
            const int monthsInYear = 12;
            const int hundredPercent = 100;

            var percents = 1 + rate / (monthsInYear * hundredPercent);
            var result = 1.0;

            for (int i = 0; i < term; ++i)
            {
                result *= percents;
            }

            return amount * result;
        }
    }
}
using System;
using System.Linq;

namespace NextDate
{
    class NextDate
    {
        private static readonly int[] Month30 = { 4, 6, 9, 11 };

        static void Main()
        {
            Console.WriteLine("Введите число");
            var dateInputIsValid = int.TryParse(Console.ReadLine(), out int date);

            Console.WriteLine("Введите месяц (числом)");
            var monthInputIsValid = int.TryParse(Console.ReadLine(), out int month);

            Console.WriteLine("Введите год");
            var yearInputIsValid = int.TryParse(Console.ReadLine(), out int year);

            if (!dateInputIsValid || !monthInputIsValid || !yearInputIsValid || !IsDateCorrect(date, month, year))
            {
                Console.WriteLine("Введены некорректные данные");
                Console.ReadLine();
                return;
            }

            if (date == 31
                || Month30.Contains(month) && date == 30
                || month == 2 && (date == 29 || !IsYearLeap(year) && date == 28))
            {
                date = 1;
                month++;
            }
            else
            {
                date++;
            }

            if (month == 13)
            {
                month = 1;
                year++;
            }

            Console.WriteLine($"Следующая дата: {date:D2}.{month:D2}.{year}");
            Console.ReadLine();
        }

        public static bool IsDateCorrect(int date, int month, int year)
        {
            if (date < 1 || date > 31 || month < 1 || month > 12 || year < 0)
            {
                return false;
            }

            if (date > 31
                || Month30.Contains(month) && date > 30
                || month == 2 && (date > 29 || !IsYearLeap(year) && date > 28))
            {
                return false;
            }

            return true;
        }

        public static bool IsYearLeap(int year)
        {
            return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        }
    }
}
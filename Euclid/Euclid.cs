using System;
using System.Globalization;

namespace Euclid
{
    class Euclid
    {
        static void Main()
        {
            Console.WriteLine("Введите первое число");
            bool numberAIsCorrect = int.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out int numberA);
            Console.WriteLine("Введите второе число");
            bool numberBIsCorrect = int.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out int numberB);

            if (!numberAIsCorrect || !numberBIsCorrect || numberA < 1 || numberB < 1)
            {
                Console.WriteLine("Введены некорректные данные");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"Наибольший общий делитель: {Nod(numberA, numberB)}");
            Console.ReadLine();
        }

        public static int Nod(int numberA, int numberB)
        {
            while (numberA != 0 && numberB != 0 && numberA % numberB != 0)
            {
                var temp = numberB;
                numberB = numberA % numberB;
                numberA = temp;
            }
            return numberB;
        }
    }
}
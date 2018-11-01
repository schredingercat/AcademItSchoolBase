using System;
using System.Collections.Generic;

namespace Apartments
{
    class Apartments
    {
        private static readonly Dictionary<int, string> ApartmentPositions = new Dictionary<int, string>
        {
            [1] = "ближняя слева",
            [2] = "дальняя слева",
            [3] = "дальняя справа",
            [4] = "ближняя справа"
        };

        const int ApartmentsInFloorCount = 4;

        static void Main()
        {
            Console.WriteLine("Введите количество этажей");
            var floorsInputIsValid = int.TryParse(Console.ReadLine(), out int floorsCount);

            Console.WriteLine("Введите количество подъездов");
            var sectionsInputIsValid = int.TryParse(Console.ReadLine(), out int sectionsCount);

            Console.WriteLine("Введите номер квартиры");
            var apartmentInputIsValid = int.TryParse(Console.ReadLine(), out int apartmentNumber);

            if (!floorsInputIsValid || !sectionsInputIsValid || !apartmentInputIsValid || floorsCount <= 0 || sectionsCount <= 0 || apartmentNumber <= 0)
            {
                Console.WriteLine("Введены некорректные данные");
                Console.ReadLine();
                return;
            }

            if (apartmentNumber > ApartmentsInFloorCount * floorsCount * sectionsCount)
            {
                Console.WriteLine("В доме нет такой квартиры");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"Квартира в {FindSection(floorsCount, apartmentNumber)} подъезде " +
                              $"на {FindFloor(floorsCount, apartmentNumber)} этаже, {FindPosition(apartmentNumber)}");
            Console.ReadLine();
        }

        private static int FindSection(int floorsCount, int apartmentNumber)
        {
            return (apartmentNumber - 1) / (floorsCount * ApartmentsInFloorCount) + 1;
        }

        private static int FindFloor(int floorsCount, int apartmentNumber)
        {
            return (apartmentNumber - 1) % (floorsCount * ApartmentsInFloorCount) / ApartmentsInFloorCount + 1;
        }

        private static string FindPosition(int apartmentNumber)
        {
            return ApartmentPositions[(apartmentNumber - 1) % ApartmentsInFloorCount + 1];
        }
    }
}
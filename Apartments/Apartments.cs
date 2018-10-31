using System;
using System.Collections.Generic;

namespace Apartments
{
    class Apartments
    {
        const int ApartmentsInFloor = 4;

        static void Main()
        {
            Console.WriteLine("Введите количество этажей");
            var floorInputIsValid = int.TryParse(Console.ReadLine(), out int floorNumber);

            Console.WriteLine("Введите количество подъездов");
            var sectionInputIsValid = int.TryParse(Console.ReadLine(), out int sectionNumber);

            Console.WriteLine("Введите номер квартиры");
            var apartmentInputIsValid = int.TryParse(Console.ReadLine(), out int apartmentId);

            if (!floorInputIsValid || !sectionInputIsValid || !apartmentInputIsValid || floorNumber <= 0 || sectionNumber <= 0 || apartmentId <= 0)
            {
                Console.WriteLine("Введены некорректные данные");
                Console.ReadLine();
                return;
            }

            if (apartmentId > ApartmentsInFloor * floorNumber * sectionNumber)
            {
                Console.WriteLine("В доме нет такой квартиры");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"Квартира в {FindSection(floorNumber, apartmentId)} подъезде на {FindFloor(floorNumber, apartmentId)} этаже, {FindPosition(apartmentId)}");
            Console.ReadLine();
        }

        private static int FindSection(int floorNumber, int apartmentId)
        {
            return (apartmentId - 1) / (floorNumber * ApartmentsInFloor) + 1;
        }

        private static int FindFloor(int floorNumber, int apartmentId)
        {
            return (apartmentId - 1) % (floorNumber * ApartmentsInFloor) / ApartmentsInFloor + 1;
        }

        private static string FindPosition(int apartmentId)
        {
            return ApartmentPositions[(apartmentId - 1) % ApartmentsInFloor + 1];
        }

        private static readonly Dictionary<int, string> ApartmentPositions = new Dictionary<int, string>()
        {
            [1] = "ближняя слева",
            [2] = "дальняя слева",
            [3] = "дальняя справа",
            [4] = "ближняя справа"
        };
    }
}
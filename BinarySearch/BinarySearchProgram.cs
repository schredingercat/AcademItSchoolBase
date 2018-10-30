using System;

namespace BinarySearch
{
    class BinarySearchProgram
    {
        static void Main()
        {
            var array = new[] { 4, 8, 15, 16, 23, 42 };
            var x = 16;

            Console.WriteLine($"Массив: {string.Join(", ", array)}");

            Console.WriteLine();
            Console.WriteLine($"Бинарный поиск {x} с рекурсией:  {Search.BinarySearch(array, 0, array.Length - 1, x)}");
            Console.WriteLine($"Бинарный поиск {x} без рекурсии: {Search.BinarySearchWithoutRecurse(array, x)}");

            Console.WriteLine();
            Console.WriteLine($"Бинарный поиск {19} с рекурсией:  {Search.BinarySearch(array, 0, array.Length - 1, 19)}");
            Console.WriteLine($"Бинарный поиск {108} без рекурсии: {Search.BinarySearchWithoutRecurse(array, 108)}");
            Console.ReadLine();
        }
    }
}

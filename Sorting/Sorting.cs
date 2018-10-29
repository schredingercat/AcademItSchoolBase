using System;

namespace Sorting
{
    class Sorting
    {
        static void Main()
        {
            var array = CreateRandomArray(24);

            var array1 = (int[])array.Clone();
            var array2 = (int[])array.Clone();
            var array3 = (int[])array.Clone();
            var array4 = (int[])array.Clone();

            Console.WriteLine($"Оригинальный массив:  {string.Join(", ", array)}");
            Console.WriteLine();

            Sort.SortSelect(array1);
            Console.WriteLine($"Сортировка выбором:   {string.Join(", ", array1)}");

            Sort.SortBubble(array2);
            Console.WriteLine($"Сортировка пузырьком: {string.Join(", ", array2)}");

            Sort.SortInsert(array3);
            Console.WriteLine($"Сортировка вставками: {string.Join(", ", array3)}");

            Sort.SortQuick(array4);
            Console.WriteLine($"Быстрая сортировка:   {string.Join(", ", array4)}");

            Console.ReadLine();
        }

        public static int[] CreateRandomArray(int size)
        {
            var array = new int[size];

            var random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(100);
            }

            return array;
        }
    }
}
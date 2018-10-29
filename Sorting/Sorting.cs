using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Sorting
    {
        static void Main(string[] args)
        {
            var array = new int[10];

            var random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(100);
            }

            Console.WriteLine($"Начальный массив: {string.Join(", ", array)}");

            
            //Sort.SortSelect(array);
            //Console.WriteLine($"Сортировка выбором: {string.Join(", ", array)}");

            //Sort.SortBubble(array);
            //Console.WriteLine($"Сортировка пузырьком: {string.Join(", ", array)}");

            //Sort.SortInsert(array);
            //Console.WriteLine($"Сортировка вставками: {string.Join(", ", array)}");

            Sort.SortQuick(array, 0, array.Length-1);
            Console.WriteLine($"Быстрая сортировка: {string.Join(", ", array)}");



            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Sorting
    {
        static void Main(string[] args)
        {
            var array = new int[10000];

            var random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(100);
            }

            var array1 = (int[])array.Clone();
            var array2 = (int[])array.Clone();
            var array3 = (int[])array.Clone();
            var array4 = (int[])array.Clone();
            var array5 = (int[])array.Clone();

            var timer = new Stopwatch();
            
            //Console.WriteLine($"Оригинальный массив: {string.Join(", ", array)}");

            timer.Start();
            Sort.SortSelect(array1);
            timer.Stop();
            Console.WriteLine($"Сортировка выбором. Время: {timer.Elapsed}");

            timer.Restart();
            Sort.SortBubble(array2);
            timer.Stop();
            Console.WriteLine($"Сортировка пузырьком. Время: {timer.Elapsed}");

            timer.Restart();
            Sort.SortInsert(array3);
            timer.Stop();
            Console.WriteLine($"Сортировка вставками. Время: {timer.Elapsed}");

            timer.Restart();
            Sort.SortQuick(array4, 0, array.Length-1);
            timer.Stop();
            Console.WriteLine($"Быстрая сортировка. Время: {timer.Elapsed}");
            //Console.WriteLine($"Быстрая сортировка {string.Join(", ", array4)}");

            timer.Restart();
            Array.Sort(array5);
            timer.Stop();
            Console.WriteLine($"Стандартная сортировка. Время: {timer.Elapsed}");


            Console.ReadLine();
        }
    }
}

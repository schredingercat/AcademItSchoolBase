using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Sort
    {

        public static void SelectSort(int[] input)
        {
            var length = input.Length;
            for (int i = 0; i < length; i++)
            {
                var minIndex = FindMinIndex(input, i);
                var temp = input[minIndex];
                input[minIndex] = input[i];
                input[i] = temp;
            }
        }

        public static int FindMinIndex(int[] input, int startIndex)
        {
            var minIndex = startIndex;
            var min = input[startIndex];
            var length = input.Length;

            for (int i = startIndex; i < length; i++)
            {
                if (input[i] < min)
                {
                    min = input[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }

    }
}

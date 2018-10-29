using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Sort
    {

        public static void SortSelect(int[] input)
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

        public static void SortBubble(int[] input)
        {
            var length = input.Length - 1;
            for (int i = 0; i < length; i++)
            {
                var isSorted = true;
                for (int j = 0; j < length; j++)
                {
                    if (input[j] > input[j + 1])
                    {
                        var temp = input[j + 1];
                        input[j + 1] = input[j];
                        input[j] = temp;
                        isSorted = false;
                    }
                }

                if (isSorted)
                {
                    return;
                }
            }
        }

        public static void SortInsert(int[] input)
        {
            var length = input.Length;

            for (int i = 1; i < length; i++)
            {
                var temp = input[i];
                var j = i - 1;
                while (j >= 0 && temp < input[j])
                {
                    input[j + 1] = input[j];
                    j--;
                }
                input[j + 1] = temp;
            }
        }

        public static void SortQuick(int[] input, int left, int right)
        {
            if (left == right)
            {
                return;
            }

            if (right - left == 1 && input[right] < input[left])
            {
                var temp = input[left];
                input[left] = input[right];
                input[right] = temp;
                return;
            }

            var i = left;
            var j = right;
            var basic = input[(left + right) / 2];

            while (i < j)
            {
                for (; i <= right; i++)
                {
                    if (input[i] >= basic)
                    {
                        break;
                    }
                }

                for (; j >= left; j--)
                {
                    if (input[j] <= basic)
                    {
                        break;
                    }
                }

                if (i <= j)
                {
                    var temp = input[j];
                    input[j] = input[i];
                    input[i] = temp;
                    i++;
                    j--;
                }
                else
                {
                    break;
                }
            }

            if (i < right)
            {
                SortQuick(input, i, right);
            }

            if (j > left)
            {
                SortQuick(input, left, j);
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

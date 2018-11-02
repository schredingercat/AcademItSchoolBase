namespace Sorting
{
    class Sort
    {
        public static void SortSelect(int[] input)
        {
            var length = input.Length;
            if (length <= 1)
            {
                return;
            }

            for (var i = 0; i < length - 1; i++)
            {
                var minIndex = i;
                var min = input[i];

                for (var j = i; j < length; j++)
                {
                    if (input[j] < min)
                    {
                        min = input[j];
                        minIndex = j;
                    }
                }

                var temp = input[minIndex];
                input[minIndex] = input[i];
                input[i] = temp;
            }
        }

        public static void SortBubble(int[] input)
        {
            if (input.Length <= 1)
            {
                return;
            }
            var length = input.Length - 1;

            for (var i = 0; i < length; i++)
            {
                var isSorted = true;
                for (var j = 0; j < length; j++)
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

            if (length <= 1)
            {
                return;
            }

            for (var i = 1; i < length; i++)
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

        public static void SortQuick(int[] input)
        {
            if (input.Length <= 1)
            {
                return;
            }

            SortQuick(input, 0, input.Length - 1);
        }

        public static void SortQuick(int[] input, int left, int right)
        {
            if (left == right)
            {
                return;
            }

            if (right - left == 1)
            {
                if (input[right] < input[left])
                {
                    var temp = input[left];
                    input[left] = input[right];
                    input[right] = temp;
                    return;
                }
                return;
            }

            var i = left;
            var j = right;
            var basic = input[(left + right) / 2];

            while (true)
            {
                for (; i < right; i++)
                {
                    if (input[i] >= basic)
                    {
                        break;
                    }
                }

                for (; j > left; j--)
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

        public static void SortPyramid(int[] input)
        {
            var length = input.Length;

            for (int i = length / 2 - 1; i >= 0; i--)
            {
                ShiftItem(input, i);
            }

            for (int i = 0; i < length; i++)
            {
                var temp = input[0];
                input[0] = input[length - 1 - i];
                input[length - 1 - i] = temp;
                ShiftItem(input, 0, i + 1);
            }
        }

        public static void ShiftItem(int[] input, int index, int sortedLength = 0)
        {
            var length = input.Length - sortedLength;
            while (true)
            {
                if (index >= length)
                {
                    return;
                }

                var child1Index = 2 * index + 1;
                var child2Index = 2 * index + 2;
                int maxChildIndex;

                if (child2Index >= length)
                {
                    if (child1Index < length)
                    {
                        maxChildIndex = child1Index;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    maxChildIndex = (input[child1Index] >= input[child2Index]) ? child1Index : child2Index;
                }

                if (input[index] < input[maxChildIndex])
                {
                    var temp = input[maxChildIndex];
                    input[maxChildIndex] = input[index];
                    input[index] = temp;
                    index = maxChildIndex;
                    continue;
                }
                break;
            }
        }
    }
}
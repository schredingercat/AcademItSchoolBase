namespace BinarySearch
{
    class Search
    {
        public static int BinarySearch(int[] array, int left, int right, int x)
        {
            if (left > right)
            {
                return -1;
            }

            var middle = (right + left) / 2;

            if (array[middle] == x)
            {
                return middle;
            }
            if (array[middle] > x)
            {
                right = middle - 1;
            }
            else
            {
                left = middle + 1;
            }

            return BinarySearch(array, left, right, x);
        }

        public static int BinarySearchWithoutRecurse(int[] array, int x)
        {
            var left = 0;
            var right = array.Length - 1;
            if (left > right)
            {
                return -1;
            }

            while (left <= right)
            {
                var middle = (right + left) / 2;

                if (array[middle] == x)
                {
                    return middle;
                }
                if (array[middle] > x)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }
            return -1;
        }
    }
}
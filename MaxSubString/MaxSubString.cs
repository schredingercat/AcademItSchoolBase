using System;

namespace MaxSubstring
{
    class MaxSubstring
    {
        static void Main()
        {
            Console.WriteLine("Введите строку для поиска");
            var output = GetMaxSubstring(Console.ReadLine());

            Console.WriteLine($"Максимум одинаковых символов подряд: {output}");
            Console.ReadLine();
        }

        private static double GetMaxSubstring(string input)
        {
            if (input.Length <= 1)
            {
                return input.Length;
            }

            var lowercaseString = input.ToLower();
            var substringLength = 1;
            var maxSubstringLength = 0;

            for (var i = 1; i < input.Length; i++)
            {
                substringLength = (lowercaseString[i] == lowercaseString[i - 1]) ? ++substringLength : 1;

                if (substringLength > maxSubstringLength)
                {
                    maxSubstringLength = substringLength;
                }
            }

            return maxSubstringLength;
        }
    }
}
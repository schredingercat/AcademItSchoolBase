using System;

namespace Palindrome
{
    class Palindrome
    {
        static void Main()
        {
            var input1 = "Аргентина манит негра";
            var input2 = "Купи кипу пик";

            Console.WriteLine($"Строка \"{input1}\", {(IsPalindrome(input1) ? "является" : "не является")} палиндромом");
            Console.WriteLine($"Строка \"{input2}\", {(IsPalindrome(input2) ? "является" : "не является")} палиндромом");
            Console.ReadLine();
        }

        public static bool IsPalindrome(string input)
        {
            var length = input.Length;
            var inputLowered = input.ToLower();
            var lastIndexForward = 0;
            var lastIndexBackward = length;

            for (int i = 0; i < length / 2; i++)
            {
                if (GetLetterByIndexForward(inputLowered, i, lastIndexForward, out lastIndexForward)
                    != GetLetterByIndexBackward(inputLowered, i, lastIndexBackward, out lastIndexBackward))
                {
                    return false;
                }
            }
            return true;
        }

        public static char GetLetterByIndexForward(string input, int index, int lastIndex, out int outLastIndex)
        {
            outLastIndex = lastIndex;
            if (index < 0 || index > input.Length)
            {
                return char.MinValue;
            }

            var letterNumber = index;

            for (int i = lastIndex; i < input.Length; i++)
            {
                if (!char.IsLetter(input[i]))
                {
                    continue;
                }

                if (letterNumber == index)
                {
                    outLastIndex = i + 1;
                    return input[i];
                }

                letterNumber++;
            }

            return char.MinValue;
        }

        public static char GetLetterByIndexBackward(string input, int index, int lastIndex, out int outLastIndex)
        {
            outLastIndex = lastIndex;
            if (index < 0 || index > input.Length)
            {
                return char.MinValue;
            }

            var letterNumber = index;

            for (int i = lastIndex - 1; i >= 0; i--)
            {
                if (!char.IsLetter(input[i]))
                {
                    continue;
                }

                if (letterNumber == index)
                {
                    outLastIndex = i;
                    return input[i];
                }

                letterNumber++;
            }

            return char.MinValue;
        }
    }
}
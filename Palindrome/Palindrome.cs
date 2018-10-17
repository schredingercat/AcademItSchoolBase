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
            var inputLowered = input.ToLower();
            for (int i = 0; i < input.Length; i++)
            {
                if (GetLetterByIndexForward(inputLowered, i) != GetLetterByIndexBackward(inputLowered, i))
                {
                    return false;
                }
            }
            return true;
        }

        public static char GetLetterByIndexForward(string input, int index)
        {
            if (index < 0 || index > input.Length)
            {
                return char.MinValue;
            }

            var letterNumber = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsLetter(input[i]))
                {
                    continue;
                }

                if (letterNumber == index)
                {
                    return input[i];
                }

                letterNumber++;
            }

            return char.MinValue;
        }

        public static char GetLetterByIndexBackward(string input, int index)
        {
            if (index < 0 || index > input.Length)
            {
                return char.MinValue;
            }

            var letterNumber = 0;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (!char.IsLetter(input[i]))
                {
                    continue;
                }

                if (letterNumber == index)
                {
                    return input[i];
                }

                letterNumber++;
            }

            return char.MinValue;
        }
    }
}
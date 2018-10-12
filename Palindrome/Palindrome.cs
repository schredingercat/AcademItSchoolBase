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
            for (int i = 0; i < input.Length; i++)
            {
                if (GetNonSpaceSymbolByIndex(input.ToLower(), i) != GetNonSpaceSymbolByIndex(input.ToLower(), i, true))
                {
                    return false;
                }
            }
            return true;
        }

        public static string GetNonSpaceSymbolByIndex(string input, int index, bool backwards = false)
        {
            if (index < 0 || index > input.Length)
            {
                return null;
            }

            var nonSpaceCharNumber = 0;

            if (!backwards)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (char.IsWhiteSpace(input[i]))
                    {
                        continue;
                    }

                    if (nonSpaceCharNumber++ == index)
                    {
                        return input[i].ToString();
                    }
                }
            }
            else
            {
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    if (char.IsWhiteSpace(input[i]))
                    {
                        continue;
                    }

                    if (nonSpaceCharNumber++ == index)
                    {
                        return input[i].ToString();
                    }
                }
            }

            return null;
        }

    }
}
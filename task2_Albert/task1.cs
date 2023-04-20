using System;
using System.Linq;

namespace PalindromeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();
            
            // Split the string into words and remove any hyphens
            string[] words = input.Split(' ').Select(w => w.Replace("-", "")).ToArray();

            Console.WriteLine("Output:");
            foreach (string word in words)
            {
                // Convert the word to lowercase for case-insensitive comparison
                string lowercaseWord = word.ToLower();

                // Check if the word is a palindrome
                bool isPalindrome = true;
                for (int i = 0; i < lowercaseWord.Length / 2; i++)
                {
                    if (lowercaseWord[i] != lowercaseWord[lowercaseWord.Length - i - 1])
                    {
                        isPalindrome = false;
                        break;
                    }
                }

                // Output the result
                Console.WriteLine($"{word} - {(isPalindrome ? "palindrome" : "not palindrome")}");
            }

            Console.ReadLine();
        }
    }
}

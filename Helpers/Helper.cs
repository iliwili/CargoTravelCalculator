using System;
using System.Text.RegularExpressions;

namespace CargoTravelCalculator.Helpers
{
    public class Helper
    {
        public static Regex SequenceRegex = new Regex(@"^((?![c-zC-Z]).)*$");

        public static int ReadIntWithCondition(string placeholder)
        {
            int output;

            Console.Write($"{placeholder}: ");
            string input = Console.ReadLine();
            while (!int.TryParse(input, out output) || output <= 0)
            {
                WriteColorLine($"{placeholder} should be a digit higher than zero!\n", ConsoleColor.Red);

                Console.Write($"Try again, {placeholder}: ");
                input = Console.ReadLine();
            }
            return output;
        }

        public static string ReadStringWithCondition(string placeholder, string errorText, Func<string, bool> condition)
        {
            Console.Write($"{placeholder}: ");
            string input = Console.ReadLine();
            while (condition(input) || input == "")
            {
                WriteColorLine($"The {placeholder[0].ToString().ToLower()}{placeholder.Substring(1)} you gave {(placeholder[^1] == 's' ? "are" : "is")} incorrect, ({errorText})!\n", ConsoleColor.Red);

                Console.Write($"{placeholder}: ");
                input = Console.ReadLine();
            }

            return input;
        }

        public static void WriteColorLine(string text, ConsoleColor color, bool newLine = true)
        {
            Console.ForegroundColor = color;
            if (newLine)
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.Write(text);
            }
            Console.ResetColor();
        }
    }
}
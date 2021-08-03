using System;
using System.Text.RegularExpressions;

namespace CargoTravelCalculator.Helpers
{
    /// <summary>
    /// This is a helper class with commonly used variables and methods.
    /// </summary>
    public class Helper
    {
        public static readonly Regex SequenceRegex = new Regex(@"^((?![c-zC-Z]).)*$");

        /// <summary>
        /// This method asks a question and expects only an int as answer.
        /// </summary>
        /// <param name="placeholder">
        /// The placeholder for the question and error text.
        /// </param>
        /// <returns>
        /// Return the answer if it passed the condition.
        /// </returns>
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

        /// <summary>
        /// This methods asks a question and the answer is only given when is passes the condition.
        /// </summary>
        /// <param name="placeholder">
        /// The placeholder for the question.
        /// </param>
        /// <param name="errorText">
        /// The placeholder when the condition is not met.
        /// </param>
        /// <param name="condition">
        /// The condition the answer should pass.
        /// </param>
        /// <returns>
        /// Returns the answer if it passed the condition.
        /// </returns>
        public static string ReadStringWithCondition(string placeholder, string errorText, Func<string, bool> condition)
        {
            Console.Write($"{placeholder}: ");
            string input = Console.ReadLine();
            while (condition(input) || input == "")
            {
                WriteColorLine($"The {placeholder[0].ToString().ToLower()}{placeholder[1..]} you gave {(placeholder[^1] == 's' ? "are" : "is")} incorrect, ({errorText})!\n", ConsoleColor.Red);

                Console.Write($"{placeholder}: ");
                input = Console.ReadLine();
            }

            return input;
        }

        /// <summary>
        /// The methods writes a line in the console in a chosen color.
        /// </summary>
        /// <param name="text">
        /// The text that should be shown in the console.
        /// </param>
        /// <param name="color">
        /// The color of the text.
        /// </param>
        /// <param name="newLine">
        /// If the text should be shown on a new line.
        /// </param>
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
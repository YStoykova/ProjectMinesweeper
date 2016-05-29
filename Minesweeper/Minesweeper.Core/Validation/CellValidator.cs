using System.Text.RegularExpressions;

namespace Minesweeper.Core
{
    public class CellValidator
    {
        /// <summary>
        /// Valid mine pattern.
        /// </summary>
        private const string validMinePattern = @"\*";

        /// <summary>
        /// Valid safe sign.
        /// </summary>
        private const string validSafeSignPattern = @"\.";

        /// <summary>
        /// Valid mine sign. 
        /// </summary>
        public const char validMineChar = '*';

        /// <summary>
        /// The valid safe character
        /// </summary>
        public const char validSafeChar = '.';
        /// <summary>
        /// Returns a boolean indicating whether the current cell has a mine.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool isMine(string input)
        {
            Regex regex = new Regex(validMinePattern, RegexOptions.Singleline);
            return regex.IsMatch(input);
        }

        /// <summary>
        /// Returns a boolean indicating whether the current cell has a safe.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool isSafe(string input)
        {
            Regex regex = new Regex(validSafeSignPattern, RegexOptions.Singleline);
            return regex.IsMatch(input);
        }

        /// <summary>
        /// Determines whether [is valid minefield cell] [the specified text].
        /// </summary>
        /// <param name="text">The cell text.</param>
        /// <returns></returns>
        public static bool isMineOrSafe(string text)
        {
            return ((isMine(text)) || (isSafe(text)));
        }
    }
}


using System.Text.RegularExpressions;
namespace Minesweeper.Core
{
    public static class ValidationRule
    {
        /// <summary>
        /// Valid first row of each Minefield.
        /// </summary>
        public const string headerMinefield = @"^([1-9][0-9]{0,1}(\.[\d]{1,2})?|100) ([1-9][0-9]{0,1}(\.[\d]{1,2})?|100)$";
        /// <summary>
        /// Valid last user input
        /// </summary>
        public const string footerMinefield = @"^([0]) ([0])";
        /// <summary>
        /// Valid mine pattern.
        /// </summary>
        public const string validMine = @"\*";
        /// <summary>
        /// Valid safe sign.
        /// </summary>
        public const string validSafeSign = @"\.";
        /// <summary>
        /// Valid mine sign. 
        /// </summary>
        public const char validMineChar = '*';

        /// <summary>
        /// Display the header of output minefield
        /// </summary>
        public const string headerOutput = "Field #{0}:";

        /// <summary>
        /// Returns a boolean indicating whether the current row is input header.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsHeader(string input)       
        {
            Regex regex = new Regex(ValidationRule.headerMinefield, RegexOptions.Singleline);
            return regex.IsMatch(input);
        }

        /// <summary>
        /// Returns a boolean indicating whether the current row is input footer.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool isFooter(string input)
        {
            Regex regex = new Regex(ValidationRule.footerMinefield, RegexOptions.Singleline);
            return regex.IsMatch(input);
        }

        /// <summary>
        /// Returns a boolean indicating whether the current cell has a mine.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool isMine(string input)
        {
            Regex regex = new Regex(ValidationRule.validMine, RegexOptions.Singleline);
            return regex.IsMatch(input);
        }

        /// <summary>
        /// Returns a boolean indicating whether the current cell has a safe.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool isSafe(string input)
        {
            Regex regex = new Regex(ValidationRule.validSafeSign, RegexOptions.Singleline);
            return regex.IsMatch(input);
        }
    }
}

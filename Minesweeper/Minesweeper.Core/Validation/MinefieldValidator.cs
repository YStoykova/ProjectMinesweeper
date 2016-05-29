using System.Text.RegularExpressions;

namespace Minesweeper.Core
{
    public class MinefieldValidator
    {
        /// <summary>
        /// Valid first row of each Minefield.
        /// </summary>
        private const string headerMinefieldPattern = @"^([1-9][0-9]{0,1}(\.[\d]{1,2})?|100) ([1-9][0-9]{0,1}(\.[\d]{1,2})?|100)$";

        /// <summary>
        /// Valid last user input
        /// </summary>
        private const string footerMinefieldPattern = @"^([0]) ([0])";

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
            Regex regex = new Regex(headerMinefieldPattern, RegexOptions.Singleline);
            return regex.IsMatch(input);
        }

        /// <summary>
        /// Returns a boolean indicating whether the current row is input footer.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool isFooter(string input)
        {
            Regex regex = new Regex(footerMinefieldPattern, RegexOptions.Singleline);
            return regex.IsMatch(input);
        }

        /// <summary>
        /// Validates the cell count in the minefield.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <returns></returns>
        public static bool isValidCellCount(int cellsCount, int rows, int columns)
        {
            return cellsCount == rows * columns;
        }
    }
}

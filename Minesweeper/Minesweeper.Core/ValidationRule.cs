
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
        /// Valid mine sign. 
        /// </summary>
        public const char validMineSign = '*';
        /// <summary>
        /// Valid safe sign.
        /// </summary>
        public const char validSafeSign = '.';
    }
}

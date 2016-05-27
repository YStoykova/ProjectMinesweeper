namespace Minesweeper.Core
{
    public class Cell : ICell
    {
        /// <summary>
        /// A boolean flag indicating if the current cell is mined.
        /// </summary>
        public bool IsMined { get; set; }
        /// <summary>
        /// The character of the current cell.
        /// </summary>
        public char Text { get; set; }

        /// <summary>
        /// Create a cell.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static ICell Create(char c)
        {
            Cell cell = new Cell();
            cell.Text = c;
            if (c == ValidationRule.validMineChar)
            {
                cell.IsMined = true;
            }
            return cell;        
        }
    }
}

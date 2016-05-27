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
    }
}

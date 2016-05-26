using System;
namespace Minesweeper.Core
{
    public interface ICell
    {
        /// <summary>
        /// Gets or sets value for text by cell.
        /// </summary>
        /// <value>Position by row.</value>
        char Text { get; set; }
        bool IsMined { get; set; }
    }
}

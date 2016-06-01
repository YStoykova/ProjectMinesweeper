using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class CellFactory
    {
        /// <summary>
        /// Creates the minefield cell.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns></returns>
        public static Cell Create(char c)
        {
            Cell cell = new Cell() { Text = c, IsMined = CellValidator.isMine(c.ToString()) };       
            return cell;        
        }
    }
}

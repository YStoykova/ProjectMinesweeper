using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core
{
    /// <summary>
    /// Implements the Factory pattern to create new cell
    /// </summary>
    public class CellFactory
    {
        public static Cell Create(char c)
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

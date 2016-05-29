using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Minesweeper.Core
{
    public class MinesweeperConverter
    {
        /// <summary>
        /// The output result.
        /// </summary>
        public StringBuilder output = new StringBuilder();

        /// <summary>
        /// Convert minefields array to result type array.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="neighborMines"></param>
        public void ConvertMinefield(Minefield field)
        {
            //returns a two dimensional array defines neighbor mines
            int[,] neighborMines = field.CalculateNeighborMines();

            //returns a two dimensional array defines cell type - mine or number
            var result = field.ConvertToResult<ICell, CellResult>(field.Cells, field.ColumnsCount, c => field.ConvertCellToTypeResult(c));

            for (int row = 0; row < result.GetLength(0); row++)
            {
                for (int column = 0; column < result.GetLength(1); column++)
                {
                    string text = string.Empty;
                    var symbolType = result[row, column];
                    if (symbolType == CellResult.Number)
                    {
                        int number = neighborMines[row, column];
                        text = number.ToString();
                    }
                    else if (symbolType == CellResult.Mine)
                    {
                        text = CellValidator.validMineChar.ToString();
                    }
                    output.Append(text);
                }
                output.Append(Environment.NewLine);
            }
        } 
    }
}

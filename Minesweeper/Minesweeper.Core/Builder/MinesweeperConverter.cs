using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Minesweeper.Core
{
    public class MinesweeperConverter
    {
        public string output;

        /// <summary>
        /// Convert minefields array to result type array.
        /// </summary>
        /// <param name="minefield"></param>
        /// <param name="neighborMines"></param>
        public void ConvertMinefield(CellResult[,] minefield, int[,] neighborMines)
        {
            for (int row = 0; row < minefield.GetLength(0); row++)
            {
                for (int col = 0; col < minefield.GetLength(1); col++)
                {
                    string symbol;
                    var symbolType = minefield[row, col];
                    if (symbolType == CellResult.Number)
                    {
                        int num = neighborMines[row, col];
                        symbol = num.ToString();
                    }
                    else
                    {
                        symbol = this.results[symbolType];
                    }
                    output += symbol;
                }
                output += Environment.NewLine;
            }
        }     

        private readonly IReadOnlyDictionary<CellResult, string> results = new ReadOnlyDictionary<CellResult, string>(
           new Dictionary<CellResult, string>()
            {
                { CellResult.Mine, "*" },
            });

    }
}

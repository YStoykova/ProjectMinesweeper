using Minesweeper.Core;
using System;
using System.Collections.Generic;

namespace ConsoleMinesweeper
{
    public class MinefieldDrawer
    {
        private readonly IRenderer renderer;

        public MinefieldDrawer(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        /// <summary>
        /// Returns the list of minefields
        /// </summary>
        /// <param name="minefields"></param>
        public void DrawMinefields(List<Minefield> minefields)
        {
            foreach (Minefield field in minefields)
            {
                int[,] neighborMines = field.CalculateNeighborMines();
                var result = field.ConvertMinefield(field);
                DrawMinefield(field.Id, result, neighborMines);
            }
        }

        /// <summary>
        /// Returns the minefield
        /// </summary>
        /// <param name="id"></param>
        /// <param name="result"></param>
        /// <param name="neighborMines"></param>
        public void DrawMinefield(int id, CellResult[,] result, int[,] neighborMines)
        {
            if (result.GetLength(0) != neighborMines.GetLength(0) ||
                result.GetLength(1) != neighborMines.GetLength(1))
            {
                throw new ArgumentException("Matrices dimensions are not equal!");
            }

            MinesweeperConverter converter = new MinesweeperConverter();
            converter.ConvertMinefield(result, neighborMines);

            this.renderer.WriteLine(String.Format(ValidationRule.headerOutput, id));
            this.renderer.Write(converter.output);
            this.renderer.WriteLine();
        }     
    }
}

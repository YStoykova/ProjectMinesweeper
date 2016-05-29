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
                DrawMinefield(field);
            }
        }

        /// <summary>
        /// Returns the minefield
        /// </summary>
        /// <param name="id"></param>
        /// <param name="result"></param>
        /// <param name="neighborMines"></param>
        public void DrawMinefield(Minefield field)
        {
            MinesweeperConverter converter = new MinesweeperConverter();
            converter.ConvertMinefield(field);

            this.renderer.WriteLine(String.Format(MinefieldValidator.headerOutput, field.Id));
            this.renderer.Write(converter.output.ToString());
            this.renderer.WriteLine();
        }
    }
}

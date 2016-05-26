using Minesweeper.Core;

namespace ConsoleMinesweeper
{
    public class MinefieldDrawer
    {
        private readonly IRenderer renderer;

        public MinefieldDrawer(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public void DrawField(CellResult[,] minefield, int[,] neighborMines)
        {
            MinesweeperConverter converter = new MinesweeperConverter();
            converter.ConvertMinefield(minefield, neighborMines);
            this.renderer.Write(converter.output);
        }
    }
}

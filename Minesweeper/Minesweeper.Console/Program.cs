using Minesweeper.Core;
using System.Collections.Generic;

namespace ConsoleMinesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            UIManager consoleUIManager = new UIManager(new ConsoleRenderer(), new ConsoleReader());

            Minesweeper game = new Minesweeper(consoleUIManager);

            bool gameRunning = true;
            while (gameRunning)
            {
                consoleUIManager.DisplayResult();

                gameRunning = consoleUIManager.Continue();
            }
            game.ExitGame();
        }
    }
}

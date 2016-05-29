using Minesweeper.Core;
using System.Collections.Generic;

namespace ConsoleMinesweeper
{
    class Program
    {
        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
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

using Minesweeper.Core;

namespace ConsoleMinesweeper
{
    public class Minesweeper
    {
        private readonly UIManager uiManager;

        public Minesweeper(UIManager uiManager)
        {
            this.uiManager = uiManager;
            this.uiManager.DisplayIntro(Messages.Intro);
        }

        /// <summary>
        /// Exit of the game
        /// </summary>
        public void ExitGame()
        {
            this.uiManager.GoodBye(Messages.Bye);
        }
    }
}

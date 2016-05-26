using Minesweeper.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

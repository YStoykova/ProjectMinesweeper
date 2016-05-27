using Minesweeper.Core;
using System;
using System.Collections.Generic;

namespace ConsoleMinesweeper
{
    public class UIManager
    {
        /// <summary>The drawer which handles drawing of the game console.</summary>
        private readonly MinefieldDrawer fieldDrawer;

        /// <summary>The renderer used by the application.</summary>
        private IRenderer renderer;
        private IRenderer Renderer
        {
            get
            {
                return this.renderer;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Reference for renderer instance cannot be null!");
                }

                this.renderer = value;
            }
        }

        /// <summary>The user input reader.</summary>
        private IUserInputReader inputReader;
        private IUserInputReader InputReader
        {
            get
            {
                return this.inputReader;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Reference for input reader instance cannot be null!");
                }

                this.inputReader = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UIManager"/> class with default ConsoleRenderer and ConsoleReader.
        /// </summary>
        public UIManager()
            : this(new ConsoleRenderer(), new ConsoleReader())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UIManager"/> class.
        /// </summary>
        /// <param name="renderer">The renderer which is going to be used by the UIManager.</param>
        /// <param name="inputReader">The input reader which UIManager is going to use.</param>
        public UIManager(IRenderer renderer, IUserInputReader inputReader)
        {
            this.Renderer = renderer;
            this.InputReader = inputReader;

            this.fieldDrawer = new MinefieldDrawer(renderer);
        }

        /// <summary>
        /// Displays the introduction text of the game.
        /// </summary>
        /// <param name="msg">The introduction message.</param>
        public void DisplayIntro(string msg)
        {
            this.ValidateMessage(msg);
            this.Renderer.Write(msg);
        }

        /// <summary>
        /// Displays the result of the game.
        /// </summary>
        public void DisplayResult()
        {
            List<Minefield> minefields = new List<Minefield>();
            Minefield minefield = null;

            string input;
            do
            {
                input = this.InputReader.ReadLine();

                if (ValidationRule.IsHeader(input))
                {
                    minefield = new Minefield().Create(minefields.Count + 1, input);
                    minefields.Add(minefield);
                }
                else if (ValidationRule.isFooter(input))
                {
                    break;
                }
                else
                {
                    foreach (char c in input.ToCharArray())
                    {
                        if ((ValidationRule.isMine(c.ToString()) )|| (ValidationRule.isSafe(c.ToString())))
                        {
                            minefield.Cells.Add(Cell.Create(c));
                        }
                        else
                        {
                            DisplayError("Not valid input. Press enter to restart the game.");
                            minefield = null;
                            minefields.Clear();
                            break;
                        }
                    }
                }
            }
            while (!ValidationRule.isFooter(input));

            this.fieldDrawer.DrawMinefields(minefields);
        }


        /// <summary>
        /// Displays the messages when the user quits the game.
        /// </summary>
        /// <param name="message">The goodbye message.</param>
        public void GoodBye(string message)
        {
            this.ValidateMessage(message);
            this.Renderer.WriteLine(message);
            this.InputReader.ReadLine();
        }

        /// <summary>
        /// Displays error messages.
        /// </summary>
        /// <param name="errorMessage">The error message to be displayed.</param>
        public void DisplayError(string errorMessage)
        {
            this.ValidateMessage(errorMessage);
            this.Renderer.Write(errorMessage);
        }


        /// <summary>
        /// Asking the user that want to continue.
        /// </summary>
        /// <returns></returns>
        public bool Continue()
        {
            this.Renderer.Write("Press esc to exit or continue...");
            this.Renderer.WriteLine();
            return (this.InputReader.ReadKey().Key == ConsoleKey.Escape);
        }      
        /// <summary>
        /// Wait for user input
        /// </summary>
        /// <param name="promptMsg"></param>
        private void WaitForKey(string promptMsg)
        {
            this.Renderer.Write(promptMsg);
            this.InputReader.WaitForKey();
        }

        /// <summary>
        /// Validates the passed message.
        /// </summary>
        /// <param name="message">The message to be validated.</param>
        private void ValidateMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("Message can not be null or empty!");
            }
        }
    }
}

using Minesweeper.Core;
using System;
using System.Collections.Generic;

namespace ConsoleMinesweeper
{
    public class UIManager
    {
        /// <summary>The drawer which handles drawing of the game console.</summary>
        private readonly MinefieldDrawer fieldDrawer;

        /// <summary>The console renderer used by the application.</summary>
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

        /// <summary>The user console input reader.</summary>
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
        /// Displays the introduction message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void DisplayIntro(string message)
        {
            this.Renderer.Write(message);
        }

        /// <summary>
        /// Displays the result of the game.
        /// </summary>
        public void DisplayResult()
        {
            List<Minefield> minefields = new List<Minefield>();
            Minefield minefield = null;

            string input = string.Empty;
            bool continueReading = true;

            while (continueReading)
            {
                input = this.InputReader.ReadLine();

                if (MinefieldValidator.IsHeader(input))
                {
                    //Validate a current minefield that the user is finish with it.
                    if ((minefield != null) && (minefield.Cells.Count != minefield.RowsCount * minefield.ColumnsCount))
                    {
                        this.Renderer.ClearCurrentLine();
                        continue;
                    }
                    minefield = MinefieldFactory.Create(minefields.Count + 1, input);
                    minefields.Add(minefield);
                }
                else if (MinefieldValidator.isFooter(input))
                {
                    if ((minefield != null) && (minefield.Cells.Count != minefield.RowsCount * minefield.ColumnsCount))
                    {
                        this.Renderer.ClearCurrentLine();
                        continue;
                    }
                    else
                    {
                        continueReading = false;
                    }                   
                }
                else
                {
                    //validate that the signs is equal to columns
                    if (minefield != null && minefield.ColumnsCount != input.Length)
                    {
                        this.Renderer.ClearCurrentLine();
                        continue;
                    }
                    CreateCells(minefield, input);                    
                }
            }         

            try
            {
                this.fieldDrawer.DrawMinefields(minefields);
            }
            catch(Exception e)
            {
                DisplayError(e.Message);
            }          
        }

        /// <summary>
        /// Filling the minefield with cells.
        /// </summary>
        /// <param name="minefield">The minefield.</param>
        /// <param name="input">The input.</param>
        private void CreateCells(Minefield minefield, string input)
        {
            foreach (char c in input.ToCharArray())
            {
                if (CellValidator.isMineOrSafe(c.ToString()))
                {
                    minefield.Cells.Add(CellFactory.Create(c));
                }
                else
                {
                    //invalid input
                    this.Renderer.ClearCurrentLine();
                    break;
                }
            }
        }

        /// <summary>
        /// Displays the messages when the user quits the game.
        /// </summary>
        /// <param name="message">The goodbye message.</param>
        public void GoodBye(string message)
        {
            this.Renderer.WriteLine(message);
            this.InputReader.ReadLine();
        }

        /// <summary>
        /// Displays error messages.
        /// </summary>
        /// <param name="errorMessage">The error message to be displayed.</param>
        public void DisplayError(string errorMessage)
        {
            this.Renderer.Write(errorMessage);
        }

        /// <summary>
        /// Asking the user that want to continue.
        /// </summary>
        /// <returns></returns>
        public bool Continue()
        {
            this.Renderer.Write("Do you want to continue? Y/N");
            bool continueGame = this.InputReader.ReadKey().Key == ConsoleKey.Y;
            if (continueGame)
            {
                this.Renderer.Write(Environment.NewLine);
            }
            return (continueGame);
        }
    }
}

using Minesweeper.Core;
using System;
using System.Collections.Generic;

namespace ConsoleMinesweeper
{
    public class UIManager
    {
        /// <summary>The drawer which handles drawing of the game console.</summary>
        private readonly MinefieldDrawer fieldDrawer;

        public List<Minefield> minefields = new List<Minefield>();
        public Minefield minefield = null;

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
            
            string input = string.Empty;
            bool continueReading = true;

            while (continueReading)
            {
                input = this.InputReader.ReadLine();

                continueReading = ParseInput(input);
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

        public bool ParseInput(string input)
        {
            if (MinefieldValidator.IsHeader(input))
            {
                //Validate cells count of the current minefield
                if (minefield != null && !MinefieldValidator.isValidCellCount(minefield.Cells.Count, minefield.RowsCount, minefield.ColumnsCount))
                {
                    this.Renderer.ClearCurrentLine();
                    return true;
                }
                //create a new minefield and add to a list of minefields
                minefield = MinefieldFactory.Create(minefields.Count + 1, input);
                minefields.Add(minefield);
            }
            //Check for end of user input
            else if (MinefieldValidator.isFooter(input))
            {
                //Validate cells count of the current minefield
                if (minefield != null && !MinefieldValidator.isValidCellCount(minefield.Cells.Count, minefield.RowsCount, minefield.ColumnsCount))
                {
                    this.Renderer.ClearCurrentLine();
                    return true;
                }
                else
                {
                    //end of user's input
                    return false;
                }
            }
            else
            {
                //validate that the signs is equal to columns
                if (minefield != null && minefield.ColumnsCount != input.Length)
                {
                    this.Renderer.ClearCurrentLine();
                    return true;
                }
                CreateCells(minefield, input);
            }
            return true;
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

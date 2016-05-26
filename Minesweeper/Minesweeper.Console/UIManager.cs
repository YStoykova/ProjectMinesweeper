using Minesweeper.Core;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
            List<string> input = ReadInput();
            MinesweeperReader reader = new MinesweeperReader();
            reader.Result(input);
            foreach (Minefield minefield in reader.minefields)
            {
                int[,] neighborMines = minefield.CalculateNeighborMines();
                Func<ICell, CellResult> converter = c => minefield.ConvertCellToTypeResult(c);
                var result = minefield.ConvertArrayToMatrix<ICell, CellResult>(minefield.Cells, minefield.ColumnsCount, converter);
                this.Renderer.WriteLine(String.Format("Field #{0}:", minefield.Id));
                DrawField(result, neighborMines);
                this.Renderer.WriteLine();
            }   
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
            this.WaitForKey(" Press any key to continue...");
        }

        /// <summary>
        /// Read the user input
        /// </summary>
        /// <returns></returns>
        public List<string> ReadInput()
        {
            List<string> inputRows = new List<string>();

            Regex headerMask = new Regex(ValidationRule.headerMinefield, RegexOptions.Singleline);
            Regex footerMask = new Regex(ValidationRule.footerMinefield, RegexOptions.Singleline);
            Regex mineMask = new Regex(ValidationRule.validMine, RegexOptions.Singleline);
            Regex safeMask = new Regex(ValidationRule.validSafeSign.ToString());

            string input;
            do
            {
                input = this.InputReader.ReadLine();
                //Validate row
                if (headerMask.IsMatch(input))
                {
                    //minefield header
                }
                else if(footerMask.IsMatch(input))
                {
                    //minefields end footer
                }
                else
                {
                    foreach (char c in input)
                    {
                        if (mineMask.IsMatch(c.ToString()) || safeMask.IsMatch(c.ToString()))
                        {
                            //valid mine or safe sign
                        }
                        else    
                        {
                            DisplayError("Not valid input.");
                        }
                    }
                }

                inputRows.Add(input);
            }
            while (!footerMask.IsMatch(input));

            return inputRows;
        }

        /// <summary>
        /// Draw Minefields
        /// </summary>
        /// <param name="minefield"></param>
        /// <param name="neighborMines"></param>
        public void DrawField(CellResult[,] minefield, int[,] neighborMines)
        {
            if (minefield.GetLength(0) != neighborMines.GetLength(0) ||
                minefield.GetLength(1) != neighborMines.GetLength(1))
            {
                throw new ArgumentException("Matrices dimensions are not equal!");
            }

            this.fieldDrawer.DrawField(minefield, neighborMines);
        }

        /// <summary>
        /// Asking the user that want to continue.
        /// </summary>
        /// <returns></returns>
        public bool Continue()
        {
            this.Renderer.Write("Do you want to continue? Y/N");
            this.Renderer.WriteLine();
            return (this.InputReader.ReadKey().Key == ConsoleKey.Y);
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

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Minesweeper.Core
{
    public class MinesweeperReader
    {
        public Minefield minefield;
        public List<Minefield> minefields;

        /// <summary>
        /// Parse the user input and fill in the minefields.
        /// </summary>
        /// <param name="listRows"></param>
        public void Result(List<string> listRows)
        {
            ParseInput(listRows);
        }

        /// <summary>
        /// Parse the user input.
        /// </summary>
        /// <param name="listRows"></param>
        private void ParseInput(List<string> listRows)
        {
            Regex headerInput = new Regex(ValidationRule.headerMinefield, RegexOptions.Singleline);
            Regex footerInput = new Regex(ValidationRule.footerMinefield, RegexOptions.Singleline);

            this.minefields = new List<Minefield>();

            for (int row = 0; row < listRows.Count; row++)
            {
                if (footerInput.IsMatch(listRows[row]))
                {
                    break;
                }
                if (headerInput.IsMatch(listRows[row]))
                {
                    string[] ar = listRows[row].Split(' ');

                    int rows = int.Parse(ar[0]);
                    int cols = int.Parse(ar[1]);
                    minefield = new Minefield(rows, cols, minefields.Count + 1);
                    minefields.Add(minefield);

                    continue;
                }
                else
                {
                    foreach (char c in listRows[row])
                    {
                        Cell cell = new Cell();
                        cell.Text = c;
                        if (c == ValidationRule.validMineSign)
                        {
                            cell.IsMined = true;
                        }
                        minefield.Cells.Add(cell);
                    }
                }
            }
        }
    }
}

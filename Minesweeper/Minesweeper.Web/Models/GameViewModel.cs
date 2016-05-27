using Minesweeper.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Minesweeper.Web.Models
{
    public class GameViewModel
    {
        [Required]
        [DataType(DataType.MultilineText)]
        public string UserInput { get; set; }
        public string UserResult { get; set; }

        public string ErroMessage { get; set; }

        public string GenerateOutput(string input)
        {
            List<Minefield> minefields = new List<Minefield>();
            Minefield minefield = null;
            string output = string.Empty;

            string[] delimiter = { "\r\n" };
            string[] words = input.Split(delimiter, StringSplitOptions.None);

            foreach (string s in words)
            {
                if (ValidationRule.IsHeader(s))
                {
                    minefield = new Minefield().Create(minefields.Count + 1, s);
                    minefields.Add(minefield);
                }
                else if (ValidationRule.isFooter(s))
                {
                    break;
                }
                else
                {
                    foreach (char c in s.ToCharArray())
                    {
                        if ((ValidationRule.isMine(c.ToString())) || (ValidationRule.isSafe(c.ToString())))
                        {
                            minefield.Cells.Add(Cell.Create(c));
                        }
                        else
                        {
                            ErroMessage = "Your input is not valid";
                            return input;
                        }
                    }
                }
            }
            foreach (Minefield field in minefields)
            {
                int[,] neighborMines = field.CalculateNeighborMines();
                var result = field.ConvertMinefield(field);
                MinesweeperConverter converter = new MinesweeperConverter();
                converter.ConvertMinefield(result, neighborMines);
                output += String.Format(ValidationRule.headerOutput, field.Id);
                output += Environment.NewLine;
                output += converter.output;
                output += Environment.NewLine;
            }

            return output;
        }
    }
}
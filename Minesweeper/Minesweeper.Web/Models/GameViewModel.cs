using Minesweeper.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Minesweeper.Web.Models
{
    public class GameViewModel
    {
        [Required]
        [DataType(DataType.MultilineText)]
        public string UserInput { get; set; }
        public string UserResult { get; set; }


        /// <summary>
        /// Returns the error message
        /// </summary>
        public string ErroMessage { get; set; }

        /// <summary>
        /// Generates the output
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string GenerateOutput(string input)
        {
            List<Minefield> minefields = new List<Minefield>();
            Minefield minefield = null;
            StringBuilder output = new StringBuilder();

            string[] delimiter = { Environment.NewLine };
            string[] words = input.Split(delimiter, StringSplitOptions.None);

            foreach (string s in words)
            {
                if (MinefieldValidator.IsHeader(s))
                {
                    minefield = MinefieldFactory.Create(minefields.Count + 1, s);
                    minefields.Add(minefield);
                }
                else if (MinefieldValidator.isFooter(s))
                {
                    break;
                }
                else
                {
                    foreach (char c in s.ToCharArray())
                    {
                        if (CellValidator.isMineOrSafe(c.ToString()))
                        {
                            minefield.Cells.Add(CellFactory.Create(c));
                        }
                        else
                        {
                            ErroMessage = "Your input data is not valid.";
                            return output.ToString();
                        }
                    }
                }
            }
            try
            {
                foreach (Minefield field in minefields)
                {
                    MinesweeperConverter converter = new MinesweeperConverter();
                    converter.ConvertMinefield(field);
                    //header
                    output.Append(String.Format(MinefieldValidator.headerOutput, field.Id));
                    output.Append(Environment.NewLine);
                    //result
                    output.Append(converter.output);
                    output.Append(Environment.NewLine);
                }
            }
            catch
            {
                ErroMessage = "Your input data is not valid.";
                return output.ToString();
            }

            return output.ToString();
        }
    }
}
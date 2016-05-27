using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core
{
    public class MinefieldFactory
    {
        /// <summary>
        /// Implements the Factory pattern to create new minefield
        /// </summary>
        public static Minefield Create(int id, string input)
        {
            string[] value = input.Split(' ');

            int rows = int.Parse(value[0].ToString());
            int cols = int.Parse(value[1].ToString());

            Minefield field = new Minefield();
            field.RowsCount = rows;
            field.ColumnsCount = cols;
            field.Id = id;
            return field;
        }
    }
}

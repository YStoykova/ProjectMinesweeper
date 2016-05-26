using System;

namespace Minesweeper.Core
{
    public struct CellPosition : ICellPosition
    {
        /// <summary>
        /// The exception message.
        /// </summary>
        private const string ExceptionMessageFormat = "Value for {0}'s position cannot be negative";

        public CellPosition(int initialRow, int initialCol)
            : this()
        {
            this.Row = initialRow;
            this.Column = initialCol;
        }

        /// <summary>
        /// The number of row for the cell position.
        /// </summary>
        private int row;
        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(ExceptionMessageFormat, "row");
                }

                this.row = value;
            }
        }

        /// <summary>
        /// The number of column for the cell position
        /// </summary>
        private int col;
        public int Column
        {
            get
            {
                return this.col;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(ExceptionMessageFormat, "column");
                }

                this.col = value;
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;

namespace Minesweeper.Core
{
    public class Minefield
    {
        /// <summary>
        /// The Id of the Minefield
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Exception message for roes and columns
        /// </summary>
        private const string ValueTypesExceptionFormat = "The value - {0} for {1} count must be greater than zero!";
        
        /// <summary>Number of rows for the minefield.</summary>
        private int rowsCount;
        public int RowsCount
        {
            get
            {
                return this.rowsCount;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ValueTypesExceptionFormat, value, "rows"));
                }

                this.rowsCount = value;
            }
        }

        /// <summary>
        /// Number of columns for the minefield.
        /// </summary>
        private int columnsCount;
        public int ColumnsCount
        {
            get
            {
                return this.columnsCount;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ValueTypesExceptionFormat, value, "column"));
                }

                this.columnsCount = value;
            }
        }
       
        /// <summary>
        /// Cells of the minefield.
        /// </summary>
        public IList<ICell> Cells { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Minefield()
        {
            this.Cells = new List<ICell>();
        }
       
        /// <summary>
        /// Algorithm to calculate neighbor mines for each cell.
        /// </summary>
        /// <returns></returns>
        public int[,] CalculateNeighborMines()
        {
            var resultArray = new int[this.RowsCount, this.ColumnsCount];
            for (int i = 0; i < this.RowsCount; i++)
            {
                for (int j = 0; j < this.ColumnsCount; j++)
                {
                    CellPosition position = new CellPosition(i, j);
                    resultArray[i, j] = this.CountNeighborMinesPerCell(position);
                }
            }
            return resultArray;
        }

        /// <summary>
        /// Calculate count of mines depends of cell position.
        /// Eeach cell may have at most 8 adjacent cells.
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <returns></returns>
        protected int CountNeighborMinesPerCell(ICellPosition currentPosition)
        {
            int counter = 0;

            for (int row = -1; row < 2; row++)
            {
                for (int col = -1; col < 2; col++)
                {
                    if (col == 0 && row == 0)
                    {
                        continue;
                    }

                    int currentIndex = ((currentPosition.Row + row) * this.ColumnsCount) + (currentPosition.Column + col);
                    bool isInsideMatrix = this.IsInsideMatrix(currentPosition.Row + row, currentPosition.Column + col);
                    if (isInsideMatrix)
                    {
                        if (this.Cells[currentIndex].IsMined)
                        {
                            counter++;
                        }
                    }
                }
            }
            return counter;
        }
       
        /// <summary>
        /// Checks that the row and the cell is in the range.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        protected bool IsInsideMatrix(int row, int col)
        {
            return (0 <= row && row < this.RowsCount) && (0 <= col && col < this.ColumnsCount);
        }

        /// <summary>
        /// Convert the two dimentional array to display source.
        /// </summary>
        /// <typeparam name="C">Cell</typeparam>
        /// <typeparam name="T">CellResult</typeparam>
        /// <param name="source">List of Cells</param>
        /// <param name="columns">the number of columns in minefield</param>
        /// <param name="func"></param>
        /// <returns></returns>
        public T[,] ConvertToResult<C, T>(IList<C> source, int columns, Func<C, T> func)
        {
            int rows = source.Count / columns;
            T[,] result = new T[rows, columns];

            for (int index = 0; index < source.Count; index++)
            {
                int row = index / columns;
                int column = index % columns;
                result[row, column] = func(source[index]);
            }

            return result;
        }

        /// <summary>
        /// Convert the cell to result  depends of cell type.
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public CellResult ConvertCellToTypeResult(ICell cell)
        {
            CellResult result = cell.IsMined ? CellResult.Mine : CellResult.Number;
            return result;
        }
    }
}

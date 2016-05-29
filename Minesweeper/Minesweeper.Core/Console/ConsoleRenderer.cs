using System;

namespace Minesweeper.Core
{
    public class ConsoleRenderer : IRenderer
    {
        /// <summary>
        /// Writes the current line terminator to the standard output stream.
        /// </summary>
        public void WriteLine()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Writes the text representation of the specified array of objects 
        /// to the standard output stream using the specified format information, 
        /// followed by the current line terminator.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An array of objects to write using format.</param>
        public void WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        /// <summary>
        /// Writes the text representation of the specified array of objects 
        /// to the standard output stream using the specified format information.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An array of objects to write using format.</param>
        public void Write(string format, params object[] args)
        {
            Console.Write(format, args);
        }

        /// <summary>
        /// Clears the current line.
        /// </summary>
        public void ClearCurrentLine()
        { 
           Console.SetCursorPosition(0, Console.CursorTop -  1);
           Console.Write(new string(' ', Console.WindowWidth));
           Console.SetCursorPosition(0, Console.CursorTop - 1);
        }

        /// <summary>
        /// Sets the cursor position.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        public void SetCursorPosition(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }
    }
}

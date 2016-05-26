
namespace Minesweeper.Core
{
    public interface IRenderer
    {
        /// <summary>
        /// Writes the current line terminator to the output stream.
        /// </summary>
        void WriteLine();

        /// <summary>
        /// Writes the text representation of the specified array of objects 
        /// to the output stream using the specified format information, 
        /// followed by the current line terminator.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An array of objects to write using format.</param>
        void WriteLine(string format, params object[] args);

        /// <summary>
        /// Writes the text representation of the specified array of objects 
        /// to the output stream using the specified format information.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An array of objects to write using format.</param>
        void Write(string format, params object[] args);
    }
}

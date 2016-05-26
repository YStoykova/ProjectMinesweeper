using System;

namespace Minesweeper.Core
{
    public interface IUserInputReader
    {
        /// <summary>
        /// Reads the next line of characters from the input stream.
        /// </summary>
        /// <returns>The next line of characters from the input stream, or null if no more lines are available.</returns>
        string ReadLine();

        /// <summary>
        /// Reads the console key info from the input character.
        /// </summary>
        /// <returns>The next character from the input key</returns>
        ConsoleKeyInfo ReadKey();

        /// <summary>
        /// Waits for the user to press a key.
        /// </summary>
        void WaitForKey();
    }
}

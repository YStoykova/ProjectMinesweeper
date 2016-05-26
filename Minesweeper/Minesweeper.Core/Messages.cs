
namespace Minesweeper.Core
{
    public static class Messages
    {
        /// <summary>Intro message.</summary>
        public const string Intro = "Welcome to the game “Minesweeper”.\nThe input will consist of an arbitrary number of fields. \nThe first line of each field contains two numbers from 1 to 100. \n The next lines contains exactly characters. \n Each safe square is represented by an '.' character (without the quotes) and each mine square is represented by an '*' character (also without the quotes). \nThe first field line where '0 0' represents the end of input and should not be processed.\n";
 
        /// <summary>Minesweeper exit message.</summary>
        public const string Bye = "Good bye!";
    }
}

Steps to prepare the source code to build properly:

Prerequisites: 
-------------------
Installed ASP.NET Framework 4.5 (https://www.microsoft.com/en-us/download/details.aspx?id=30653)
The Minesweeper folder contains the Visual Studio 2013 solution file named Minesweeper.sln
Start the solution file (or open Visual Studio 2013 and browse to sln file).
-------------------

Description:
---------------------
The solution file contains follow folders:
 
1. Minesweeper.Web           	the web application
2. Minesweeper.Console        	the console application
3. Minesweeper.Core        	the library project contains logic uses from web application and console application

------------------------

Actions:
--------------------
Build the solution. The solution uses Nuget to respore packages from packages config files.
To run the web application: set the Minesweeper.Web project as startup project
To run the console application: set the Minesweeper.Console project as startup project

--------------------
Implemented design patterns:

Creational: Builder (MinesweeperConverter)
Behavioral: Command (Minesweeper)
Structural: Adapter(IRenderer: ConsoleRenderer(System.Console))
	    Facade:  Minesweeper is Facade for UIManager, Minefield

Design Principles: Dependency Inversion Principle


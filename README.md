# TicTacToe
A command line implementation of Tic Tac Toe, aka Noughts and Crosses, written in C#.  Users are presented with various options of gameplay:

- Two-player game (two humans)
- Single-player game against a *dumb* computer that randomly chooses a move
- Single-player game against an *unbeatable* computer using a [minimax](https://en.wikipedia.org/wiki/Minimax) algorithm
- Watch the computer play against itself - unbeatable vs dumb
- Users can also choose their own markers!

## Installation

Download or clone this repository with the "clone or download" button at the top of this page. 

This project was built in C# and uses the .NET framework and the [xUnit](https://xunit.net/) test suite. To run this application you'll first need to install C#.  I recommend following this ["hello world"](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/intro) tutorial to get started. Once installed you can run the commands detailed below from the project's root directory. 

Run the following command to install the dependencies for the project:

```dotnet restore```

## Testing
Navigate to this project's directory and run the following command:

```dotnet test TicTacToeTests/```

## Starting the Game

Run this command to compile and launch the playable game:

```dotnet run --project TicTacToeRunner/```

#### Good luck!
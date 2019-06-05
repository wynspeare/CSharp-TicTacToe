using System;
using TicTacToeApp;

namespace TicTacToeUserInterface
{
    public class UserInterface
    {

        public TicTacToe newGame;
        public Adapter adapter;

        static void Main(string[] args)
        {
            Console.WriteLine("Main Method being run!");
            var game = new UserInterface(); 
            game.startNewGame();
        }

        public string startNewGame()
        {
            Console.WriteLine("Do you want to play a game of Tic Tac Toe? Y/N");
            string answer = Console.ReadLine();

            if (answer == "Y")
            {
                Console.Write("Player One - ");
                var markerOne = chooseMarker();

                Console.Write("Player Two - ");
                var markerTwo = chooseMarker();

                adapter = new Adapter(markerOne, markerTwo);

                newGame = new TicTacToe(adapter.X_MARKER, adapter.O_MARKER);
                Console.WriteLine("A new game has been started");
                return "A new game has been started";
            }
            else if (answer == "N")
            {
                return "Okay Bye!";
            }
            else
            {
                Console.WriteLine("Please enter Y or N only.");
                return startNewGame();
            }
        }


        public string chooseMarker()
        {
            Console.WriteLine("Please choose a marker: X or O");
            string marker = Console.ReadLine();
            if(marker == "")
            {
                return chooseMarker();
            }
            else
            {
                return marker.Substring(0,1);
            }
            // if (marker == Adapter.X_MARKER)
            // {
            //     Console.WriteLine("Player One - Your Marker is X\nPlayer Two - Your Marker is O\n");
            //     return Adapter.X_MARKER;
            // }
            // else if (marker == Adapter.O_MARKER | marker == "0")
            // {
            //     Console.WriteLine("Player One - Your Marker is O\nPlayer Two - Your Marker is X\n");
            //     return Adapter.O_MARKER;
            // }
            // else
            // {
            //     Console.WriteLine("Please enter X or O only.");
            //     return chooseMarker();
            // }
        }


        public bool isValidSpace(string location)
        {   
            try
            {
                var convertedLocation = Convert.ToInt32(location);
                if (convertedLocation >= 1 && convertedLocation <= Adapter.BOARD_SIZE)
                {
                    return newGame.currentBoard.board[convertedLocation - 1].marker == Adapter.EMPTY;
                }
                else
                {
                    return false;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please only enter a number.");
                return false;
            }
        }

        
        public int getSpace()
        {
            Console.WriteLine("Please enter an empty space between 1 - 9:");
            string location = Console.ReadLine();
            int locationInt = 0;
            if (isValidSpace(location))
            {
                locationInt = Convert.ToInt32(location);
                // currentSpace = locationInt;
            }
            else
            {
                getSpace();
            }
            return locationInt;
        }

        
        public string displayBoard(Board board)
        {
            var displayBoard = "  ———————————  \n | ";
            foreach (Space space in board.board)
            {
                if(space.marker == Adapter.EMPTY)
                {
                    displayBoard += space.location.ToString() + " | ";
                }
                else
                {
                    displayBoard += space.marker + " | ";
                }
            }
            displayBoard = displayBoard.Insert(28, " |\n |———|———|———| \n");
            displayBoard = displayBoard.Insert(60, "|\n |———|———|———|  \n ");
            displayBoard += "\n  ———————————  ";
            Console.WriteLine(displayBoard);
            return displayBoard;
        }


        public string displayInstructions()
        {
            var instructions = "\nHOW TO PLAY\n===========\nPlayers alternate placing Xs and Os on the board until either one player has three in a row, horizontally, vertically, or diagonally; or all nine squares are filled.\nIf a player is able to draw three of their Xs or three of their Os in a row, then that player wins.\n";
            Console.WriteLine(instructions);
            return instructions;
        }


    }
}

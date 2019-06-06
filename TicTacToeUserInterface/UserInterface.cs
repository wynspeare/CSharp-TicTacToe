using System;
using TicTacToeApp;

namespace TicTacToeUserInterface
{
    public class UserInterface
    {

        public TicTacToe newGame;
        // public Options options; //maybe not instance variable 

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
                var options = new Options(setMarkers());
                
                newGame = new TicTacToe(options.P1_MARKER, options.P2_MARKER);
                Console.WriteLine("A new game has been started!");
                Console.WriteLine("Player One - Your Marker is {0}\nPlayer Two - Your Marker is {1}\n", options.P1_MARKER, options.P2_MARKER);

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

        public Tuple<string, string> setMarkers()
        {
            Console.Write("Player One - ");
            var markerOne = chooseMarker();
            Console.Write("Player Two - ");
            var markerTwo = chooseMarker();

            while (!isMarkerDifferent(markerOne, markerTwo))
            {
                Console.WriteLine("Please select a different symbol from Player One.");
                markerTwo = chooseMarker();
            }
            return Tuple.Create(markerOne, markerTwo);
        }


        public bool isMarkerDifferent(string marker1, string marker2)
        {
            return marker1 != marker2;
        }


        public string chooseMarker()
        {
            Console.WriteLine("Please choose a symbol for your marker:");
            string marker = Console.ReadLine();
            if(marker == "")
            {
                return chooseMarker();
            }
            else
            {
                return marker.Substring(0,1);
            }
        }


        public bool isValidSpace(string location)
        {   
            try
            {
                var convertedLocation = Convert.ToInt32(location);
                if (convertedLocation >= 1 && convertedLocation <= Options.BOARD_SIZE)
                {
                    return newGame.currentBoard.board[convertedLocation - 1].marker == Options.EMPTY;
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
            Console.WriteLine("Please enter an empty space between 1 - {0}:", Convert.ToInt32(Options.BOARD_SIZE));
            string location = Console.ReadLine();
            int locationInt = 0;
            if (isValidSpace(location))
            {
                locationInt = Convert.ToInt32(location);
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
                if(space.marker == Options.EMPTY)
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
            var instructions = "\nHOW TO PLAY\n===========\nPlayers alternate placing different markers on the board until either one player has three in a row, horizontally, vertically, or diagonally; or all nine squares are filled.\nIf a player is able to draw three of their markers in a row, then that player wins.\n";
            Console.WriteLine(instructions);
            return instructions;
        }


    }
}

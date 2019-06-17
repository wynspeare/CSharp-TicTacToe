using System;
using System.Collections.Generic;
using TicTacToeApp;


namespace TicTacToeUserInterface
{
    public class UserInterface
    {

        public bool startNewGame()
        {
            Console.WriteLine("Are you ready to play Tic Tac Toe? Y/N");
            string answer = Console.ReadLine();
            if (answer == "Y")
            {
                displayInstructions();
                return true;
            }
            else if (answer == "N")
            {
                Console.WriteLine("Okay Bye!");
                return false;
            }   
            else
            {
                Console.WriteLine("Please enter Y or N only.");
                return startNewGame();
            }
        }

        public string getTypeOfGame()
        {
            Console.WriteLine("Do you want to play against the computer? Y/N");            
            string answer = Console.ReadLine();            
            if (answer == "Y" || answer == "N")
            {
                return answer;
            }
            else
            {
                Console.WriteLine("Please enter Y or N only.");
                return getTypeOfGame();
            }
        }

        public void displayComputersMove(int compSpace)
        {
            Console.WriteLine("\nThe computer selected space {0}.", compSpace.ToString());
        }

        public bool isSinglePlayerGame(string isSinglePlayer)
        {
            return isSinglePlayer == "Y" ? true : false;
        }

        public int getValidSpace(List<int> availableSpaces, Dictionary<int, string> board, PlayerInterface player)
        {
            displayBoard(board);
            var location = getSpace(player, availableSpaces);
            while(!isValidSpace(availableSpaces, location))
            {
                Console.Write("Try again! ");                
                location = getSpace(player, availableSpaces);
            }
            return Convert.ToInt32(location);
        }

        public bool isValidSpace(List<int> availableSpaces, string location)
        {   
            try
            {
                var convertedLocation = Convert.ToInt32(location);
                return availableSpaces.Contains(convertedLocation);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please only enter a number.");
                return false;
            }
        }

        private string getSpace(PlayerInterface player, List<int> availableSpaces)
        {
            Console.Write("Player \"{0}\" please enter an empty space between 1 - {1}: ", player.marker, Convert.ToInt32(Options.BOARD_SIZE));
            return player.getMove(availableSpaces);
        }

        public void displayWinOrDraw(bool isDraw, string winnersMarker)
        {
            if (isDraw)
            {
                Console.WriteLine("This game is a draw, better luck next time.");
            }
            else
            {
                Console.WriteLine("\"{0}\" has WON!", winnersMarker);    
            }
        }

        public void displaySinglePlayerGameStatus(bool isWon)
        {
            if(isWon)
            {
                Console.WriteLine("Congrats you are the winner!!");
            }
            else
            {
                Console.WriteLine("Oh no, the computer is the winner, better luck next time.");
            }
        }

        public Tuple<string, string> setMarkers()
        {
            Console.Write("Please choose a symbol for Player One: ");
            var markerOne = chooseMarker();
            Console.Write("Please choose a symbol for Player Two: ");

            var markerTwo = chooseMarker();
            while (!isMarkerDifferent(markerOne, markerTwo))
            {
                Console.WriteLine("Please select a different symbol from Player One.");
                markerTwo = chooseMarker();
            }
            Console.WriteLine("\nA new game has been started!\n\nPlayer One - Your Marker is {0}\nPlayer Two - Your Marker is {1}\n", markerOne, markerTwo);
            return Tuple.Create(markerOne, markerTwo);
        }

        public bool isMarkerDifferent(string marker1, string marker2)
        {
            return marker1 != marker2;
        }

        private string chooseMarker()
        {
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

        public string displayBoard(Dictionary<int, string> board)
        {
            var displayBoard = "  ———————————  \n | ";
            foreach (KeyValuePair<int, string> space in board)
            {
                var marker = space.Value;
                var location = space.Key;
                if(marker == Options.EMPTY)
                {
                    displayBoard += location.ToString() + " | ";
                }
                else
                {
                    displayBoard += marker + " | ";
                }
            }
            displayBoard = displayBoard.Insert(28, " |\n |———|———|———| \n");
            displayBoard = displayBoard.Insert(60, "|\n |———|———|———|  \n ");
            displayBoard += "\n  ———————————  ";
            Console.WriteLine(displayBoard);
            return displayBoard;
        }

        private string displayInstructions()
        {
            var instructions = "\nHOW TO PLAY\n===========\nPlayers alternate placing different markers on the board until either one player has three in a row, horizontally, vertically, or diagonally; or all nine squares are filled.\nIf a player is able to draw three of their markers in a row, then that player wins.\n";
            Console.WriteLine(instructions);
            return instructions;
        }

    }
}

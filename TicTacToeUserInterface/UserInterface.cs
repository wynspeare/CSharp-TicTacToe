using System;
using System.Collections.Generic;

namespace TicTacToeUserInterface
{
    public class UserInterface
    {
        public bool StartNewGame()
        {
            Console.WriteLine("Are you ready to play Tic Tac Toe? Y/N");
            string answer = Console.ReadLine();
            if (answer == "Y")
            {
                DisplayInstructions();
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
                return StartNewGame();
            }
        }

        public string IsHardMode()
        {
            Console.WriteLine("Do you want play an unbeatable computer? Y/N");            
            string answer = Console.ReadLine();            
            if (IsValidYesOrNoInput(answer))
            {
                return answer;
            }
            else
            {
                return IsHardMode();
            }
        }

        public string IsHumanFirst()
        {
            Console.WriteLine("Do you want to go first? Y/N");            
            string answer = Console.ReadLine();            
            if (IsValidYesOrNoInput(answer))
            {
                return answer;
            }
            else
            {
                return IsHumanFirst();
            }
        }

        public string GetTypeOfGame()
        {
            Console.WriteLine("Do you want to play against the computer? Y/N");            
            string answer = Console.ReadLine();            
            if (IsValidYesOrNoInput(answer))
            {
                return answer;
            }
            else
            {
                return GetTypeOfGame();
            }
        }

        public string IsCompVCompGame()
        {
            Console.WriteLine("Do you want to watch an unbeatable computer play a random computer? Y/N");            
            string answer = Console.ReadLine();
            if (IsValidYesOrNoInput(answer))
            {
                return answer;
            }
            else
            {
                return IsCompVCompGame();
            }            
        }

        public bool IsValidYesOrNoInput(string userInput)
        {   
            if (userInput == "Y" || userInput == "N")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Please enter Y or N only.");
                return false;
            }
        }

        public bool IsUserInputYes(string userInput)
        {
            return userInput == "Y" ? true : false;
        }

        public void AskForMove(string marker)
        {
            Console.Write("Player \"{0}\" please enter an empty space between 1 - {1}: ", marker, Convert.ToInt32(Options.BOARD_SIZE));
        }

        public void DisplayWinOrDraw(bool isDraw, string winnersMarker)
        {
            if (isDraw)
            {
                Console.WriteLine("This game is a draw, better luck next time.");
            }
            else
            {
                Console.WriteLine("Player \"{0}\" has WON!", winnersMarker);    
            }
        }

        public Tuple<string, string> SetMarkers()
        {
            Console.Write("Please choose a symbol for Player One: ");
            var markerOne = ChooseMarker();
            Console.Write("Please choose a symbol for Player Two: ");

            var markerTwo = ChooseMarker();
            while (!IsMarkerDifferent(markerOne, markerTwo))
            {
                Console.WriteLine("Please select a different symbol from Player One.");
                markerTwo = ChooseMarker();
            }
            Console.WriteLine("\nA new game has been started!\n\nPlayer One - Your Marker is {0}\nPlayer Two - Your Marker is {1}\n", markerOne, markerTwo);
            return Tuple.Create(markerOne, markerTwo);
        }

        public bool IsMarkerDifferent(string marker1, string marker2)
        {
            return marker1 != marker2;
        }

        private string ChooseMarker()
        {
            string marker = Console.ReadLine();
            if(marker == "")
            {
                return ChooseMarker();
            }
            else
            {
                return marker.Substring(0,1);
            }
        }

        public string DisplayBoard(Dictionary<int, string> board)
        {
            var DisplayBoard = "  ———————————  \n | ";
            foreach (KeyValuePair<int, string> space in board)
            {
                var marker = space.Value;
                var location = space.Key;
                if(marker == Options.EMPTY)
                {
                    DisplayBoard += location.ToString() + " | ";
                }
                else
                {
                    DisplayBoard += marker + " | ";
                }
            }
            DisplayBoard = DisplayBoard.Insert(28, " |\n |———|———|———| \n");
            DisplayBoard = DisplayBoard.Insert(60, "|\n |———|———|———|  \n ");
            DisplayBoard += "\n  ———————————  ";
            Console.WriteLine(DisplayBoard);
            return DisplayBoard;
        }

        private string DisplayInstructions()
        {
            var instructions = "\nHOW TO PLAY\n===========\nPlayers alternate placing different markers on the board until either one player has three in a row, horizontally, vertically, or diagonally; or all nine squares are filled.\nIf a player is able to draw three of their markers in a row, then that player wins.\n";
            Console.WriteLine(instructions);
            return instructions;
        }

    }
}

﻿using System;
using System.Collections.Generic;

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

        public string getDifficultyLevel()
        {
            Console.WriteLine("Do you want play an unbeatable computer? Y/N");            
            string answer = Console.ReadLine();            
            if (isValidYesOrNoInput(answer))
            {
                return answer;
            }
            else
            {
                return getDifficultyLevel();
            }
        }

        public string getPlayerOrder()
        {
            Console.WriteLine("Do you want to go first? Y/N");            
            string answer = Console.ReadLine();            
            if (isValidYesOrNoInput(answer))
            {
                return answer;
            }
            else
            {
                return getPlayerOrder();
            }
        }

        public string getTypeOfGame()
        {
            Console.WriteLine("Do you want to play against the computer? Y/N");            
            string answer = Console.ReadLine();            
            if (isValidYesOrNoInput(answer))
            {
                return answer;
            }
            else
            {
                return getTypeOfGame();
            }
        }

        public string isCompVCompGame()
        {
            Console.WriteLine("Do you want to watch an unbeatable computer play a random computer? Y/N");            
            string answer = Console.ReadLine();
            if (isValidYesOrNoInput(answer))
            {
                return answer;
            }
            else
            {
                return isCompVCompGame();
            }            
        }

        public bool isValidYesOrNoInput(string userInput)
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

        public bool isUserInputYes(string userInput)
        {
            return userInput == "Y" ? true : false;
        }

        public void askForMove(string marker)
        {
            Console.Write("Player \"{0}\" please enter an empty space between 1 - {1}: ", marker, Convert.ToInt32(Options.BOARD_SIZE));
        }

        public void displayWinOrDraw(bool isDraw, string winnersMarker)
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

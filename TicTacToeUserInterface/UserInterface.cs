﻿using System;
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


        public int getValidSpace(List<Space> board)
        {
            displayBoard(board);
            var location = getSpace();
            while (!isValidSpace(location, board))
            {   
                Console.WriteLine("That space has already been taken!");
                location = getSpace();
            }
            return Convert.ToInt32(location);
        }


        // public void winOrDraw(List <Space> board) Modify not to reach into board and check - just send it the message of W/D
        // {
        //     displayBoard(board);            
        //     // if (newGame.rules.checkIfDraw(newGame.currentBoard, newGame.currentPlayer.marker))
        //     if (false))
        //     {
        //         Console.WriteLine("This game is a draw, better luck next time.");
        //     }
        //     else
        //     {
        //         Console.WriteLine("Player \"{0}\" has WON!", newGame.currentPlayer.marker);                
        //     }
        // }


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
            Console.WriteLine("\nA new game has been started!\n\nPlayer One - Your Marker is {0}\nPlayer Two - Your Marker is {1}\n", markerOne, markerTwo);

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


        public bool isValidSpace(string location, List <Space> board)
        {   
            try
            {
                var convertedLocation = Convert.ToInt32(location);
                if (convertedLocation >= 1 && convertedLocation <= Options.BOARD_SIZE)
                {
                    return board[convertedLocation - 1].marker == Options.EMPTY;
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


        public string getSpace()
        {
            // Console.WriteLine("Player \"{0}\" please enter an empty space between 1 - {1}:", newGame.currentPlayer.marker, Convert.ToInt32(Options.BOARD_SIZE));
            Console.WriteLine("Player please enter an empty space between 1 - {0}:", Convert.ToInt32(Options.BOARD_SIZE));

            return Console.ReadLine();
        }

        
        public string displayBoard(List <Space> board)
        {
            var displayBoard = "  ———————————  \n | ";
            foreach (Space space in board)
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

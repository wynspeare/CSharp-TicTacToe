using System;
using System.Collections;
using System.Collections.Generic;

// Separate out all user input into a different project
namespace TicTacToeApp
{
    public class TicTacToe
    {

        public Board currentBoard;
        // public string currentTurn;
        public Player playerOne;
        public Player playerTwo;

        public Space currentSpace;


        public string startNewGame()
        {
            Console.WriteLine("Do you want to play a game of Tic Tac Toe? Y/N");
            string answer = Console.ReadLine();

            if (answer == "Y")
            {
                currentBoard = new Board();
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


        public void chooseMarker()
        {
            Console.WriteLine("Player One - please choose a marker -  X or O");
            string marker = Console.ReadLine();
            if (marker == "X")
            {
                Console.WriteLine("Player One - Your Marker is X\nPlayer Two - Your Marker is O\n");
                playerOne = new Player(marker);
                playerTwo = new Player("O");
            }
            else if (marker == "O" | marker == "0")
            {
                Console.WriteLine("Player One - Your Marker is O\nPlayer Two - Your Marker is X\n");
                playerOne = new Player("O");
                playerTwo = new Player("X");
            }
            else
            {
                Console.WriteLine("Please enter X or O only.");
                chooseMarker();
            }
        }


        public string displayInstructions()
        {
            var instructions = "\nHOW TO PLAY\n===========\nPlayers alternate placing Xs and Os on the board until either one player has three in a row, horizontally, vertically, or diagonally; or all nine squares are filled.\nIf a player is able to draw three of their Xs or three of their Os in a row, then that player wins.\n";
            Console.WriteLine(instructions);
            return instructions;
        }


        public int getSpace()
        {
            Console.WriteLine("Please enter an empty space between 1 - 9:");
            string location = Console.ReadLine();
            if (isValidSpace(location))
            {
                currentSpace = new Space(Convert.ToInt32(location));
            }
            else
            {
                getSpace();
            }
            return currentSpace.location;
        }
        

        public bool isValidSpace(string location)
        {   
            try
            {
                var converted_location = Convert.ToInt32(location);
                if (currentBoard.board.Contains(location))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Please only choose an empty space between 1 and 9:");
                    displayBoard();
                    return false;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please only enter a number.");
                return false;
            }
        }


        // public string move(int location, string playerMarker)
        // {
        //     currentBoard.placeMarker(location, playerMarker);
        //     displayBoard();
        //     Console.WriteLine("Swap players!");
        //     return "Good Move!";
        // }


        public string displayBoard()
        {
            var displayBoard = "  ———————————  \n | ";
            foreach (string space in currentBoard.board)
            {
                displayBoard += space + " | ";
            }
            displayBoard = displayBoard.Insert(28, " |\n |———|———|———| \n");
            displayBoard = displayBoard.Insert(60, "|\n |———|———|———|  \n ");
            displayBoard += "\n  ———————————  ";
            Console.WriteLine(displayBoard);
            return displayBoard;
        }
    }
}


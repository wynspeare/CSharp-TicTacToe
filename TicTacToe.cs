using System;
using System.Collections;
using System.Collections.Generic;


namespace TicTacToe
{
    public class TicTacToe
    {
        public string playerOneMarker;
        public string playerTwoMarker;
        public Board currentBoard;
        public string currentTurn;

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
            playerOneMarker = marker;
            playerTwoMarker = "O";
          }
          else if (marker == "O" | marker == "0")
          {
            Console.WriteLine("Player One - Your Marker is O\nPlayer Two - Your Marker is X\n");
            playerOneMarker = "O";
            playerTwoMarker = "X";
          }
          else
          {
            Console.WriteLine("Please enter X or O only.");
            chooseMarker();
          }
        }

        public string displayInstructions()
        {
          var instructions = "HOW TO PLAY\n===========\nPlayers alternate placing Xs and Os on the board until either one player has three in a row, horizontally, vertically, or diagonally; or all nine squares are filled.\nIf a player is able to draw three of their Xs or three of their Os in a row, then that player wins.\n";
          Console.WriteLine(instructions);
          return instructions;
        }
    }

    public class Board
    {
        public List<string> board = new List<string> { "_", "_", "_", "_", "_", "_", "_", "_", "_" };

        public bool isEmpty()
        {
          return !board.Contains("X") ^ board.Contains("O");
        }

        public string displayBoard()
        {
          var formattedBoard = board;
          formattedBoard.Insert(3, "\n");
          formattedBoard.Insert(7, "\n");
          var displayBoard = " ";
          foreach (string space in formattedBoard)
          {
            displayBoard += space + " ";
          }
          Console.WriteLine(displayBoard);
          return displayBoard;
        }

    }


  }



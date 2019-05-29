using System;
using System.Collections;
using System.Collections.Generic;


namespace TicTacToeApp
{
    public class Board
    {
        // static void Main() {}

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


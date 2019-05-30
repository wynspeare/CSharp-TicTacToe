using System;
using System.Collections;
using System.Collections.Generic;


namespace TicTacToeApp
{
    public class Board
    {
        // static void Main() {}

        public List<string> board = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        public bool successfulMove = false;

        // public List<List<int>> winCombinations = new List<List<int>>
        int [,] winCombinations = new int[8, 3]
        { 
            { 0, 1, 2 },
            { 3, 4, 5 },
            { 6, 7, 8 },
            { 0, 4, 8 },
            { 2, 4, 6 },
            { 0, 3, 6 },
            { 1, 4, 7 },
            { 2, 5, 8 },
        };


        public bool isEmpty()
        {
            return !(board.Contains("X") | board.Contains("O"));
        }

        public bool isSpaceEmpty(int position)
        {
            if (board[position - 1] == position.ToString())
            {
                Console.WriteLine(board[position - 1]);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool placeMarker(int position, string marker)
        {
            if (isSpaceEmpty(position))
            {
                board[position - 1] = marker;
                Console.WriteLine("Your marker was successfully placed on space " + position.ToString());
                successfulMove = true;
                return successfulMove;
            }
            else
            {
                Console.WriteLine("Your move was invalid.");
                return successfulMove;
            }
        }

        public void checkBoardArray()
        {
            foreach (string element in board)
            {
                Console.Write(element + ", ");
            }
        }

        public bool isRowComplete()
        {
            // loop thru windCombos and check if player's marker is at all three of the indexes on the board list
            return true;
        }
    }
}


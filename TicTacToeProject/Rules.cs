using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeApp
{
    public class Rules
    {
        private int [,] winCombinations = new int[8, 3]
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

        public bool checkIfWon(List<Space> board, string currentMarker)
        {
            List<string> tempRow = new List<string>();
            var isWon = false;

            for (int i = 0; i < winCombinations.GetLength(0); i++)
            {
                for (int j = 0; j < winCombinations.GetLength(1); j++)
                {
                    int index = winCombinations[i, j];
                    tempRow.Add(board[index].marker);
                }
                if (isRowComplete(tempRow, currentMarker))
                {
                    isWon = true;
                }
                tempRow.Clear();
            }
            return isWon;
        }

        public bool checkIfDraw(Board board, string currentMarker)
        {
            return board.isBoardFilled() && !checkIfWon(board.board, currentMarker);
        }

        public bool isRowComplete(List <string> row, string marker) 
        {
            return row.All(space => space == marker) ? true : false; 
        }

        public bool isOver(Board board, string currentMarker)
        {
            return checkIfWon(board.board, currentMarker) || checkIfDraw(board, currentMarker);
        }
        
    }
}
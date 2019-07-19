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

        public bool CheckIfWon(List<Space> board, string currentMarker)
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
                if (IsRowComplete(tempRow, currentMarker))
                {
                    isWon = true;
                }
                tempRow.Clear();
            }
            return isWon;
        }

        public bool CheckIfDraw(Board board, string currentMarker)
        {
            return board.IsBoardFilled() && !CheckIfWon(board.spaces, currentMarker);
        }

        public bool IsRowComplete(List <string> row, string marker) 
        {
            return row.All(space => space == marker) ? true : false; 
        }

        public bool IsOver(Board board, string currentMarker)
        {
            return CheckIfWon(board.spaces, currentMarker) || CheckIfDraw(board, currentMarker);
        }
        
    }
}
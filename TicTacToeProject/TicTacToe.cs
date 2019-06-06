using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeApp
{
    public class TicTacToe
    {
        public Board currentBoard;
        public Player playerOne;
        public Player playerTwo;
        
        public Player currentPlayer;

        int [,] winCombinations = new int[8, 3] //Maybe move to rules class
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

        public TicTacToe(string playerOneMarker = "X", string playerTwoMarker = "O")
        {
            
            Symbols.P1_MARKER = playerOneMarker;
            Symbols.P2_MARKER = playerTwoMarker;

            this.currentBoard = new Board();

            this.playerOne = new Player(Symbols.P1_MARKER);
            this.playerTwo = new Player(Symbols.P2_MARKER);
            currentPlayer = this.playerOne;
        }

        public bool turn(int location)
        {
            moveMarker(location, currentPlayer.marker);
            if (!checkIfWon())
            {
                switchPlayer();
                return true;
            }
            else
            {
                return false;
            }
        }


        public void switchPlayer()
        {
            currentPlayer = (currentPlayer == playerOne) ? playerTwo : playerOne;
        }


        public bool moveMarker(int location, string marker)
        {
            return currentBoard.placeMarker(location, marker);
        }


        public bool checkIfWon()
        {
            List<string> tempRow = new List<string>();
            var isWon = false;

            for (int i = 0; i < winCombinations.GetLength(0); i++)
            {
                for (int j = 0; j < winCombinations.GetLength(1); j++)
                {
                    int index = winCombinations[i, j];
                    tempRow.Add(currentBoard.board[index].marker);
                }
                var currentPlayersMarker_PLACEHOLDER = currentPlayer.marker;
                if (isRowComplete(tempRow, currentPlayersMarker_PLACEHOLDER))
                {
                    isWon = true;
                }
                tempRow.Clear();
            }
            return isWon;
        }


        public bool isRowComplete(List <string> row, string marker) 
        {
            return row.All(space => space == marker) ? true : false; 
        }


    }
}


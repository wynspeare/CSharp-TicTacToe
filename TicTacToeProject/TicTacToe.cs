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

        // public string currentTurn;
        // public Space currentSpace;

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


        public TicTacToe(string playerOneMarker = "X", string playerTwoMarker = "O")
        {
            
            Symbols.P1_MARKER = playerOneMarker;
            Symbols.P2_MARKER = playerTwoMarker;

            this.currentBoard = new Board();

            this.playerOne = new Player(Symbols.P1_MARKER);
            this.playerTwo = new Player(Symbols.P2_MARKER); 
        }


        public bool moveMarker(int location, string marker)
        {
            // Create new class currentMove or currentTurn to hold location/marker
            return currentBoard.placeMarker(location, marker);
        }

        // public bool checkIfWon()
        // {
        //     List<string> tempCombo = new List<string>();

        //     foreach (int combo in winCombinations)
        //     {
        //         Console.WriteLine(combo);
        //         foreach (int index in winCombinations[combo])
        //         {
        //             tempCombo.Add(currentBoard.board[index].marker);
        //         }
        //         tempCombo.TrueForAll(allSpacesMatch);
        //         {
        //             isWon = true;
        //             tempCombo.Clear();
        //         }
        //     }
        // }


        public bool isRowComplete(List <string> row, string marker) 
        {
            return row.All(space => space == marker) ? true : false; 
        }


    }
}


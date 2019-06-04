using System;
using System.Collections;
using System.Collections.Generic;

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

        public TicTacToe(string playerOneMarker)
        {
            this.currentBoard = new Board();
            this.playerOne = new Player(playerOneMarker);
            this.playerTwo = new Player("O"); 
        }

        // static void Main(string[] args)
        // {
        //     Console.WriteLine("Hello World!!!");
        // }

        public bool moveMarker(int location, string marker)
        {
            // Create new class currentMove or currentTurn to hold location/marker
            return currentBoard.placeMarker(location, marker);
        }


        public bool isRowComplete() // This isn't completed yet
        {
            // loop thru winCombos and check if player's marker is at all three of the indexes on the board list

            // var isWon = false;
            // List<string> tempCombo = new List<string>();

            // foreach (int combo in winCombinations)
            // {
            //     // Console.WriteLine(combo);
            //     foreach (int index in winCombinations[combo])
            //     {
            //         tempCombo.Add(currentBoard.board[index].marker);
            //     }
            //     tempCombo.TrueForAll(allSpacesMatch);
            //     {
            //         isWon = true;
            //         tempCombo.Clear();
            //     }
            // }
            // return isWon;
            return true;
        }

        private static bool allSpacesMatch(string marker)
        {
            return marker == "X";
        }

    }
}


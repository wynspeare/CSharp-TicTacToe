using System;
using System.Collections;
using System.Collections.Generic;


namespace TicTacToeApp
{
    public class Board
    {

        public List<string> board = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" }; // Fill board with instances of Space class

        public bool successfulMove = false;

        // Move winCombos to another class - board doesn't need to know this!
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


        public bool isSpaceEmpty(int location) // Maybe move to Space class? Each space knows if they are empty.
        {
            return board[location - 1] == location.ToString();
        }


        public bool placeMarker(Space space) 
        {
            if (isSpaceEmpty(space.location))
            {
                board[space.location - 1] = space.marker;
                Console.WriteLine("Your marker was successfully placed on space " + space.location.ToString());
                successfulMove = true;
                return successfulMove;
            }
            else
            {
                Console.WriteLine("Your move was invalid.");
                return successfulMove;
            }
        }

        public bool isRowComplete() // Move to another class with winCombos
        {
            // loop thru windCombos and check if player's marker is at all three of the indexes on the board list
            return true;
        }
    }
}


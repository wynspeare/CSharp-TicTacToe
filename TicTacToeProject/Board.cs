using System;
using System.Collections;
using System.Collections.Generic;


namespace TicTacToeApp
{
    public class Board
    {

        public List<Space> board = new List<Space>();
        public bool successfulMove = false;


        public Board()
        {
            for (int i = 1; i < 10; i++)
            {
                this.board.Add(new Space(i));
            }
        }


        public bool isEmpty()
        {
            var isBoardEmpty = true;
            foreach (Space space in board)
            {
                if(!space.isSpaceEmpty())
                {
                    isBoardEmpty = false;
                }
            }
            return isBoardEmpty;
        }


        public bool placeMarker(int location, string playerMarker) 
        {
            if (board[location - 1].isSpaceEmpty())
            {
                board[location - 1].marker = playerMarker;
                successfulMove = true;
                return successfulMove;
            }
            else
            {
                return successfulMove;
            }
        }

    }
}


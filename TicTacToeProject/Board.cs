using System;
using System.Collections;
using System.Collections.Generic;

namespace TicTacToeApp
{
    public class Board
    {

        public List<Space> board = new List<Space>(); 
        
        public Board()
        {
            for (int i = 1; i <= Symbols.BOARD_SIZE; i++)
            {
                this.board.Add(new Space(i));
            }
        }

        public bool isEmpty()
        {
            return board.TrueForAll(space => space.isSpaceEmpty());
        }

        public bool isFilled()
        {
            return board.TrueForAll(space => !space.isSpaceEmpty());
        }

        public bool placeMarker(int location, string playerMarker) 
        {
            if (board[location - 1].isSpaceEmpty())
            {
                board[location - 1].marker = playerMarker;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Dictionary<int, string> createDictBoard()
        {
            var dictBoard = new Dictionary<int, string>();
            foreach (Space space in board)
            {
                dictBoard.Add(space.location, space.marker);
            }
            return dictBoard;
        }
    }
}


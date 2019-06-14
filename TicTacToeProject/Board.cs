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

        public bool isBoardEmpty()
        {
            return board.TrueForAll(space => space.isSpaceEmpty());
        }

        public bool isBoardFilled()
        {
            return board.TrueForAll(space => !space.isSpaceEmpty());
        }

        public void placeMarker(int location, string playerMarker) 
        {
            board[location - 1].marker = playerMarker;
        }

        public string markerAtLocation(int location) 
        {
            return board[location - 1].marker;
        }

        public bool isSpaceOnBoardEmpty(int location)
        {
            return board[location - 1].isSpaceEmpty();
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


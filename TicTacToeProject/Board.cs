using System.Collections.Generic;
using System.Linq;

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

        public void partiallyFillBoard()
        {
            placeMarker(3, Symbols.P1_MARKER);
            placeMarker(4, Symbols.P1_MARKER);
            placeMarker(7, Symbols.P1_MARKER);

            placeMarker(1, Symbols.P2_MARKER);
            placeMarker(8, Symbols.P2_MARKER);
            placeMarker(9, Symbols.P2_MARKER);
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

        public List<int> getAvailableSpaces()
        {
            return board
                .Where(space => space.isSpaceEmpty())
                .Select(space => space.location)
                .ToList();
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


using System.Collections.Generic;
using System.Linq;

namespace TicTacToeApp
{
    public class Board
    {
        public List<Space> spaces = new List<Space>(); 
        
        public Board()
        {
            for (int i = 1; i <= Symbols.BOARD_SIZE; i++)
            {
                this.spaces.Add(new Space(i));
            }
        }

        public void partiallyFillBoard(int[] moves, string marker)
        {
            for (int i = 0; i < moves.GetLength(0); i++)
            {
                placeMarker(moves[i], marker);
            }
        }

        public bool isBoardEmpty()
        {
            return spaces.TrueForAll(space => space.isSpaceEmpty());
        }

        public bool isBoardFilled()
        {
            return spaces.TrueForAll(space => !space.isSpaceEmpty());
        }

        public void placeMarker(int location, string playerMarker) 
        {
            spaces[location - 1].marker = playerMarker;
        }

        public string markerAtLocation(int location) 
        {
            return spaces[location - 1].marker;
        }

        public bool isSpaceOnBoardEmpty(int location)
        {
            return spaces[location - 1].isSpaceEmpty();
        }

        public List<int> getAvailableSpaces()
        {
            return spaces
                .Where(space => space.isSpaceEmpty())
                .Select(space => space.location)
                .ToList();
        }

        public Dictionary<int, string> createDictBoard()
        {
            var dictBoard = new Dictionary<int, string>();
            foreach (Space space in spaces)
            {
                dictBoard.Add(space.location, space.marker);
            }
            return dictBoard;
        }

        public string getCurrentPlayer() {
            int totalMovesOnBoard = 9 - getAvailableSpaces().Count;
            if (totalMovesOnBoard % 2 == 0)
            {
                return Symbols.P1_MARKER;
            }
            else
            {
                return Symbols.P2_MARKER;
            }
        }
    }
}


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

        public void PartiallyFillBoard(int[] moves, string marker)
        {
            for (int i = 0; i < moves.GetLength(0); i++)
            {
                PlaceMarker(moves[i], marker);
            }
        }

        public bool IsBoardEmpty()
        {
            return spaces.TrueForAll(space => space.IsSpaceEmpty());
        }

        public bool IsBoardFilled()
        {
            return spaces.TrueForAll(space => !space.IsSpaceEmpty());
        }

        public void PlaceMarker(int location, string playerMarker) 
        {
            spaces[location - 1].marker = playerMarker;
        }

        public string MarkerAtLocation(int location) 
        {
            return spaces[location - 1].marker;
        }

        public bool IsSpaceOnBoardEmpty(int location)
        {
            return spaces[location - 1].IsSpaceEmpty();
        }

        public List<int> GetAvailableSpaces()
        {
            return spaces
                .Where(space => space.IsSpaceEmpty())
                .Select(space => space.location)
                .ToList();
        }

        public Dictionary<int, string> CreateDictBoard()
        {
            var dictBoard = new Dictionary<int, string>();
            foreach (Space space in spaces)
            {
                dictBoard.Add(space.location, space.marker);
            }
            return dictBoard;
        }

        public string GetCurrentPlayer() {
            int totalMovesOnBoard = 9 - GetAvailableSpaces().Count;
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


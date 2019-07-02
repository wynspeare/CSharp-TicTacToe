using System.Linq;

namespace TicTacToeApp
{
    public class GameState
    {
        public Board currentBoard;


        public GameState()
        {
            this.currentBoard = new Board();
        }

        public Board getCurrentGameState()
        {
            return currentBoard;
        }

    }
}

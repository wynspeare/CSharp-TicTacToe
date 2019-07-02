using System;

namespace TicTacToeApp
{
    public class Configuration
    {
        public IStrategy strategy;
        public Board board;

        public Configuration(bool isEasyGame, Board board)
        {
            if (isEasyGame)
            {
                strategy = new EasyStrategy(board);
            }
            else
            {
                strategy = new MinimaxStrategy(board);
            }
        }

    }
}
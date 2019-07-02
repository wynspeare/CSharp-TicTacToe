using System;

namespace TicTacToeApp
{
    public class Configuration
    {
        public IStrategy strategy;
        public Board board;

        public Configuration(bool isEasyGame)
        {
            if (isEasyGame)
            {
                strategy = new EasyStrategy();
            }
            else
            {
                strategy = new MinimaxStrategy();
            }
        }

    }
}
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


        // Method to reach into CompPlayer and inject strategy into players after the player has been created.
        // public void setStrategies(IPlayer player)
        // {
        //     player.strategy = strategy;     
        // }
    }
}
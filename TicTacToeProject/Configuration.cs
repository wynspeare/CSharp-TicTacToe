using System;

namespace TicTacToeApp
{
    public class Configuration
    {
        public IStrategy strategy;
        public Board board;
        public bool isSinglePlayer;

        public Configuration(bool isEasyGame, Board board, bool isSinglePlayer)
        {
            this.isSinglePlayer = isSinglePlayer;
            if (isEasyGame)
            {
                strategy = new EasyStrategy(board);
            }
            // else
            // {
            //     strategy = new MinimaxStrategy(game);
            // }
        }

        //Method to reach into CompPlayer and inject strategy into players after the player has been created.
        public void setStrategies(ComputerPlayer player)
        {
            player.strategy = strategy;     
        }
    }
}
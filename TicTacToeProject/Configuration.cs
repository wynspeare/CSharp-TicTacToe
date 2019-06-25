using System;

namespace TicTacToeApp
{
    public class Configuration
    {
        public IStrategy strategy;
        public TicTacToe game;
        public bool isSinglePlayer;

        public Configuration(bool isEasyGame, TicTacToe game, bool isSinglePlayer)
        {
            this.game = game;
            this.isSinglePlayer = isSinglePlayer;
            if (isEasyGame)
            {
                strategy = new EasyStrategy(game);
            }
            else
            {
                strategy = new MinimaxStrategy(game);
            }

        }

        //Method to reach into CompPlayer and inject strategy into players after the player has been created.
        public void setStrategies()
        {
            if (isSinglePlayer)
            {
                game.playerTwo.strategy = strategy;
            }       
        }
    }
}
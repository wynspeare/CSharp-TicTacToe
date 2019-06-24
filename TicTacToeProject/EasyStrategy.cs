using System;
using System.Collections.Generic;
using System.Linq;


namespace TicTacToeApp
{
    public class EasyStrategy : IStrategy
    {
        public TicTacToe game;

        public EasyStrategy(TicTacToe game)
        {
            this.game = game;
        }

        public string getMove()
        {
            string location = getRandomSpace().ToString();
            Console.WriteLine("\nThe computer selected space {0}.", location);
            return location;
        }

        private int getRandomSpace()
        {
            Random random = new Random();
            int index = random.Next(game.currentBoard.getAvailableSpaces().Count);
            return game.currentBoard.getAvailableSpaces()[index];
        }

    }
}


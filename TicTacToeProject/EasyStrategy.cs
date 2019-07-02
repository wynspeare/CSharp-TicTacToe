using System;
using System.Collections.Generic;
using System.Linq;


namespace TicTacToeApp
{
    public class EasyStrategy : IStrategy
    {
        public Board board;

        public EasyStrategy(Board board)
        {
            this.board = board;
        }

        public string getMove(string Marker)
        {
            string location = getRandomSpace().ToString();
            Console.WriteLine("\nThe computer selected space {0}.", location);
            return location;
        }

        private int getRandomSpace()
        {
            Random random = new Random();
            int index = random.Next(board.getAvailableSpaces().Count);
            return board.getAvailableSpaces()[index];
        }
    }
}


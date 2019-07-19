using System;
using System.Collections.Generic;
using System.Linq;


namespace TicTacToeApp
{
    public class EasyStrategy : IStrategy
    {
        public string GetMove(string Marker, Board Board)
        {
            string location = getRandomSpace(Board).ToString();
            Console.WriteLine("\nThe computer selected space {0}.", location);
            return location;
        }

        private int getRandomSpace(Board Board)
        {
            Random random = new Random();
            int index = random.Next(Board.GetAvailableSpaces().Count);
            return Board.GetAvailableSpaces()[index];
        }
    }
}


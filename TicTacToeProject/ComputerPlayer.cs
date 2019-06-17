using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeApp
{
    public class ComputerPlayer : PlayerInterface
    {
        private string _marker;

        public ComputerPlayer(string marker)
        {
            _marker = marker;
        }

        public string marker
        {
            get
            {
                return _marker;
            }
            set
            {
                _marker = value;
            }
        }       

        public string getMove(List<int> availableSpaces)
        {
            var move = getRandomSpace(availableSpaces);
            return move.ToString();
        }

        private int getRandomSpace(List<int> availableSpaces)
        {
            Random random = new Random();
            int index = random.Next(availableSpaces.Count);
            return availableSpaces[index];
        }

    }

}
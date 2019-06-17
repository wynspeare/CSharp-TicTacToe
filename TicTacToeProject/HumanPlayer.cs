using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeApp
{
    class HumanPlayer : PlayerInterface
    {
        private string _marker;

        public HumanPlayer(string marker)
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
            return Console.ReadLine();
        }
    }

}
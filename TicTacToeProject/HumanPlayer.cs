using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeApp
{
    class HumanPlayer : PlayerInterface
    {
        private string _marker;
        private Board _board;
        
        public HumanPlayer(string marker, Board board)
        {
            _marker = marker;
            _board = board;
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
        
        public Board board
        {
            get
            {
                return _board;
            }
            set
            {
                _board = value;
            }
        }       

        public string getMove()
        {
            return Console.ReadLine();
        }
    }

}
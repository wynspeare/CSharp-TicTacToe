using System;

namespace TicTacToeApp
{
    public class ComputerPlayer : PlayerInterface
    {
        private string _marker;
        private Board _board;

        public ComputerPlayer(string marker, Board board)
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
            string location = getRandomSpace().ToString();
            Console.WriteLine("\nThe computer selected space {0}.", location);
            return location;
        }

        private int getRandomSpace()
        {
            Random random = new Random();
            int index = random.Next(_board.getAvailableSpaces().Count);
            return _board.getAvailableSpaces()[index];
        }
    }
}
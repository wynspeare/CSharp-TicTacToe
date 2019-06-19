using System;

namespace TicTacToeApp
{
    public class HumanPlayer : PlayerInterface
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
            return getValidSpace();
        }
        
        private string getValidSpace()
        {
            var location = getSpace();
            while(!isValidSpace(location))
            {
                Console.Write("Try again! ");                
                location = getSpace();
            }
            return location;
        }

        public bool isValidSpace(string location)
        {   
            try
            {
                var convertedLocation = Convert.ToInt32(location);
                return _board.getAvailableSpaces().Contains(convertedLocation);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please only enter a number.");
                return false;
            }
        }

        private string getSpace()
        {
            return Console.ReadLine();
        }
    }

}
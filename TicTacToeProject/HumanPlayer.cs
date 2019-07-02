using System;

namespace TicTacToeApp
{
    public class HumanPlayer : IPlayer
    {
        public string Marker { get; set; }
        public Board Board;

        public HumanPlayer(string Marker, Board Board)
        {
            this.Marker = Marker;
            this.Board = Board;
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
                return Board.getAvailableSpaces().Contains(convertedLocation);
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
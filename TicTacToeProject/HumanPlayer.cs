using System;

namespace TicTacToeApp
{
    public class HumanPlayer : IPlayer
    {
        public string Marker { get; set; }

        public HumanPlayer(string Marker)
        {
            this.Marker = Marker;
            // this.rules = rules;
        }

        public string getMove(Board Board)
        {      
            return getValidSpace(Board);
        }
        
        private string getValidSpace(Board Board)
        {
            var location = getSpace();
            while(!isValidSpace(location, Board))
            {
                Console.Write("Try again! ");                
                location = getSpace();
            }
            return location;
        }

        public bool isValidSpace(string location, Board Board)
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
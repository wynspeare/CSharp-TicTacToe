using System;

namespace TicTacToeApp
{
    public class ComputerPlayer : IPlayer
    {
        public string Marker { get; set; }
        public IStrategy strategy;
        
        public ComputerPlayer(string Marker)
        {
            this.Marker = Marker;
        }

        public string getMove()
        {
            return strategy.getMove();
        }
    }
}
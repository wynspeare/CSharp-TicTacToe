using System;

namespace TicTacToeApp
{
    public class ComputerPlayer : IPlayer
    {
        public string Marker { get; set; }
        public IStrategy strategy;
        
        public ComputerPlayer(string Marker, IStrategy strategy)
        {
            this.Marker = Marker;
            this.strategy = strategy;
        }

        public string GetMove(Board Board)
        {
            return strategy.GetMove(Marker, Board);
        }
    }
}
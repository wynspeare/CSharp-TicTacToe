using System;

namespace TicTacToeApp
{
    public class Move 
    {
        public int location;
        public string marker;

        public Move(int location, string marker)
        {
            this.location = location;
            this.marker = marker;
        }
    }
}
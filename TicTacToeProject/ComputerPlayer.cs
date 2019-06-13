using System;
using System.Collections.Generic;


namespace TicTacToeApp
{
    public class ComputerPlayer
    {
        public string marker;

        public ComputerPlayer(string marker = "o")
        {
            this.marker = marker;
        }

        public int getRandomSpace()
        {
            Random random = new Random();
            return random.Next(1, 10);  
            
        }

        public bool isValidSpace(int location, Dictionary<int, string> board)
        {   
            return board[location] == Symbols.EMPTY;
        }



        public int getValidSpace(Dictionary<int, string> board)
        {
            
            var location = getRandomSpace();
            while (!isValidSpace(location, board))
            {   
                location = getRandomSpace();
            }
            return location;
        }

    }
}
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

        public bool isFilledSpace(int location, List<Space> board)
        {   
            return board[location - 1].isSpaceFilled();
        }

        public int getValidSpace(List<Space> board)
        {
            var location = getRandomSpace();
            while (isFilledSpace(location, board))
            {   
                location = getRandomSpace();
            }
            return location;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeApp
{

    public interface PlayerInterface
    {
        string marker
        {
            get;
            set;
        }

        int getRandomSpace();
        bool isFilledSpace(int location, List<Space> board);
        int getValidSpace(List<Space> board);
    }

    class IHumanPlayer : PlayerInterface
    {
        private string _marker;

        public IHumanPlayer(string marker)
        {
            _marker = marker;
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

    class IComputerPlayer : PlayerInterface
    {
        public string marker
        {
            get;
            set;
        }

        public IComputerPlayer(string marker)
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
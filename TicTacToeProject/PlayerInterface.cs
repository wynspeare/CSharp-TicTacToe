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

        string getMove();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace TicTacToeApp
{
    public class Space
    {
        public int location;
        public string marker;

        public Space(int location, string marker = Symbols.EMPTY)
        {
            this.location = location;
            this.marker = marker;
        }

        public bool isSpaceEmpty()
        {
            return marker == Symbols.EMPTY;
        }

    }
}  

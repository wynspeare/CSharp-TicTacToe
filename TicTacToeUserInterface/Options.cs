using System;
using TicTacToeApp;

namespace TicTacToeUserInterface
{
    public class Options {

        public string P1_MARKER;
        public string P2_MARKER;

        public const string EMPTY = Symbols.EMPTY;
        public const int BOARD_SIZE = Symbols.BOARD_SIZE;
        public bool IS_SINGLE_PLAYER;

        public Options (Tuple<string, string> markers, bool isSinglePlayer = false)
        {
            this.P1_MARKER = markers.Item1;
            this.P2_MARKER = markers.Item2;
            this.IS_SINGLE_PLAYER = isSinglePlayer;
        }
    }
}
using System;
using TicTacToeApp;
using System.Collections.Generic;


namespace TicTacToeUserInterface
{
    public class Options {

        public string P1_MARKER;
        public string P2_MARKER;

        public const string EMPTY = Symbols.EMPTY;
        public const int BOARD_SIZE = Symbols.BOARD_SIZE;
        public bool IS_SINGLE_PLAYER;

        public Dictionary<int, List<string>> playerTypes = new Dictionary<int, List<string>>();


        public Options (Tuple<string, string> markers, bool isSinglePlayer = false)
        {
            this.P1_MARKER = markers.Item1;
            this.P2_MARKER = markers.Item2;
            this.IS_SINGLE_PLAYER = isSinglePlayer;

            playerTypes.Add(1, new List<string> { "computer", markers.Item1, "hard"});
            playerTypes.Add(2, new List<string> { "computer", markers.Item2, "easy" });

            // playerTypes.Add(1, new List<string> { "human", markers.Item1 });
            // playerTypes.Add(2, new List<string> { "computer", markers.Item2, "easy"});


        }
    }
}
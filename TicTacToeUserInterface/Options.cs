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


        public Options (Tuple<string, string> markers, bool isSinglePlayer)
        {
            this.P1_MARKER = markers.Item1;
            this.P2_MARKER = markers.Item2;
            this.IS_SINGLE_PLAYER = isSinglePlayer;

            // playerTypes.Add(1, new List<string> { "computer", markers.Item1, "hard"});
            // playerTypes.Add(2, new List<string> { "computer", markers.Item2, "easy" });
        }
    
        public void setPlayer(bool isSinglePlayer, bool isEasyGame = false, bool isHumanFirst = false)
        {
            if (isSinglePlayer && isHumanFirst && isEasyGame) //easy human first
            {
                playerTypes.Add(1, new List<string> { "human", P1_MARKER});
                playerTypes.Add(2, new List<string> { "computer", P2_MARKER, "easy"});
            } 
            else if (isSinglePlayer && isHumanFirst) //minimax human first
            {
                playerTypes.Add(1, new List<string> { "human", P1_MARKER});
                playerTypes.Add(2, new List<string> { "computer", P2_MARKER, "hard"});
            }
            else if (isEasyGame) // easy comp first
            {
                playerTypes.Add(1, new List<string> { "computer", P1_MARKER, "easy"});
                playerTypes.Add(2, new List<string> { "human", P2_MARKER});
            }
            else if (isSinglePlayer) //minimax comp first
            {
                playerTypes.Add(1, new List<string> { "computer", P1_MARKER, "hard"});
                playerTypes.Add(2, new List<string> { "human", P2_MARKER});
            }
            else // human game
            {
                playerTypes.Add(1, new List<string> { "human", P1_MARKER});
                playerTypes.Add(2, new List<string> { "human", P2_MARKER});
            }
        }
    }
}
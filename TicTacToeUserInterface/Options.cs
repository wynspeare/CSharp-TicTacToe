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

        public Dictionary<string, List<string>> playerTypes = new Dictionary<string, List<string>>();

        public Options (Tuple<string, string> markers, bool isSinglePlayer)
        {
            this.P1_MARKER = markers.Item1;
            this.P2_MARKER = markers.Item2;
            this.IS_SINGLE_PLAYER = isSinglePlayer;
        }
    
        public void setPlayer(bool isSinglePlayer, bool isEasyGame, bool isHumanFirst, bool isCompVCompGame)
        {
            if (isCompVCompGame)
            {
                playerTypes.Add(P1_MARKER, new List<string> { "computer", "hard"});
                playerTypes.Add(P2_MARKER, new List<string> { "computer", "easy"});
            }
            else if (isSinglePlayer && isHumanFirst && isEasyGame) //easy human first
            {
                playerTypes.Add(P1_MARKER, new List<string> { "human" });
                playerTypes.Add(P2_MARKER, new List<string> { "computer", "easy"});
            } 
            else if (isSinglePlayer && isHumanFirst) //minimax human first
            {
                playerTypes.Add(P1_MARKER, new List<string> { "human" });
                playerTypes.Add(P2_MARKER, new List<string> { "computer", "hard"});
            }
            else if (isEasyGame) // easy comp first
            {
                playerTypes.Add(P1_MARKER, new List<string> { "computer", "easy"});
                playerTypes.Add(P2_MARKER, new List<string> { "human" });
            }
            else if (isSinglePlayer) //minimax comp first
            {
                playerTypes.Add(P1_MARKER, new List<string> { "computer", "hard"});
                playerTypes.Add(P2_MARKER, new List<string> { "human" });
            }
            else // human game
            {
                playerTypes.Add(P1_MARKER, new List<string> { "human" });
                playerTypes.Add(P2_MARKER, new List<string> { "human"});
            }
        }
    }
}
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

        public Dictionary<string, List<string>> playerTypes = new Dictionary<string, List<string>>();

        public Options (Tuple<string, string> markers, bool isSinglePlayer = false, bool isEasyGame = false, bool isHumanFirst = false, bool isCompVCompGame = false)
        {
            this.P1_MARKER = markers.Item1;
            this.P2_MARKER = markers.Item2;
            this.setPlayers(isSinglePlayer, isEasyGame, isHumanFirst, isCompVCompGame);
        }
    
        private void setPlayers(bool isSinglePlayer, bool isEasyGame, bool isHumanFirst, bool isCompVCompGame)
        {
            if (isCompVCompGame)
            {
                playerTypes.Add(P1_MARKER, new List<string> { "computer", "hard"});
                playerTypes.Add(P2_MARKER, new List<string> { "computer", "easy"});
            }
            else if (isSinglePlayer && isHumanFirst && isEasyGame)
            {
                playerTypes.Add(P1_MARKER, new List<string> { "human" });
                playerTypes.Add(P2_MARKER, new List<string> { "computer", "easy"});
            } 
            else if (isSinglePlayer && isHumanFirst)
            {
                playerTypes.Add(P1_MARKER, new List<string> { "human" });
                playerTypes.Add(P2_MARKER, new List<string> { "computer", "hard"});
            }
            else if (isEasyGame)
            {
                playerTypes.Add(P1_MARKER, new List<string> { "computer", "easy"});
                playerTypes.Add(P2_MARKER, new List<string> { "human" });
            }
            else if (isSinglePlayer)
            {
                playerTypes.Add(P1_MARKER, new List<string> { "computer", "hard"});
                playerTypes.Add(P2_MARKER, new List<string> { "human" });
            }
            else
            {
                playerTypes.Add(P1_MARKER, new List<string> { "human" });
                playerTypes.Add(P2_MARKER, new List<string> { "human"});
            }
        }
    }
}
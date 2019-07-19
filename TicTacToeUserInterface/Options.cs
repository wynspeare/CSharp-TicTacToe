using System;
using TicTacToeApp;
using System.Collections.Generic;


namespace TicTacToeUserInterface
{
    public class Options {

        enum PlayerSetting {human, easy, hard};

        public string P1_MARKER;
        public string P2_MARKER;

        public const string EMPTY = Symbols.EMPTY;
        public const int BOARD_SIZE = Symbols.BOARD_SIZE;

        public Dictionary<string, string> playerTypes = new Dictionary<string, string>();
        public Options (Tuple<string, string> markers, int p1Setting, int p2Setting)
        {
            this.P1_MARKER = markers.Item1;
            this.P2_MARKER = markers.Item2;
            this.setPlayers(p1Setting, p2Setting);
        }

        private void setPlayers(int p1Setting, int p2Setting)
        {
                PlayerSetting p1 = (PlayerSetting)p1Setting;
                PlayerSetting p2 = (PlayerSetting)p2Setting;

                playerTypes.Add(P1_MARKER, p1.ToString());
                playerTypes.Add(P2_MARKER, p2.ToString());
        }
    }
}


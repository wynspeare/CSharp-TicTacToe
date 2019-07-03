using System;
using System.Collections.Generic;

namespace TicTacToeApp
{
    public class Configuration
    {
        public IStrategy strategy;

        public Configuration(string playerOneMarker, string playerTwoMarker)

        {
            Symbols.P1_MARKER = playerOneMarker;
            Symbols.P2_MARKER = playerTwoMarker;
        }

        public List<IPlayer> buildPlayers(Dictionary<int, List<string>> playerTypes)
        {
            var builtPlayers = new List<IPlayer>();
            foreach (KeyValuePair<int, List<string>> player in playerTypes)
            {            
                if (player.Value[0] == "human")
                {
                    var newPlayer = new HumanPlayer(player.Value[1]);
                    Console.WriteLine(newPlayer.Marker + " Human");
                    builtPlayers.Add(newPlayer);
                }
                else
                {
                    if (player.Value[2] == "easy")
                    {
                        var newPlayer = new ComputerPlayer(player.Value[1], new EasyStrategy());
                        Console.WriteLine(newPlayer.Marker + " Easy");

                        builtPlayers.Add(newPlayer);
                    }
                    else
                    {
                        var newPlayer = new ComputerPlayer(player.Value[1], new MinimaxStrategy());
                        Console.WriteLine(newPlayer.Marker + " Minimax");
                        builtPlayers.Add(newPlayer);
                    }
                }
            }
            return builtPlayers;
        }
    }
}
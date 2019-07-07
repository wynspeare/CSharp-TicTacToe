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

        public List<IPlayer> buildPlayers(Dictionary<string, List<string>> playerTypes)
        {
            var builtPlayers = new List<IPlayer>();
            foreach (KeyValuePair<string, List<string>> player in playerTypes)
            {            
                if (player.Value[0] == "human")
                {
                    var newPlayer = new HumanPlayer(player.Key);
                    Console.WriteLine("Player \"{0}\" is a human", newPlayer.Marker);
                    builtPlayers.Add(newPlayer);
                }
                else
                {
                    if (player.Value[1] == "easy")
                    {
                        var newPlayer = new ComputerPlayer(player.Key, new EasyStrategy());
                        Console.WriteLine("Player \"{0}\" is a random computer", newPlayer.Marker);
                        builtPlayers.Add(newPlayer);
                    }
                    else
                    {
                        var newPlayer = new ComputerPlayer(player.Key, new MinimaxStrategy());
                        Console.WriteLine("Player \"{0}\" is an unbeatable computer", newPlayer.Marker);
                        builtPlayers.Add(newPlayer);
                    }
                }
            }
            return builtPlayers;
        }
    }
}
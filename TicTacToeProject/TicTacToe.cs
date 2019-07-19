using System;
using System.Collections.Generic;


namespace TicTacToeApp
{
    public class TicTacToe
    {
        public Rules rules;
        public Board currentBoard;
        public IPlayer playerOne;
        public IPlayer playerTwo;
        public IPlayer currentPlayer;

        public TicTacToe(List<IPlayer> players)
        {
            this.currentBoard = new Board();
            this.rules = new Rules();
            this.playerOne = players[0];
            this.playerTwo = players[1];
            this.currentPlayer = this.playerOne;
        }

        public int GetCurrentMove(IPlayer player)
        {
            return Convert.ToInt32(player.GetMove(currentBoard));
        }

        public bool Turn(int location)
        {
            MoveMarker(location, currentPlayer.Marker);
            
            bool notWon = !rules.CheckIfWon(currentBoard.spaces, currentPlayer.Marker);
            bool notDrawn = !rules.CheckIfDraw(currentBoard, currentPlayer.Marker);
            bool notOver = notWon && notDrawn;
            if (notOver)
            {
                SwitchPlayer();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == playerOne) ? playerTwo : playerOne;
        }

        public void MoveMarker(int location, string marker)
        {
            currentBoard.PlaceMarker(location, marker);
        }

    }
}


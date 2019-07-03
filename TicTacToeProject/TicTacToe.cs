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

        public int getCurrentMove(IPlayer player)
        {
            return Convert.ToInt32(player.getMove(currentBoard));
        }

        public bool turn(int location)
        {
            moveMarker(location, currentPlayer.Marker);
            
            bool notWon = !rules.checkIfWon(currentBoard.spaces, currentPlayer.Marker);
            bool notDrawn = !rules.checkIfDraw(currentBoard, currentPlayer.Marker);
            bool notOver = notWon && notDrawn;
            if (notOver)
            {
                switchPlayer();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void switchPlayer()
        {
            currentPlayer = (currentPlayer == playerOne) ? playerTwo : playerOne;
        }

        public void moveMarker(int location, string marker)
        {
            currentBoard.placeMarker(location, marker);
        }

    }
}


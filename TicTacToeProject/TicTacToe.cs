using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeApp
{
    public class TicTacToe
    {
        public Rules rules;
        public Player playerOne;
        public Player playerTwo;

        public Board currentBoard;
        public Player currentPlayer;

        public TicTacToe(string playerOneMarker = "X", string playerTwoMarker = "O")
        {
            Symbols.P1_MARKER = playerOneMarker;
            Symbols.P2_MARKER = playerTwoMarker;

            this.currentBoard = new Board();
            this.rules = new Rules();

            this.playerOne = new Player(Symbols.P1_MARKER);
            this.playerTwo = new Player(Symbols.P2_MARKER);
            currentPlayer = this.playerOne;
        }

        public bool turn(int location)
        {
            moveMarker(location, currentPlayer.marker);
            if (!rules.checkIfWon(currentBoard.board, currentPlayer.marker) && !rules.checkIfDraw(currentBoard, currentPlayer.marker))
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


        public bool moveMarker(int location, string marker)
        {
            return currentBoard.placeMarker(location, marker);
        }

    }
}


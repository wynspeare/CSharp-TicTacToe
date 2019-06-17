using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeApp
{
    public class TicTacToe
    {
        public Rules rules;
        public Board currentBoard;
        public PlayerInterface playerOne;
        public PlayerInterface playerTwo;
        public PlayerInterface currentPlayer;

        public bool isSinglePlayer;

        
        public TicTacToe(string playerOneMarker = "X", string playerTwoMarker = "O", bool isSinglePlayer = false)
        {
            Symbols.P1_MARKER = playerOneMarker;
            Symbols.P2_MARKER = playerTwoMarker;
            this.currentBoard = new Board();
            this.rules = new Rules();
            this.playerOne = new IHumanPlayer(Symbols.P1_MARKER);
            
            if (isSinglePlayer) 
            {
                this.playerTwo = new IComputerPlayer(Symbols.P2_MARKER);
                this.isSinglePlayer = true;
            }
            else
            {
                this.playerTwo = new IHumanPlayer(Symbols.P2_MARKER);
            }
            this.currentPlayer = this.playerOne;
        }

        public bool turn(int location)
        {
            moveMarker(location, currentPlayer.marker);
            
            bool notWon = !rules.checkIfWon(currentBoard.board, currentPlayer.marker);
            bool notDrawn = !rules.checkIfDraw(currentBoard, currentPlayer.marker);
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


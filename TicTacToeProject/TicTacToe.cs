using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeApp
{
    public class TicTacToe
    {
        public Rules rules;
        public HumanPlayer playerOne;
        public HumanPlayer playerTwo;
        public ComputerPlayer compPlayer;
        public Board currentBoard;
        public string currentPlayerMarker;
        public bool isSinglePlayer;

        public TicTacToe(string playerOneMarker = "X", string playerTwoMarker = "O", bool isSinglePlayer = false)
        {
            Symbols.P1_MARKER = playerOneMarker;
            Symbols.P2_MARKER = playerTwoMarker;
            this.currentBoard = new Board();
            this.rules = new Rules();
            this.playerOne = new HumanPlayer(Symbols.P1_MARKER);
            
            if (isSinglePlayer) 
            {
                this.compPlayer = new ComputerPlayer(Symbols.P2_MARKER);
                this.isSinglePlayer = true;
            }
            else
            {
                this.playerTwo = new HumanPlayer(Symbols.P2_MARKER);
            }
            this.currentPlayerMarker = this.playerOne.marker;
        }

        public bool turn(int location)
        {
            
            moveMarker(location, currentPlayerMarker);
            
            bool notWon = !rules.checkIfWon(currentBoard.board, currentPlayerMarker);
            bool notDrawn = !rules.checkIfDraw(currentBoard, currentPlayerMarker);
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
            if (isSinglePlayer) 
            {
                currentPlayerMarker = (currentPlayerMarker == playerOne.marker) ? compPlayer.marker : playerOne.marker;
            }
            else 
            {
                currentPlayerMarker = (currentPlayerMarker == playerOne.marker) ? playerTwo.marker : playerOne.marker;
            }
        }

        public void moveMarker(int location, string marker)
        {
            currentBoard.placeMarker(location, marker);
        }

    }
}


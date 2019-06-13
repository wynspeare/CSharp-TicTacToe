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

        public TicTacToe(string playerOneMarker = "X", string playerTwoMarker = "O", bool isSinglePlayer = true)
        {
            Symbols.P1_MARKER = playerOneMarker;
            Symbols.P2_MARKER = playerTwoMarker;
            this.currentBoard = new Board();
            this.rules = new Rules();

            if (isSinglePlayer) 
            {
                this.playerOne = new HumanPlayer(Symbols.P1_MARKER);
                this.compPlayer = new ComputerPlayer(Symbols.P2_MARKER);
                this.isSinglePlayer = true;
            }
            else
            {
                this.playerOne = new HumanPlayer(Symbols.P1_MARKER);
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

        // public bool computerTurn()
        // {
        //     var compsCurrentSpace = compPlayer.getValidSpace(currentBoard.createDictBoard());
        //     moveMarker(compsCurrentSpace, compPlayer.marker);
                
        //         bool notWon = !rules.checkIfWon(currentBoard.board, compPlayer.marker);
        //         bool notDrawn = !rules.checkIfDraw(currentBoard, compPlayer.marker);
        //         bool notOver = notWon && notDrawn;

        //         if (notOver)
        //         {
        //             switchPlayer();
        //             return true;
        //         }
        //         else
        //         {
        //             return false;
        //         }
            
        // }


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

        public bool moveMarker(int location, string marker)
        {
            return currentBoard.placeMarker(location, marker);
        }

    }
}


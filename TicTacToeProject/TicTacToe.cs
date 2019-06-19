using System;

namespace TicTacToeApp
{
    public class TicTacToe
    {
        public Rules rules;
        public Board currentBoard;
        public PlayerInterface playerOne;
        public PlayerInterface playerTwo;
        public PlayerInterface currentPlayer;
        
        public TicTacToe(string playerOneMarker = "X", string playerTwoMarker = "O", bool isSinglePlayer = false)
        {
            Symbols.P1_MARKER = playerOneMarker;
            Symbols.P2_MARKER = playerTwoMarker;
            this.currentBoard = new Board();
            this.rules = new Rules();
            this.playerOne = new HumanPlayer(Symbols.P1_MARKER, this.currentBoard);
            this.currentPlayer = this.playerOne;
            
            if (isSinglePlayer) 
            {
                this.playerTwo = new ComputerPlayer(Symbols.P2_MARKER, this.currentBoard);
            }
            else
            {
                this.playerTwo = new HumanPlayer(Symbols.P2_MARKER, this.currentBoard);
            }
        }

        public int getCurrentMove(PlayerInterface player)
        {
            return Convert.ToInt32(player.getMove());
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


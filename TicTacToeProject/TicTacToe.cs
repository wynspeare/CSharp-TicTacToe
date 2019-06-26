using System;

namespace TicTacToeApp
{
    public class TicTacToe
    {
        public Rules rules;
        public Board currentBoard;
        public IPlayer playerOne;
        public IPlayer playerTwo;
        public IPlayer currentPlayer;
        
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
                var isEasyGame = false; //Need to pass in correct bool for easy/hard
                var configuration = new Configuration(isEasyGame, this.currentBoard); 

                this.playerTwo = new ComputerPlayer(Symbols.P2_MARKER, configuration.strategy);

                configuration.strategy.setPlayers(this.playerTwo, this.playerOne); //Have board query itself for whose turn it is
            }
            else
            {
                this.playerTwo = new HumanPlayer(Symbols.P2_MARKER, this.currentBoard);
            }
        }

        public int getCurrentMove(IPlayer player)
        {
            return Convert.ToInt32(player.getMove());
        }

        public bool turn(int location)
        {
            moveMarker(location, currentPlayer.Marker);
            
            bool notWon = !rules.checkIfWon(currentBoard.board, currentPlayer.Marker);
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


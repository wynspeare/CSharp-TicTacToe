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
                var configuration = new Configuration(false, this.currentBoard);

                this.playerTwo = new ComputerPlayer(Symbols.P2_MARKER, configuration.strategy);

                configuration.strategy.setPlayers(this.playerTwo, this.playerOne);
            }
            else
            {
                this.playerTwo = new HumanPlayer(Symbols.P2_MARKER, this.currentBoard);
            }
        }

        public TicTacToe(TicTacToe originalGame)
        {
            this.currentBoard = originalGame.changeBoard();
            this.rules = originalGame.rules;
            this.playerOne = originalGame.playerOne;
            this.playerTwo = originalGame.playerTwo;
            this.currentPlayer = originalGame.currentPlayer;
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



        public Board changeBoard()
        {
            var possibleBoard = new Board();
            for (int i = 1; i <= Symbols.BOARD_SIZE; i++)
            {
                if (currentBoard.board[i - 1].isSpaceFilled())
                {
                    possibleBoard.board[i - 1].marker = currentBoard.board[i - 1].marker;
                }                
            }
            return possibleBoard;
        }

        public TicTacToe getNewState(TicTacToe game, int move)
        {
            //get a copy of a game with a new move applied
            var possibleGame = new TicTacToe(game);
            possibleGame.turn(move);
            return possibleGame;
        }

    }
}


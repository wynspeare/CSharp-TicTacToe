using System;
using TicTacToeApp;
using TicTacToeUserInterface;


namespace TicTacToeRunner
{
    class Runner
    {
        public TicTacToe newGame;
        public UserInterface gameUI;
        public bool isGameOver = false;


        static void Main(string[] args)
        {
            var runner = new Runner();
            runner.createGame();
        }


        public void createGame()
        {
            gameUI = new UserInterface();
            if (gameUI.startNewGame())
            {
                var options = new Options(gameUI.setMarkers());
                newGame = new TicTacToe(options.P1_MARKER, options.P2_MARKER);

                while (!isGameOver)
                {
                    playGameLoop();
                }
            }
        }


        public void playGameLoop()
        {
            if (newGame.turn(gameUI.getValidSpace(newGame.currentBoard.board, newGame.currentPlayer.marker)))
            {
                playGameLoop();
            }
            else
            {
                getCompletedGameStatus(newGame.currentBoard, newGame.currentPlayer.marker);
                isGameOver = true;
            }
        }


        public void getCompletedGameStatus(Board board, string marker)
        {
            var isDraw = newGame.rules.checkIfDraw(board, marker);

            gameUI.displayBoard(board.board);
            gameUI.displayWinOrDraw(isDraw, marker);
        }


    }
}

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
                    playGame();
                }
            }
        }



        public void playGame()
        {
            if (newGame.turn(gameUI.getValidSpace(newGame.currentBoard.board)))
            {
                playGame();
            }
            else
            {
                // gameUI.winOrDraw(newGame.currentBoard);
                isGameOver = true;
            }
        }




    }
}

using System;

using TicTacToeApp;
using TicTacToeUserInterface;

namespace TicTacToeRunner
{
    class Runner
    {
        private TicTacToe newGame;
        private UserInterface gameUI;
        private Options options;
        private bool isGameOver = false;

        static void Main(string[] args)
        {
            var runner = new Runner();
            runner.createGame();
        }

        private void createGame()
        {
            gameUI = new UserInterface();
            if (gameUI.startNewGame())
            {
                var isSinglePlayer = gameUI.isSinglePlayerGame(gameUI.getTypeOfGame());
                options = new Options(gameUI.setMarkers(), isSinglePlayer);
                newGame = new TicTacToe(options.P1_MARKER, options.P2_MARKER, options.IS_SINGLE_PLAYER);
                while (!isGameOver)
                {
                    playGameLoop();
                }
            }
        }

        private void playGameLoop()
        {
            gameUI.displayBoard(newGame.currentBoard.createDictBoard());
            
            gameUI.askForMove(newGame.currentPlayer.Marker);

            int location = newGame.getCurrentMove(newGame.currentPlayer);
            
            bool successfulTurn = newGame.turn(location);
            if (successfulTurn)
            {
                playGameLoop();
            }
            else
            {
                getCompletedGameStatus(newGame.currentBoard, newGame.currentPlayer.Marker);
            }
        }

        private void getCompletedGameStatus(Board boardObject, string marker)
        {
            bool isDraw = newGame.rules.checkIfDraw(boardObject, marker);

            gameUI.displayBoard(newGame.currentBoard.createDictBoard());
            gameUI.displayWinOrDraw(isDraw, marker);
            getSinglePlayerGameStatus(marker, isDraw);
            isGameOver = true;
        }

        private void getSinglePlayerGameStatus(string marker, bool isDraw)
        {
            bool isSinglePlayerAndNotDraw = options.IS_SINGLE_PLAYER != isDraw;
            bool isHumansTurn = marker == newGame.playerOne.Marker;

            if ((isSinglePlayerAndNotDraw) && (isHumansTurn))
            {
                gameUI.displaySinglePlayerGameStatus(true);
            }
            else if (isSinglePlayerAndNotDraw)
            {
                gameUI.displaySinglePlayerGameStatus(false);
            }
        }
    }
}

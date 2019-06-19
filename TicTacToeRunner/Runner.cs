using System;
using TicTacToeApp;
using TicTacToeUserInterface;
using System.Collections.Generic;

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
            var availableSpaces = newGame.currentBoard.getAvailableSpaces();
            
            int selectedSpace = gameUI.getValidSpace(availableSpaces, newGame.currentBoard.createDictBoard(), newGame.currentPlayer);

            bool successfulTurn = newGame.turn(selectedSpace);
            if (successfulTurn)
            {
                if (newGame.playerTwo.GetType() == typeof(ComputerPlayer))
                {
                    compTurn();
                }
                else
                {
                    playGameLoop();
                }
            }
            else
            {
                getCompletedGameStatus(newGame.currentBoard, newGame.currentPlayer.marker);
            }
        }

        private void compTurn()
        {
            int compSelectedSpace = Convert.ToInt32(newGame.playerTwo.getMove());

            gameUI.displayComputersMove(compSelectedSpace);
            if (newGame.turn(compSelectedSpace))
            {
                playGameLoop();
            }
            else
            {
                getCompletedGameStatus(newGame.currentBoard, newGame.currentPlayer.marker);
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
            bool isHumansTurn = marker == newGame.playerOne.marker;

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

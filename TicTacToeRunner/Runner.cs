using System;
using TicTacToeApp;
using TicTacToeUserInterface;
using System.Collections.Generic;

namespace TicTacToeRunner
{
    class Runner
    {
        public TicTacToe newGame;
        public UserInterface gameUI;
        public Options options;
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
                var isSinglePlayer = gameUI.isSinglePlayerGame(gameUI.getTypeOfGame());
                options = new Options(gameUI.setMarkers(), isSinglePlayer);

                newGame = new TicTacToe(options.P1_MARKER, options.P2_MARKER, options.IS_SINGLE_PLAYER);

                while (!isGameOver)
                {
                    playGameLoop();
                }
            }
        }

        public void playGameLoop()
        {
            int selectedSpace = gameUI.getValidSpace(newGame.currentBoard.createDictBoard(), newGame.currentPlayerMarker);
            bool successfulTurn = newGame.turn(selectedSpace);
            if (successfulTurn)
            {
                if(options.IS_SINGLE_PLAYER)
                {
                    computerPlayerTurn();
                }
                else
                {
                    playGameLoop();
                }
            }
            else
            {
                getCompletedGameStatus(newGame.currentBoard, newGame.currentPlayerMarker);
            }
        }

        public void computerPlayerTurn()
        {
            int compSelectedSpace = newGame.compPlayer.getValidSpace(newGame.currentBoard.createDictBoard());
            if (newGame.turn(compSelectedSpace))
            {
                gameUI.displayComputersMove(compSelectedSpace);
                playGameLoop();
            }
            else
            {
                getCompletedGameStatus(newGame.currentBoard, newGame.currentPlayerMarker);
            }
        }

        public void getCompletedGameStatus(Board boardObject, string marker)
        {
            bool isDraw = newGame.rules.checkIfDraw(boardObject, marker);

            gameUI.displayBoard(newGame.currentBoard.createDictBoard());
            gameUI.displayWinOrDraw(isDraw, marker);
            getSinglePlayerGameStatus(marker, isDraw);
            isGameOver = true;
        }


        public void getSinglePlayerGameStatus(string marker, bool isDraw)
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

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
                int p1Setting = 0;
                int p2Setting = 0;
                var isSinglePlayer = gameUI.isUserInputYes(gameUI.getTypeOfGame());
                if (isSinglePlayer)
                {
                    if (gameUI.isUserInputYes(gameUI.getPlayerOrder()))
                    {
                        p1Setting = 0;
                        if (!gameUI.isUserInputYes(gameUI.getDifficultyLevel()))
                        {
                            p2Setting = 1;
                        }
                        else
                        {
                            p2Setting = 2;
                        }
                    }
                    else
                    {
                        p2Setting = 0;
                        if (!gameUI.isUserInputYes(gameUI.getDifficultyLevel()))
                        {
                            p1Setting = 1;
                        }
                        else
                        {
                            p1Setting = 2;
                        }
                    }
                }
                else
                {
                    if (gameUI.isUserInputYes(gameUI.isCompVCompGame()))
                    {
                        p1Setting = 2;
                        p2Setting = 1;
                    }
                }
                options = new Options(gameUI.setMarkers(), p1Setting, p2Setting);

                var config = new Configuration(options.P1_MARKER, options.P2_MARKER);

                var players = config.buildPlayers(options.playerTypes);
                
                newGame = new TicTacToe(players);
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
            isGameOver = true;
        }

    }
}

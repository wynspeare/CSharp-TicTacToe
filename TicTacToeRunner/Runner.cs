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
            runner.CreateGame();
        }

        private void CreateGame()
        {
            gameUI = new UserInterface();
            if (gameUI.StartNewGame())
            {
                int p1Setting = 0;
                int p2Setting = 0;
                var isSinglePlayer = gameUI.IsUserInputYes(gameUI.GetTypeOfGame());
                
                if (isSinglePlayer)
                {
                    if (gameUI.IsUserInputYes(gameUI.IsHumanFirst()))
                    {
                        p1Setting = 0;
                        p2Setting = gameUI.IsUserInputYes(gameUI.IsHardMode()) ? 2 : 1;
                    }
                    else
                    {
                        p2Setting = 0;
                        p1Setting = gameUI.IsUserInputYes(gameUI.IsHardMode()) ? 2 : 1;
                    }
                }
                else
                {
                    if (gameUI.IsUserInputYes(gameUI.IsCompVCompGame()))
                    {
                        p1Setting = 2;
                        p2Setting = 1;
                    }
                }
                options = new Options(gameUI.SetMarkers(), p1Setting, p2Setting);

                var config = new Configuration(options.P1_MARKER, options.P2_MARKER);

                var players = config.BuildPlayers(options.playerTypes);
                
                newGame = new TicTacToe(players);
                while (!isGameOver)
                {
                    PlayGameLoop();
                }
            }
        }

        private void PlayGameLoop()
        {
            gameUI.DisplayBoard(newGame.currentBoard.CreateDictBoard());
            
            gameUI.AskForMove(newGame.currentPlayer.Marker);

            int location = newGame.GetCurrentMove(newGame.currentPlayer);
            
            bool successfulTurn = newGame.Turn(location);
            if (successfulTurn)
            {
                PlayGameLoop();
            }
            else
            {
                getCompletedGameStatus(newGame.currentBoard, newGame.currentPlayer.Marker);
            }
        }

        private void getCompletedGameStatus(Board boardObject, string marker)
        {
            bool isDraw = newGame.rules.CheckIfDraw(boardObject, marker);

            gameUI.DisplayBoard(newGame.currentBoard.CreateDictBoard());
            gameUI.DisplayWinOrDraw(isDraw, marker);
            isGameOver = true;
        }

    }
}

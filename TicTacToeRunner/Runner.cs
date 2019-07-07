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
                var isEasyGame = false;
                var isHumanFirst = false;
                var isCompVCompGame = false;
                var isSinglePlayer = gameUI.isUserInputYes(gameUI.getTypeOfGame());
                if (isSinglePlayer)
                {
                    isEasyGame = !gameUI.isUserInputYes(gameUI.getDifficultyLevel());
                    
                    isHumanFirst = gameUI.isUserInputYes(gameUI.getPlayerOrder());
                }
                else
                {
                    isCompVCompGame = gameUI.isUserInputYes(gameUI.isCompVCompGame());
                }
                options = new Options(gameUI.setMarkers(), isSinglePlayer, isEasyGame, isHumanFirst, isCompVCompGame);


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

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
                    // playGameLoop();
                    singlePlayerGameLoop();
                }
            }
        }

        public void playGameLoop()
        {
            int selectedSpace = gameUI.getValidSpace(newGame.currentBoard.createDictBoard(), newGame.currentPlayerMarker);

            bool successfulTurn = newGame.turn(selectedSpace);

            if (successfulTurn)
            {
                playGameLoop();
            }
            else
            {
                getCompletedGameStatus(newGame.currentBoard, newGame.currentPlayerMarker);
                isGameOver = true;
            }
        }


        public void singlePlayerGameLoop()
        {
            int selectedHumanSpace = gameUI.getValidSpace(newGame.currentBoard.createDictBoard(), newGame.currentPlayerMarker);

            bool successfulHumanTurn = newGame.turn(selectedHumanSpace);

            if (successfulHumanTurn)
            {
                if (newGame.turn(newGame.compPlayer.getValidSpace(newGame.currentBoard.createDictBoard())))
                {
                    singlePlayerGameLoop();
                }
                else
                {
                    getCompletedGameStatus(newGame.currentBoard, newGame.currentPlayerMarker);
                    isGameOver = true;
                }
            }
            else
            {
                getCompletedGameStatus(newGame.currentBoard, newGame.currentPlayerMarker);
                isGameOver = true;
            }
        }



        
        // public void singlePlayerGameLoop()
        // {
        //     int selectedSpace = gameUI.getValidSpace(newGame.currentBoard.createDictBoard(), newGame.currentPlayerMarker);
        //     bool successfulTurn = newGame.turn(selectedSpace);

        //     if (successfulTurn)
        //     {
        //         int computerSpace = newGame.compPlayer.getRandomSpace();
        //         if (gameUI.isValidSpace(computerSpace.ToString(), newGame.currentBoard.createDictBoard()))
        //         {
        //             if (newGame.computerTurn(computerSpace))
        //             {
        //                 singlePlayerGameLoop();
        //             }
        //             else
        //             {
        //                 getCompletedGameStatus(newGame.currentBoard, newGame.currentPlayerMarker);
        //                 isGameOver = true;
        //             }
        //         }
        //     }
        //     else
        //     {
        //         getCompletedGameStatus(newGame.currentBoard, newGame.currentPlayerMarker);
        //         isGameOver = true;
        //     }
        // }



        public void getCompletedGameStatus(Board boardObject, string marker)
        {
            var isDraw = newGame.rules.checkIfDraw(boardObject, marker);
            gameUI.displayBoard(newGame.currentBoard.createDictBoard());
            gameUI.displayWinOrDraw(isDraw, marker);
        }

    }
}

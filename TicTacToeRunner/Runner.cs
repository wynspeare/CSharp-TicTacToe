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
                    playGameLoop();
                }
            }
        }


        public Dictionary<int, string> createPrimitiveBoard()
        {
            var primitiveBoard = new Dictionary<int, string>();
            foreach (Space space in newGame.currentBoard.board)
            {
                primitiveBoard.Add(space.location, space.marker);
            }
            return primitiveBoard;
        }


        public void playGameLoop()
        {
            int selectedSpace = gameUI.getValidSpace(createPrimitiveBoard(), newGame.currentPlayer.marker);
            bool successfulTurn = newGame.turn(selectedSpace);

            if (successfulTurn)
            {
                playGameLoop();
            }
            else
            {
                getCompletedGameStatus(newGame.currentBoard, newGame.currentPlayer.marker);
                isGameOver = true;
            }
        }


        public void getCompletedGameStatus(Board boardObject, string marker)
        {
            var isDraw = newGame.rules.checkIfDraw(boardObject, marker);

            gameUI.displayBoard(createPrimitiveBoard());
            gameUI.displayWinOrDraw(isDraw, marker);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;


namespace TicTacToeApp
{
    public class Minimax
    {
        public int bestMove;

        public int score(TicTacToe game)
        {
            bool isWon = game.rules.checkIfWon(game.currentBoard.board, game.currentPlayer.marker);
            
            if (isWon && game.currentPlayer == game.playerOne)
            {
                return 10;
            }
            else if (isWon && game.currentPlayer == game.playerTwo)
            {
                return -10;
            }
            else
            {
                return 0;
            }
        }


        public int minimax(TicTacToe game)
        {
            if (game.rules.isOver(game.currentBoard, game.currentPlayer.marker))
            {
                return score(game);
            }
            var scores = new List<int>();
            var moves = new List<int>();
            
            var availableMoves = game.currentBoard.getAvailableSpaces();

            foreach (int move in availableMoves)
            {
                Console.WriteLine(move);
                
                var possibleBoard = game.getNewState(move, game.currentPlayer.marker);
                Console.Write("\nCurrentBoard:  ");
                checkBoardArray(game.currentBoard);
                Console.Write("\nPossibleBoard: ");
                checkBoardArray(possibleBoard);

                // var possibleGame = game;
                // scores.Add(minimax(possibleGame));
                // moves.Add(move);

            }

            if (game.currentPlayer == game.playerOne)
            {
                int maxScoreIndex = scores.IndexOf(scores.Max());
                bestMove = moves[maxScoreIndex];
                return scores[maxScoreIndex];
            }
            else
            {
                int minScoreIndex = scores.IndexOf(scores.Min());
                bestMove = moves[minScoreIndex];
                return scores[minScoreIndex];
            }
        }

        public void checkBoardArray(Board board)
        {
            foreach (Space space in board.board)
            {
                Console.Write("{0}: {1} |  ", space.location, space.marker);
            }
        }

    }
}


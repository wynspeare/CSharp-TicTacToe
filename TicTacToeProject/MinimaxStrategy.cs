using System;
using System.Collections.Generic;
using System.Linq;


namespace TicTacToeApp
{
    public class MinimaxStrategy : IStrategy
    {
        public int bestMove;
        public TicTacToe game;

        public MinimaxStrategy(TicTacToe game)
        {
            this.game = game;
        }

        public string getMove()
        {
            var score = minimax(game);
            Console.WriteLine("SCORE: " + score);
            Console.WriteLine("BESTMOVE: " + bestMove);
            return bestMove.ToString();
        }

        public int score(TicTacToe game)
        {
            bool isWon = game.rules.checkIfWon(game.currentBoard.board, game.currentPlayer.Marker);
            
            if (isWon && game.currentPlayer == game.playerTwo)
            {
                return 10;
            }
            else if (isWon && game.currentPlayer == game.playerOne)
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
            if (game.rules.isOver(game.currentBoard, game.currentPlayer.Marker))
            {
                return score(game);
            }
            var scores = new List<int>();
            var moves = new List<int>();
            
            var availableMoves = game.currentBoard.getAvailableSpaces();

            foreach (int move in availableMoves)
            {
                    Console.WriteLine("\nTRY Location: " + move);

                var possibleGame = game.getNewState(game, move);

                    Console.Write("\nCurrentBoard:  ");
                    checkBoardArray(game.currentBoard);
                    Console.Write("\nPossibleBoard: ");
                    checkBoardArray(possibleGame.currentBoard);

                scores.Add(minimax(possibleGame));
                moves.Add(move);

                Console.WriteLine("\nCurrentPlayer: " + game.currentPlayer.Marker);
                Console.WriteLine(scores[scores.Count - 1]);
            }

            if (game.currentPlayer == game.playerTwo)
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


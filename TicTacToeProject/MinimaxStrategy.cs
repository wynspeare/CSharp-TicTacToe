using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeApp
{
    public class MinimaxStrategy : IStrategy
    {
        public int bestMove;
        public Board originalBoard;
        public Rules rules;
        public string maximizingPlayer;
        public string minimizingPlayer;

        public MinimaxStrategy(Board originalBoard)
        {
            this.rules = new Rules();            
            this.originalBoard = originalBoard;    
        }

        public void getMinimizingPlayer(string currentPlayer)
        {
            if (currentPlayer == Symbols.P1_MARKER)
            {
                maximizingPlayer = currentPlayer;
                minimizingPlayer = Symbols.P2_MARKER;
            }
            else
            {
                maximizingPlayer = Symbols.P2_MARKER;
                minimizingPlayer = Symbols.P1_MARKER;
            }
        }

        public string getMove(string maximizingPlayer)
        {
            getMinimizingPlayer(maximizingPlayer);          
            var depth = 0;
            var score = minimax(originalBoard, maximizingPlayer, minimizingPlayer, depth);
            Console.WriteLine("\nThe minimax computer selected space {0}.", bestMove);
            return bestMove.ToString();
        }

        public int score(Board board, string playerMarker, int depth)
        {
            bool isWon = rules.checkIfWon(board.board, playerMarker);
            if (isWon && playerMarker == maximizingPlayer)
            {

                return 10 - depth;
            }
            else if (isWon && playerMarker == minimizingPlayer)
            {     
                return depth -10;
            }
            else
            {
                return 0;
            }
        }

        public int minimax(Board board, string maximizingPlayer, string minimizingPlayer, int depth)
        {
            if (rules.isOver(board, minimizingPlayer))
            {
                return score(board, minimizingPlayer, depth);
            }
            depth += 1;
            var scores = new List<int>();
            var moves = new List<int>();
            
            var availableMoves = board.getAvailableSpaces();

            foreach (int move in availableMoves)
            {
                var possibleBoard = getBoardWithNextMove(board, maximizingPlayer, move);

                scores.Add(minimax(possibleBoard, minimizingPlayer, maximizingPlayer, depth));
                moves.Add(move);
            }

            if (maximizingPlayer == originalBoard.getCurrentPlayer())
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

        public Board getPossibleBoard(Board boardToClone)
        {
            var possibleBoard = new Board();
            for (int i = 1; i <= Symbols.BOARD_SIZE; i++)
            {
                if (boardToClone.board[i - 1].isSpaceFilled())
                {
                    possibleBoard.board[i - 1].marker = boardToClone.board[i - 1].marker;
                }                
            }
            return possibleBoard;
        }

        public Board getBoardWithNextMove(Board board, string currentPlayerMarker, int move)
        {
            var possibleBoard = getPossibleBoard(board);
            possibleBoard.placeMarker(move, currentPlayerMarker);
            return possibleBoard;
        }
    }
}
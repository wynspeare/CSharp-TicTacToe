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
        public string currentPlayerMarker;
        public string opponentPlayerMarker;

        public MinimaxStrategy(Board originalBoard)
        {
            this.rules = new Rules();            
            this.originalBoard = originalBoard;    
        }

        public void setPlayers()
        {
            var current = originalBoard.getCurrentPlayer();
            if (current == Symbols.P1_MARKER)
            {
                currentPlayerMarker = current;
                opponentPlayerMarker = Symbols.P2_MARKER;
            }
            else
            {
                currentPlayerMarker = Symbols.P2_MARKER;
                opponentPlayerMarker = Symbols.P1_MARKER;
            }
        }

        public string getMove()
        {
            setPlayers();            
            var depth = 0;
            var score = minimax(originalBoard, currentPlayerMarker, opponentPlayerMarker, depth);
            Console.WriteLine("\nThe minimax computer selected space {0}.", bestMove);
            return bestMove.ToString();
        }

        public int score(Board board, string playerMarker, int depth)
        {
            bool isWon = rules.checkIfWon(board.board, playerMarker);
            if (isWon && playerMarker == currentPlayerMarker)
            {

                return 10 - depth;
            }
            else if (isWon && playerMarker == opponentPlayerMarker)
            {     
                return depth -10;
            }
            else
            {
                return 0;
            }
        }

        public int minimax(Board board, string currentPlayerMarker, string opponentPlayerMarker, int depth)
        {
            if (rules.isOver(board, opponentPlayerMarker))
            {
                return score(board, opponentPlayerMarker, depth);
            }
            depth += 1;
            var scores = new List<int>();
            var moves = new List<int>();
            
            var availableMoves = board.getAvailableSpaces();

            foreach (int move in availableMoves)
            {
                var possibleBoard = getBoardWithNextMove(board, currentPlayerMarker, move);

                scores.Add(minimax(possibleBoard, opponentPlayerMarker, currentPlayerMarker, depth));
                moves.Add(move);
            }

            if (currentPlayerMarker == originalBoard.getCurrentPlayer())
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
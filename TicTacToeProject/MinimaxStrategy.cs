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

        public MinimaxStrategy()
        {
            this.rules = new Rules();            
        }

        public void GetMinimizingPlayer(string currentPlayer)
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

        public string GetMove(string maximizingPlayer, Board board)
        {
            originalBoard = board;    
            GetMinimizingPlayer(maximizingPlayer);          
            var depth = 0;
            var score = Minimax(originalBoard, maximizingPlayer, minimizingPlayer, depth);
            Console.WriteLine("\nThe minimax computer selected space {0}.", bestMove);
            return bestMove.ToString();
        }

        public int Score(Board board, string playerMarker, int depth)
        {
            bool isWon = rules.CheckIfWon(board.spaces, playerMarker);
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

        public int Minimax(Board board, string maximizingPlayer, string minimizingPlayer, int depth)
        {
            if (rules.IsOver(board, minimizingPlayer))
            {
                return Score(board, minimizingPlayer, depth);
            }
            depth += 1;
            var scores = new List<int>();
            var moves = new List<int>();
            
            var availableMoves = board.GetAvailableSpaces();

            foreach (int move in availableMoves)
            {
                var possibleBoard = GetBoardWithNextMove(board, maximizingPlayer, move);

                scores.Add(Minimax(possibleBoard, minimizingPlayer, maximizingPlayer, depth));
                moves.Add(move);
            }

            if (maximizingPlayer == originalBoard.GetCurrentPlayer())
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

        public void CheckBoardArray(Board board)
        {
            foreach (Space space in board.spaces)
            {
                Console.Write("{0}: {1} |  ", space.location, space.marker);
            }
        }

        public Board GetPossibleBoard(Board boardToClone)
        {
            var possibleBoard = new Board();
            for (int i = 1; i <= Symbols.BOARD_SIZE; i++)
            {
                if (boardToClone.spaces[i - 1].IsSpaceFilled())
                {
                    possibleBoard.spaces[i - 1].marker = boardToClone.spaces[i - 1].marker;
                }                
            }
            return possibleBoard;
        }

        public Board GetBoardWithNextMove(Board board, string currentPlayerMarker, int move)
        {
            var possibleBoard = GetPossibleBoard(board);
            possibleBoard.PlaceMarker(move, currentPlayerMarker);
            return possibleBoard;
        }
    }
}
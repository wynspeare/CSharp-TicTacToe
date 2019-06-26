using System;
using System.Collections.Generic;
using System.Linq;


namespace TicTacToeApp
{
    public class MinimaxStrategy : IStrategy
    {
        public int bestMove;
        public Board board;
        public IPlayer currentPlayer;
        public IPlayer opponentPlayer;
        public Rules rules;

        public MinimaxStrategy(Board board)
        {
            this.rules = new Rules();            
            this.board = board;
        }

        public void setPlayers(IPlayer playerTwo, IPlayer playerOne)
        {
            currentPlayer = playerTwo;
            opponentPlayer = playerOne;
        }

        public string getMove()
        {
            var depth = 0;
            var score = minimax(board, currentPlayer, opponentPlayer, depth);
            Console.WriteLine("SCORE: " + score);
            Console.WriteLine("BESTMOVE: " + bestMove);
            return bestMove.ToString();
        }

        public int score(Board board, IPlayer player, int depth)
        {
            bool isWon = rules.checkIfWon(board.board, player.Marker);
            if (isWon && player.Marker == Symbols.P2_MARKER) //Dependant on p2 being a computer
            {
                Console.WriteLine("Player " + player.Marker + " has won this match! Score: 10");
                return 10 - depth;
            }
            else if (isWon && player.Marker == Symbols.P1_MARKER)
            {
                Console.WriteLine("Player " + player.Marker + " has won this match! Score: -10");      
                return depth -10;
            }
            else
            {
                Console.WriteLine("This match is a draw. Score: 0");
                return 0;
            }
        }

        public int minimax(Board board, IPlayer currentPlayer, IPlayer opponentPlayer, int depth)
        {
            if (rules.isOver(board, opponentPlayer.Marker))
            {
                return score(board, opponentPlayer, depth);
            }
            depth += 1;
            var scores = new List<int>();
            var moves = new List<int>();
            
            var availableMoves = board.getAvailableSpaces();

            foreach (int move in availableMoves)
            {
                    Console.WriteLine("\nTRY Location: " + move + "  FOR Player: " + currentPlayer.Marker);

                var possibleGame = getNewState(board, currentPlayer, opponentPlayer, move);

                var possibleBoard = possibleGame.Item1; 
                var nextPlayer = possibleGame.Item2;

                    Console.Write("\nCurrentBoard:  ");
                    checkBoardArray(board);
                    Console.Write("\nPossibleBoard: ");
                    checkBoardArray(possibleBoard);

                scores.Add(minimax(possibleBoard, opponentPlayer, currentPlayer, depth));
                moves.Add(move);
            }

            if (currentPlayer.Marker == Symbols.P2_MARKER) //If current persons turn (board method) is current player..
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


        public Board getPossibleBoard(Board originalBoard)
        {
            var possibleBoard = new Board();
            for (int i = 1; i <= Symbols.BOARD_SIZE; i++)
            {
                if (originalBoard.board[i - 1].isSpaceFilled())
                {
                    possibleBoard.board[i - 1].marker = originalBoard.board[i - 1].marker;
                }                
            }
            return possibleBoard;
        }

        public Tuple<Board, IPlayer> getNewState(Board board, IPlayer currentPlayer, IPlayer opponentPlayer, int move)
        {
            var possibleBoard = getPossibleBoard(board);
            possibleBoard.placeMarker(move, currentPlayer.Marker);
            
            // Switch players
            return Tuple.Create(possibleBoard, opponentPlayer);
        }

    }
}
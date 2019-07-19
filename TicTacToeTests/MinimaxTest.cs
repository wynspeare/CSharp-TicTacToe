using Xunit;
using System;
using TicTacToeApp;

namespace TicTacToeTests
{
    public class MiniMaxTest
    {
        public const string P1_MARKER = "+";
        public const string P2_MARKER = "o";

        [Fact]
        public void ScoreCanTakeInANewBoardAndReturnAZeroScore()
        {
            var board = new Board();
            var subject = new MinimaxStrategy();

            Assert.Equal(0, subject.Score(board, P1_MARKER, 0));
        }

        [Fact]
        public void ScoreIsZeroForADrawnGame()
        {
            var board = new Board();
            var subject = new MinimaxStrategy();
            var p1_moves = new [] { 1, 2, 6, 7, 9 };
            var p2_moves = new [] { 3, 4, 5, 8 };
            board.PartiallyFillBoard(p1_moves, P1_MARKER);
            board.PartiallyFillBoard(p2_moves, P2_MARKER);

            Assert.True(subject.rules.IsOver(board, subject.maximizingPlayer));
            Assert.True(subject.rules.CheckIfDraw(board, subject.maximizingPlayer));

            Assert.Equal(0, subject.Score(board, P1_MARKER, 0));
        }

        [Fact]
        public void ScoreIsTenIfPlayerTwoHasWonTheGame()
        {
            var board = new Board();
            var subject = new MinimaxStrategy();
            
            var p1_moves = new [] { 2, 4, 7 };
            var p2_moves = new [] { 1, 5, 9 };
            board.PartiallyFillBoard(p1_moves, P1_MARKER);
            board.PartiallyFillBoard(p2_moves, P2_MARKER);

            subject.maximizingPlayer = P2_MARKER;
            subject.minimizingPlayer = P1_MARKER;

            Assert.True(subject.rules.IsOver(board, P2_MARKER));
            Assert.False(subject.rules.CheckIfWon(board.spaces, P1_MARKER));
            Assert.Equal(10, subject.Score(board, P2_MARKER, 0));
        }

        [Fact]
        public void ScoreIsMinusTenIfPlayerOneHasWonTheGame()
        {
            var board = new Board();
            var subject = new MinimaxStrategy();

            var p1_moves = new [] { 1, 5, 9 };
            var p2_moves = new [] { 2, 4 };
            board.PartiallyFillBoard(p1_moves, P1_MARKER);
            board.PartiallyFillBoard(p2_moves, P2_MARKER);

            subject.maximizingPlayer = P2_MARKER;
            subject.minimizingPlayer = P1_MARKER;

            Assert.True(subject.rules.IsOver(board, P1_MARKER));
            Assert.True(subject.rules.CheckIfWon(board.spaces, P1_MARKER));
            Assert.Equal(-10, subject.Score(board, P1_MARKER, 0));
        }
    }
}


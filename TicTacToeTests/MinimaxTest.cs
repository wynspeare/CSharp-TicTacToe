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
        public void scoreCanTakeInANewBoardAndReturnAZeroScore()
        {
            var board = new Board();
            var subject = new MinimaxStrategy();

            Assert.Equal(0, subject.score(board, P1_MARKER, 0));
        }

        [Fact]
        public void scoreIsZeroForADrawnGame()
        {
            var board = new Board();
            var subject = new MinimaxStrategy();
            var p1_moves = new [] { 1, 2, 6, 7, 9 };
            var p2_moves = new [] { 3, 4, 5, 8 };
            board.partiallyFillBoard(p1_moves, P1_MARKER);
            board.partiallyFillBoard(p2_moves, P2_MARKER);

            Assert.True(subject.rules.isOver(board, subject.maximizingPlayer));
            Assert.True(subject.rules.checkIfDraw(board, subject.maximizingPlayer));

            Assert.Equal(0, subject.score(board, P1_MARKER, 0));
        }

        [Fact]
        public void scoreIsTenIfPlayerTwoHasWonTheGame()
        {
            var board = new Board();
            var subject = new MinimaxStrategy();
            
            var p1_moves = new [] { 2, 4, 7 };
            var p2_moves = new [] { 1, 5, 9 };
            board.partiallyFillBoard(p1_moves, P1_MARKER);
            board.partiallyFillBoard(p2_moves, P2_MARKER);

            subject.maximizingPlayer = P2_MARKER;
            subject.minimizingPlayer = P1_MARKER;

            Assert.True(subject.rules.isOver(board, P2_MARKER));
            Assert.False(subject.rules.checkIfWon(board.spaces, P1_MARKER));
            Assert.Equal(10, subject.score(board, P2_MARKER, 0));
        }

        [Fact]
        public void scoreIsMinusTenIfPlayerOneHasWonTheGame()
        {
            var board = new Board();
            var subject = new MinimaxStrategy();

            var p1_moves = new [] { 1, 5, 9 };
            var p2_moves = new [] { 2, 4 };
            board.partiallyFillBoard(p1_moves, P1_MARKER);
            board.partiallyFillBoard(p2_moves, P2_MARKER);

            subject.maximizingPlayer = P2_MARKER;
            subject.minimizingPlayer = P1_MARKER;

            Assert.True(subject.rules.isOver(board, P1_MARKER));
            Assert.True(subject.rules.checkIfWon(board.spaces, P1_MARKER));
            Assert.Equal(-10, subject.score(board, P1_MARKER, 0));
        }
    }
}


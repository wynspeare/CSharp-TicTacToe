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
        public void scoreCanTakeInANewGameAndReturnAZeroScore()
        {
            var subject = new Minimax();
            var game = new TicTacToe();

            Assert.Equal(0, subject.score(game));
        }

        [Fact]
        public void scoreIsZeroForADrawnGame()
        {
            var subject = new Minimax();
            var game = new TicTacToe(P1_MARKER, P2_MARKER, true);

            var p1_moves = new [] { 1, 2, 6, 7, 9 };
            var p2_moves = new [] { 3, 4, 5, 8 };

            game.currentBoard.partiallyFillBoard(p1_moves, P1_MARKER);
            game.currentBoard.partiallyFillBoard(p2_moves, P2_MARKER);

            Assert.True(game.rules.isOver(game.currentBoard, game.currentPlayer.marker));
            Assert.True(game.rules.checkIfDraw(game.currentBoard, game.currentPlayer.marker));

            Assert.Equal(0, subject.score(game));
        }

        [Fact]
        public void scoreIsTenIfPlayerTwoComputerWinsAGame()
        {
            var subject = new Minimax();
            var game = new TicTacToe(P1_MARKER, P2_MARKER, true);
            var p1_moves = new [] { 2, 4, 7 };
            var p2_moves = new [] { 1, 5, 9 };

            game.currentBoard.partiallyFillBoard(p1_moves, P1_MARKER);
            game.currentBoard.partiallyFillBoard(p2_moves, P2_MARKER);
            game.switchPlayer();

            Assert.Equal(10, subject.score(game));
        }

        [Fact]
        public void scoreIsMinusTenIfPlayerOneHumanWinsGame()
        {
            var subject = new Minimax();
            var game = new TicTacToe(P1_MARKER, P2_MARKER, true);
            var p1_moves = new [] { 1, 5, 9 };
            var p2_moves = new [] { 2, 4 };

            game.currentBoard.partiallyFillBoard(p1_moves, P1_MARKER);
            game.currentBoard.partiallyFillBoard(p2_moves, P2_MARKER);

            Assert.True(game.rules.isOver(game.currentBoard, game.currentPlayer.marker));
            Assert.True(game.rules.checkIfWon(game.currentBoard.board, game.currentPlayer.marker));

            Assert.Equal(-10, subject.score(game));
        }

    }
}


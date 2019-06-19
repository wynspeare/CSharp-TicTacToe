using Xunit;
using System;
using TicTacToeApp;

namespace TicTacToeTests
{
    public class ComputerPlayerTest
    {
        public const string P1_MARKER = "+";

        [Fact]
        public void aComputerPlayerInstantiatesWithAMarker()
        {
            var board = new Board();
            var subject = new ComputerPlayer(P1_MARKER, board);

            Assert.Equal(P1_MARKER, subject.marker);
        }

        [Fact]
        public void aComputerPlayerCanGenerateARandomMoveFromAvailableSpaces()
        {
            var board = new Board();
            var subject = new ComputerPlayer(P1_MARKER, board);
            string selectedSpace = subject.getMove();

            Assert.InRange(Convert.ToInt32(selectedSpace), 1, 9);
        }
    }
}

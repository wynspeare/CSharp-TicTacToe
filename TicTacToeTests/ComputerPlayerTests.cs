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
            var strategy = new EasyStrategy(board);
            var subject = new ComputerPlayer(P1_MARKER, strategy);

            Assert.Equal(P1_MARKER, subject.Marker);
        }

        [Fact]
        public void aComputerPlayerCanGenerateARandomMoveFromAvailableSpaces()
        {
            var board = new Board();
            var strategy = new EasyStrategy(board);

            var subject = new ComputerPlayer(P1_MARKER, strategy);
            string selectedSpace = subject.getMove();

            Assert.InRange(Convert.ToInt32(selectedSpace), 1, 9);
        }
    }
}

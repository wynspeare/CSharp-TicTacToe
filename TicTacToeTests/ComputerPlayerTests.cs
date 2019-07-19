using Xunit;
using System;
using TicTacToeApp;

namespace TicTacToeTests
{
    public class ComputerPlayerTest
    {
        public const string P1_MARKER = "+";

        [Fact]
        public void ComputerPlayerInstantiatesWithAMarker()
        {
            var strategy = new EasyStrategy();
            var subject = new ComputerPlayer(P1_MARKER, strategy);

            Assert.Equal(P1_MARKER, subject.Marker);
        }

        [Fact]
        public void ComputerPlayerCanGenerateARandomMoveFromAvailableSpaces()
        {
            var board = new Board();
            var strategy = new EasyStrategy();
            var subject = new ComputerPlayer(P1_MARKER, strategy);
            string selectedSpace = subject.GetMove(board);

            Assert.InRange(Convert.ToInt32(selectedSpace), 1, 9);
        }
    }
}

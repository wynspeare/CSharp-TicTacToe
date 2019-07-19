using Xunit;
using System;
using TicTacToeApp;

namespace TicTacToeTests
{
    public class HumanPlayerTest
    {
        public const string P1_MARKER = "+";

        [Fact]
        public void HumanPlayerInstantiatesWithAMarker()
        {
            var subject = new HumanPlayer(P1_MARKER);

            Assert.Equal(P1_MARKER, subject.Marker);
        }

        [Fact]
        public void HumanPlayerCanKnowIfSelectedSpaceIsValid()
        {
            var subject = new HumanPlayer(P1_MARKER);
            var board = new Board();      

            Assert.True(subject.isValidSpace("9", board));   
            Assert.False(subject.isValidSpace("-1", board));
            Assert.False(subject.isValidSpace("11", board));
            Assert.False(subject.isValidSpace("Q", board));   
        }
    }
}


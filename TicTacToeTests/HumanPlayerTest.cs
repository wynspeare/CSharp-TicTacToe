using Xunit;
using System;
using TicTacToeApp;

namespace TicTacToeTests
{
    public class HumanPlayerTest
    {
        public const string P1_MARKER = "+";

        [Fact]
        public void aHumanPlayerInstantiatesWithAMarker()
        {
            var board = new Board();
            var subject = new HumanPlayer(P1_MARKER, board);

            Assert.Equal(P1_MARKER, subject.Marker);
        }

        [Fact]
        public void aHumanPlayerCanKnowIfSelectedSpaceIsValid()
        {
            var board = new Board();            
            var subject = new HumanPlayer(P1_MARKER, board);
            Assert.True(subject.isValidSpace("9"));   
            Assert.False(subject.isValidSpace("-1"));
            Assert.False(subject.isValidSpace("11"));
            Assert.False(subject.isValidSpace("Q"));   
        }
    }
}


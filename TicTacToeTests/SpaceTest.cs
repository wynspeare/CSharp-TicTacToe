using Xunit;
using System;
using System.Collections.Generic;
using TicTacToeApp;
using TicTacToeUserInterface;

namespace TicTacToeTests
{
    public class SpaceTest
    {
        [Fact]
        public void aNewSpaceIsEmpty()
        {
            var subject = new Space(1);
            Assert.True(subject.isSpaceEmpty());
        }

        [Fact]
        public void aSpacesMarkerCanBeChanged()
        {
            var subject = new Space(1);
            subject.marker = "X";
            Assert.Equal("X", subject.marker);
        }

        [Fact]
        public void aMarkedSpaceIsNotEmpty()
        {
            var subject = new Space(1);
            subject.marker = "X";
            Assert.False(subject.isSpaceEmpty());
        }
    }
}
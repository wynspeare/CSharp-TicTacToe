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
        public void NewSpaceIsEmpty()
        {
            var subject = new Space(1);
            Assert.True(subject.IsSpaceEmpty());
        }

        [Fact]
        public void SpacesMarkerCanBeChanged()
        {
            var subject = new Space(1);
            subject.marker = "X";
            Assert.Equal("X", subject.marker);
        }

        [Fact]
        public void MarkedSpaceIsNotEmpty()
        {
            var subject = new Space(1);
            subject.marker = "X";
            Assert.False(subject.IsSpaceEmpty());
        }

        [Fact]
        public void MarkedSpaceIsFilled()
        {
            var subject = new Space(1);
            subject.marker = "X";
            Assert.True(subject.IsSpaceFilled());
        }
    }
}
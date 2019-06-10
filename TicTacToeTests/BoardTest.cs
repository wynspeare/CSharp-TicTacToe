using Xunit;
using System;
using System.Collections.Generic;
using TicTacToeApp;
using TicTacToeUserInterface;

namespace TicTacToeTests
{
    public class BoardTest
    {

        public const string P1_MARKER = "+";
        public const string P2_MARKER = "*";

        [Fact]
        public void aNewBoardIsEmpty()
        {
            var subject = new Board();
            Assert.True(subject.isEmpty());
        }


        [Fact]
        public void aBoardCanMarkaSpace()
        {
            var subject = new Board();
            Assert.True(subject.placeMarker(5, P2_MARKER));
        }


        [Fact]
        public void aNewBoardContainsInstancesOfSpaces()
        {
            var subject = new Board();
            Assert.Equal(9, subject.board[8].location);
        }


        [Fact]
        public void whenAMarkerIsPlacedTheBoardIsChanged()
        {
            var subject = new Board();
            subject.placeMarker(5, P1_MARKER);
            Assert.Equal(P1_MARKER, subject.board[4].marker);
        }


        [Fact]
        public void aSpecificLocationIsFilledAfterAMarkerIsPlaced()
        {
            var subject = new Board();
            subject.placeMarker(5, P1_MARKER);
            Assert.False(subject.board[4].isSpaceEmpty());
        }


        [Fact]
        public void aBoardIsNotEmptyAfterAMarkerIsPlaced()
        {
            var subject = new Board();
            subject.placeMarker(5, P1_MARKER);
            Assert.False(subject.isEmpty());
        }


        [Fact]
        public void aBoardCanBeCompletelyFull()
        {
            var subject = new Board();
            subject.placeMarker(1, P1_MARKER);
            subject.placeMarker(2, P1_MARKER);
            subject.placeMarker(6, P1_MARKER);
            subject.placeMarker(7, P1_MARKER);
            subject.placeMarker(9, P1_MARKER);
            subject.placeMarker(3, P2_MARKER);
            subject.placeMarker(4, P2_MARKER);
            subject.placeMarker(5, P2_MARKER);
            subject.placeMarker(8, P2_MARKER);

            Assert.False(subject.isEmpty());
            Assert.True(subject.isFilled());

        }

    }
}
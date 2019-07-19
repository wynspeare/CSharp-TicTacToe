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
        public void ANewBoardIsEmpty()
        {
            var subject = new Board();
            Assert.True(subject.IsBoardEmpty());
        }

        [Fact]
        public void ABoardCanMarkaSpace()
        {
            var subject = new Board();
            subject.PlaceMarker(5, P2_MARKER);
            Assert.Equal(P2_MARKER, subject.MarkerAtLocation(5));
        }

        [Fact]
        public void ASpecificLocationIsFilledAfterAMarkerIsPlaced()
        {
            var subject = new Board();
            subject.PlaceMarker(5, P1_MARKER);
            Assert.False(subject.IsSpaceOnBoardEmpty(5));
        }

        [Fact]
        public void ABoardIsNotEmptyAfterAMarkerIsPlaced()
        {
            var subject = new Board();
            subject.PlaceMarker(5, P1_MARKER);
            Assert.False(subject.IsBoardEmpty());
        }

        [Fact]
        public void AWhenNineMarkersArePlacedABoardIsFull()
        {
            var subject = new Board();
            subject.PlaceMarker(1, P1_MARKER);
            subject.PlaceMarker(2, P1_MARKER);
            subject.PlaceMarker(6, P1_MARKER);
            subject.PlaceMarker(7, P1_MARKER);
            subject.PlaceMarker(9, P1_MARKER);
            subject.PlaceMarker(3, P2_MARKER);
            subject.PlaceMarker(4, P2_MARKER);
            subject.PlaceMarker(5, P2_MARKER);
            subject.PlaceMarker(8, P2_MARKER);

            Assert.False(subject.IsBoardEmpty());
            Assert.True(subject.IsBoardFilled());
        }

        [Fact]
        public void ABoardKnowsWhatSpacesAreStillAvailable()
        {
            var subject = new Board();
            subject.PlaceMarker(1, P1_MARKER);
            subject.PlaceMarker(2, P1_MARKER);
            subject.PlaceMarker(3, P1_MARKER);
            
            Assert.Equal(new List<int> { 4, 5, 6, 7, 8, 9 }, subject.GetAvailableSpaces());
        }

        [Fact]
        public void ABoardCanBePartiallyFilledByPassingInAnArrayOfMoves()
        {
            var subject = new Board();
            var p1_moves = new [] { 1, 2, 6, 7, 9 };
            subject.PartiallyFillBoard(p1_moves, P1_MARKER);

            Assert.Equal(new List<int> { 3, 4, 5, 8 }, subject.GetAvailableSpaces());
        }

        [Fact]
        public void ABoardCanBeFilledByPassingInTwoArraysOfMoves()
        {
            var subject = new Board();
            var p1_moves = new [] { 1, 2, 6, 7, 9 };
            var p2_moves = new [] { 3, 4, 5, 8 };

            subject.PartiallyFillBoard(p1_moves, P1_MARKER);
            subject.PartiallyFillBoard(p2_moves, P2_MARKER);

            Assert.True(subject.IsBoardFilled());
        }

    }
}
using Xunit;
using System;
using System.Collections.Generic;
using TicTacToeApp;
using TicTacToeUserInterface;

namespace TicTacToeTests
{
    public class TTTTest
    {

        public const string EMPTY = "_";
        public const string P1_MARKER = "+";
        public const string P2_MARKER = "*";

        [Fact]
        public void gameInitializesWithDefaultPlayerMarkersXandO()
        {
            var subject = new TicTacToe();
            Assert.NotNull(subject.playerOne.marker);
            Assert.NotNull(subject.playerTwo.marker);
        }

        [Fact]
        public void gameInitializesProvidedPlayerMarkers()
        {
            var subject = new TicTacToe(P1_MARKER, P2_MARKER);

            Assert.Equal(P1_MARKER, subject.playerOne.marker);
            Assert.Equal(P2_MARKER, subject.playerTwo.marker);
        }


        [Fact]
        public void gameInitializesWithNewInstanceOfBoard()
        {
            var subject = new TicTacToe();
            Assert.NotNull(subject.currentBoard);
        }

        [Fact]
        public void aNewBoardIsEmpty()
        {
            var subject = new Board();
            Assert.True(subject.isEmpty());
        }

        [Fact]
        public void aNewSpaceIsEmpty()
        {
            var subject = new Space(1);
            Assert.True(subject.isSpaceEmpty());
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
        public void aNewGameCanMarkaSpace()
        {
            var subject = new TicTacToe(P1_MARKER);
            Assert.True(subject.moveMarker(3, P1_MARKER));
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

        [Fact] //Implement a way to add in a mock board with pre-filled spaces??
        public void aRowOfThreeMarkersWinsTheGame()
        {
            var subject = new TicTacToe(P1_MARKER, P2_MARKER);           
            subject.moveMarker(1, subject.playerOne.marker);
            subject.moveMarker(2, subject.playerOne.marker);
            subject.moveMarker(3, subject.playerOne.marker);
            subject.moveMarker(4, subject.playerTwo.marker);

            // var userInterface = new UserInterface();
            // userInterface.displayBoard(subject.currentBoard);
            
            var row = new List<string> {"x", "x", "x"};

            Assert.True(subject.isRowComplete(row, "x"));
        }

    }
}

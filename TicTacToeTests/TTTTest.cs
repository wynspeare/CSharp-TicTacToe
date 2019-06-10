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
            
            Assert.Equal("X", subject.playerOne.marker);
            Assert.Equal("O", subject.playerTwo.marker);
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
        public void aNewGameCanMarkaSpace()
        {
            var subject = new TicTacToe(P1_MARKER);
            Assert.True(subject.moveMarker(3, P1_MARKER));
        }


        [Fact]
        public void aRowOfThreeSameMarkersReturnsTrue()
        {
            var subject = new TicTacToe(P1_MARKER, P2_MARKER);           
            var row = new List<string> {P1_MARKER, P1_MARKER, P1_MARKER};

            Assert.True(subject.rules.isRowComplete(row, P1_MARKER));
        }


        [Fact]
        public void aBoardWithThreeHorizontalMarkersInARowWinsGame()
        {
            var subject = new TicTacToe(P1_MARKER, P2_MARKER);           
            subject.moveMarker(4, subject.playerOne.marker);
            subject.moveMarker(5, subject.playerOne.marker);
            subject.moveMarker(6, subject.playerOne.marker);

            // var userInterface = new UserInterface();
            // userInterface.displayBoard(subject.currentBoard);
            
            Assert.True(subject.rules.checkIfWon(subject.currentBoard.board, subject.currentPlayer.marker));
        }


        [Fact]
        public void aBoardWithThreeDiagonalMarkersInARowWinsGame()
        {
            var subject = new TicTacToe(P1_MARKER, P2_MARKER);           
            subject.moveMarker(1, subject.playerOne.marker);
            subject.moveMarker(5, subject.playerOne.marker);
            subject.moveMarker(9, subject.playerOne.marker);

            Assert.True(subject.rules.checkIfWon(subject.currentBoard.board, subject.currentPlayer.marker));
        }


        [Fact]
        public void aBoardWithThreeVerticalMarkersInARowWinsGame()
        {
            var subject = new TicTacToe(P1_MARKER, P2_MARKER);           
            subject.moveMarker(3, subject.playerOne.marker);
            subject.moveMarker(6, subject.playerOne.marker);
            subject.moveMarker(9, subject.playerOne.marker);

            Assert.False(subject.rules.checkIfDraw(subject.currentBoard, subject.currentPlayer.marker));
            Assert.True(subject.rules.checkIfWon(subject.currentBoard.board, subject.currentPlayer.marker));
        }

        [Fact]
        public void aFullBoardWithNoWinnerIsADraw()
        {
            var subject = new TicTacToe(P1_MARKER, P2_MARKER);           
            subject.moveMarker(1, subject.playerOne.marker);
            subject.moveMarker(2, subject.playerOne.marker);
            subject.moveMarker(6, subject.playerOne.marker);
            subject.moveMarker(7, subject.playerOne.marker);
            subject.moveMarker(9, subject.playerOne.marker);
            subject.moveMarker(3, subject.playerTwo.marker);
            subject.moveMarker(4, subject.playerTwo.marker);
            subject.moveMarker(5, subject.playerTwo.marker);
            subject.moveMarker(8, subject.playerTwo.marker);

            // var userInterface = new UserInterface();
            // userInterface.displayBoard(subject.currentBoard);

            Assert.True(subject.rules.checkIfDraw(subject.currentBoard, subject.currentPlayer.marker));
        }

        [Fact]
        public void aTurnMethodWorks()
        {
            var subject = new TicTacToe(P1_MARKER, P2_MARKER);           
            subject.turn(1);
            subject.turn(3);
            subject.turn(2);
            subject.turn(4);
            subject.turn(6);
            subject.turn(5);
            subject.turn(7);
            subject.turn(8);
            subject.turn(9);

            Assert.False(subject.rules.checkIfWon(subject.currentBoard.board, subject.currentPlayer.marker));
            Assert.True(subject.rules.checkIfDraw(subject.currentBoard, subject.currentPlayer.marker));
            
        }

    }
}

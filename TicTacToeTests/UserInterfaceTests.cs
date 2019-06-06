using Xunit;
using System;
using System.Collections.Generic;
using TicTacToeApp;
using TicTacToeUserInterface;

namespace TicTacToeTests
{
    public class UITest
    {

        public const string EMPTY = "_";
        public const string P1_MARKER = "+";
        public const string P2_MARKER = "*";

        [Fact]
        public void userIntefaceCanStartNewGameWithUserGivenSymbols()
        {
            var subject = new UserInterface();
            subject.startNewGame();

            subject.newGame.moveMarker(3, subject.options.P1_MARKER);
            subject.newGame.moveMarker(6, subject.options.P2_MARKER);

            subject.displayBoard(subject.newGame.currentBoard);

            Assert.Equal(1, subject.newGame.currentBoard.board[0].location);
        }


        [Fact]
        public void userCanKnowIfSelectedSpaceIsValid()
        {
            var subject = new UserInterface();
            subject.startNewGame();
            Assert.True(subject.isValidSpace("9"));   
            Assert.False(subject.isValidSpace("-1"));
            Assert.False(subject.isValidSpace("11"));
            Assert.False(subject.isValidSpace("Q"));   
        }


        [Fact]
        public void aBoardDisplaysCorrectly()
        {
            var subject = new TicTacToe(P1_MARKER);
            subject.moveMarker(3, P1_MARKER);
            subject.moveMarker(8, P1_MARKER);
            var userInterface = new UserInterface();
            userInterface.displayBoard(subject.currentBoard);
        }

        [Fact]
        public void userCanViewTheBoard()
        {
            var myBoard = new Board();
            var subject = new UserInterface();
            Assert.Contains( "  ———————————  \n | " , subject.displayBoard(myBoard));
        }

        [Fact]
        public void userCanEnterASpaceAndItsReturnsAnInteger()
        {
            var subject = new UserInterface();
            subject.startNewGame();
            Assert.Equal(typeof(int), subject.getSpace().GetType());
        }

        [Fact]
        public void userIntefaceCanStartNewGame()
        {
            var subject = new UserInterface();
            Assert.Equal("A new game has been started", subject.startNewGame());
            Assert.Equal(1, subject.newGame.currentBoard.board[0].location);
        }

        [Fact]
        public void userCanReadInstructions()
        {
            var subject = new UserInterface();
            Assert.Contains("Players alternate placing", subject.displayInstructions());
        }

    }
}
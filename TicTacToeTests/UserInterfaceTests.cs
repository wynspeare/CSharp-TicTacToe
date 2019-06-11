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

        [Trait("Category", "UITest")]
        [Fact]
        public void userIntefaceCanStartNewGameWithUserGivenSymbols()
        {
            var subject = new UserInterface();
            subject.startNewGame();

            subject.newGame.moveMarker(3, subject.newGame.playerOne.marker);
            subject.newGame.moveMarker(6, subject.newGame.playerTwo.marker);

            subject.displayBoard(subject.newGame.currentBoard);

            Assert.Equal(1, subject.newGame.currentBoard.board[0].location);
        }

        [Trait("Category", "UITest")]
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

        [Trait("Category", "UITest")]
        [Fact]
        public void userCanEnterASpaceAndItsReturnsAnInteger()
        {
            var subject = new UserInterface();
            subject.startNewGame();
            Assert.Equal(typeof(int), subject.getValidSpace().GetType());
        }

        [Trait("Category", "UITest")]
        [Fact]
        public void userCanReadInstructions()
        {
            var subject = new UserInterface();
            Assert.Contains("Players alternate placing", subject.displayInstructions());
        }

    }
}

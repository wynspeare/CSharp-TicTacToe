using Xunit;
using System;
using TicTacToeApp;
using TicTacToeUserInterface;

namespace TicTacToeTests
{
    public class TTTTest
    {

        public const string EMPTY = "_";
        public const string X_MARKER = "+";
        public const string O_MARKER = "*";

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
            var subject = new TicTacToe(X_MARKER, O_MARKER);

            Assert.Equal(X_MARKER, subject.playerOne.marker);
            Assert.Equal(O_MARKER, subject.playerTwo.marker);
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
            Assert.True(subject.placeMarker(5, O_MARKER));
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
            var subject = new TicTacToe(X_MARKER);
            Assert.True(subject.moveMarker(3, X_MARKER));
        }

        [Fact]
        public void whenAMarkerIsPlacedTheBoardIsChanged()
        {
            var subject = new Board();
            subject.placeMarker(5, X_MARKER);
            Assert.Equal(X_MARKER, subject.board[4].marker);
        }

        [Fact]
        public void aSpecificLocationIsFilledAfterAMarkerIsPlaced()
        {
            var subject = new Board();
            subject.placeMarker(5, X_MARKER);
            Assert.False(subject.board[4].isSpaceEmpty());
        }

        [Fact]
        public void aBoardIsNotEmptyAfterAMarkerIsPlaced()
        {
            var subject = new Board();
            subject.placeMarker(5, X_MARKER);
            Assert.False(subject.isEmpty());
        }

        [Fact] //Implement a way to add in a mock board with pre-filled spaces??
        public void aRowOfThreeMarkersWinsTheGame()
        {
            var subject = new TicTacToe(X_MARKER, O_MARKER);           
            subject.moveMarker(1, subject.playerOne.marker);
            subject.moveMarker(2, subject.playerOne.marker);
            subject.moveMarker(3, subject.playerOne.marker);
            subject.moveMarker(4, subject.playerTwo.marker);

            var userInterface = new UserInterface();
            userInterface.displayBoard(subject.currentBoard);
            
            Assert.True(subject.isRowComplete());
        }





// User Interface Tests Below

        // [Fact]
        // public void userIntefaceCanStartNewGameWithUserGivenSymbols()
        // {
        //     var subject = new UserInterface();
        //     subject.startNewGame();

        //     subject.newGame.moveMarker(3, subject.adapter.X_MARKER);
        //     subject.newGame.moveMarker(6, subject.adapter.O_MARKER);

        //     subject.displayBoard(subject.newGame.currentBoard);


        //     Assert.Equal(1, subject.newGame.currentBoard.board[0].location);
        // }


        // [Fact]
        // public void userCanKnowIfSelectedSpaceIsValid()
        // {
        //     var subject = new UserInterface();
        //     subject.startNewGame();
        //     Assert.True(subject.isValidSpace("9"));   
        //     Assert.False(subject.isValidSpace("-1"));
        //     Assert.False(subject.isValidSpace("11"));
        //     Assert.False(subject.isValidSpace("Q"));   
        // }


        // [Fact]
        // public void aBoardDisplaysCorrectly()
        // {
        //     var subject = new TicTacToe("X");
        //     subject.moveMarker(3, "X");
        //     subject.moveMarker(8, "X");
        //     var userInterface = new UserInterface();
        //     userInterface.displayBoard(subject.currentBoard);
        //     // Assert.True(subject.currentBoard.successfulMove);
        // }

        // [Fact]
        // public void userCanViewTheBoard()
        // {
        //     var myBoard = new Board();
        //     var subject = new UserInterface();
        //     Assert.Contains( "  ———————————  \n | " , subject.displayBoard(myBoard));
        // }

        // [Fact]
        // public void userCanEnterASpaceAndItsReturnsAnInteger()
        // {
        //     var subject = new UserInterface();
        //     subject.startNewGame();
        //     Assert.Equal(typeof(int), subject.getSpace().GetType());
        // }

        // [Fact]
        // public void userIntefaceCanStartNewGame() //userinterface test - move to different tests project?
        // {
        //     var subject = new UserInterface();
        //     Assert.Equal("A new game has been started", subject.startNewGame());
        //     Assert.Equal(1, subject.newGame.currentBoard.board[0].location);
        // }

        // [Fact]
        // public void userCanReadInstructions()
        // {
        //     var subject = new UserInterface();
        //     Assert.Contains("Players alternate placing", subject.displayInstructions());
        // }

    }
}

using Xunit;
using System;
using TicTacToeApp;
using TicTacToeUserInterface;

namespace TicTacToeTests
{
    public class TTTTest
    {
        [Fact]
        public void gameInitializesWithNewInstancesOfPlayer()
        {
            var subject = new TicTacToe("X");
            Assert.NotNull(subject.playerOne.marker);
            Assert.NotNull(subject.playerTwo.marker);
        }

        [Fact]
        public void gameInitializesWithNewInstanceOfBoard()
        {
            var subject = new TicTacToe("X");
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
            Assert.True(subject.placeMarker(5, "O"));
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
            var subject = new TicTacToe("X");
            Assert.True(subject.moveMarker(3, "X"));
        }

        [Fact]
        public void whenAMarkerIsPlacedTheBoardIsChanged()
        {
            var subject = new Board();
            subject.placeMarker(5, "X");
            Assert.Equal("X", subject.board[4].marker);
        }

        [Fact]
        public void aSpecificLocationisFilledafterAMarkerIsPlaced()
        {
            var subject = new Board();
            subject.placeMarker(5, "X");
            Assert.False(subject.board[4].isSpaceEmpty());
        }

        [Fact]
        public void aBoardIsNotEmptyafterAMarkerIsPlaced()
        {
            var subject = new Board();
            subject.placeMarker(5, "X");
            Assert.False(subject.isEmpty());
        }



        [Fact] //Implement a way to add in a mock board with pre-filled spaces??
        public void aRowOfThreeMarkersWinsTheGame()
        {
            var subject = new TicTacToe("X");           
            subject.moveMarker(1, "X");
            subject.moveMarker(2, "X");
            subject.moveMarker(3, "X");

            // var userInterface = new UserInterface();
            // userInterface.displayBoard(subject.currentBoard);
            
            Assert.True(subject.isRowComplete());
        }






// User Interface Tests Below

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

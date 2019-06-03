using Xunit;
using System;
using TicTacToeApp;
using TicTacToeUserInterface;

namespace TicTacToeTests
{
    public class TTTTest
    {
        [Fact]
        public void userIntefaceConnectionTest()
        {
            var subject = new UserInterface();
            Assert.Equal("Hello World!", subject.hello());
        }

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
        public void aBoardCanMarkaSpace()
        {
            var subject = new Board();
            var newSpace = new Space(3);
            subject.placeMarker(newSpace);
            Assert.True(subject.successfulMove);
        }

        [Fact]
        public void aNewGameCanMarkaSpace()
        {
            var subject = new TicTacToe("X");
            subject.moveMarker(3);
            Assert.True(subject.currentBoard.successfulMove);
        }




        // [Fact]
        // public void userCanEnterASpaceAndANewCurrentInstanceIsCreated()
        // {
        //     TicTacToe myTTT = new TicTacToe();
        //     myTTT.startNewGame();
        //     Assert.Null(myTTT.currentSpace);
        //     myTTT.getSpace();
        //     Assert.NotNull(myTTT.currentSpace);
        // }

        // [Fact]
        // public void whenANewSpaceIsEnteredTheCurrentLocationIsChanged()
        // {
        //     TicTacToe myTTT = new TicTacToe();
        //     myTTT.startNewGame();
        //     Assert.Null(myTTT.currentSpace);
        //     myTTT.getSpace(); // Enter 3
        //     Assert.Equal(3, myTTT.currentSpace.location);
        //     myTTT.getSpace(); // Enter 5
        //     Assert.Equal(5, myTTT.currentSpace.location);
        // }

        // [Fact]
        // public void userCanKnowIfSelectedSpaceIsValid()
        // {
        //     TicTacToe myTTT = new TicTacToe();
        //     myTTT.startNewGame();
        //     Assert.True(myTTT.isValidSpace("9"));   
        //     Assert.False(myTTT.isValidSpace("-1"));
        //     Assert.False(myTTT.isValidSpace("11"));
        //     Assert.False(myTTT.isValidSpace("Q"));   
        // }
        
        // [Fact]
        // public void userCanKnowIfSpaceIsEmpty()
        // {
        //     TicTacToe myTTT = new TicTacToe();
        //     myTTT.startNewGame();
        //     Assert.True(myTTT.currentBoard.isSpaceEmpty(3));
        // }

        // [Fact]
        // public void userCanPlaceMarkerOnASpace()
        // {
        //     TicTacToe myTTT = new TicTacToe();
        //     myTTT.startNewGame();
        //     Space mySpace = new Space(3, "O");
        //     Assert.True(myTTT.currentBoard.placeMarker(mySpace));
        //     myTTT.displayBoard();
        // }

        // [Fact]
        // public void userCanKnowIfAMoveWasSuccessful()
        // {
        //     TicTacToe myTTT = new TicTacToe();
        //     myTTT.startNewGame();
        //     Space mySpace = new Space(3);
        //     myTTT.currentBoard.placeMarker(mySpace);
        //     Assert.True(myTTT.currentBoard.successfulMove);
        // }

        // [Fact]
        // public void aSpecificLocationisFilledafterAMove()
        // {
        //     TicTacToe myTTT = new TicTacToe();
        //     myTTT.startNewGame();
        //     Space mySpace = new Space(6);
        //     myTTT.currentBoard.placeMarker(mySpace);
        //     myTTT.displayBoard();
        //     Assert.False(myTTT.currentBoard.isSpaceEmpty(6));
        // }

        // [Fact]
        // public void aBoardIsNotEmptyafterAMoves()
        // {
        //     TicTacToe myTTT = new TicTacToe();
        //     myTTT.startNewGame();
        //     Space mySpace = new Space(6);
        //     myTTT.currentBoard.placeMarker(mySpace);
        //     mySpace = new Space(8, "O");
        //     myTTT.currentBoard.placeMarker(mySpace);
        //     myTTT.displayBoard();
        //     Assert.False(myTTT.currentBoard.isEmpty());
        // }

        // [Fact] //Implement a way to add in a mock board with pre-filled spaces??
        // public void userIsShownIfTheirLatestMoveWinsTheGame()
        // {
        //     TicTacToe myTTT = new TicTacToe();
        //     myTTT.startNewGame();
        //     Space mySpace = new Space(6);
        //     myTTT.currentBoard.placeMarker(mySpace);
        //     mySpace.location = 9;
        //     myTTT.currentBoard.placeMarker(mySpace);
        //     mySpace.location = 3;
        //     myTTT.currentBoard.placeMarker(mySpace);
        //     myTTT.displayBoard();
        //     Assert.True(myTTT.currentBoard.isRowComplete());
        // }





        // [Fact]
        // public void userCanEnterASpaceAndItsReturnsAnInteger()
        // {
        //     var subject = new UserInterface();
        //     subject.startNewGame();
        //     Assert.Equal(typeof(int), subject.getSpace().GetType());
        // }


        // [Fact]
        // public void userCanViewTheBoard()
        // {
        //     var subject = new UserInterface();
        //     subject.startNewGame();
        //     Assert.Contains( "  ———————————  \n | " , subject.displayBoard());
        // }

        // [Fact]
        // public void userIntefaceCanStartNewGame() //userinterface test - move to different testins project?
        // {
        //     var subject = new UserInterface();
        //     Assert.Equal("A new game has been started", subject.startNewGame());
        //     Assert.Equal("1", subject.newGame.currentBoard.board[0]);
        // }

        // [Fact]
        // public void userCanReadInstructions()
        // {
        //     var subject = new UserInterface();
        //     Assert.Contains("Players alternate placing", subject.displayInstructions());
        // }

    }
}

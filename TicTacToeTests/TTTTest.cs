using Xunit;
using System;
using TicTacToeApp;

namespace TicTacToeTests
{
    public class TTTTest
    {
        [Fact]
        public void userCanStartNewGame()
        {
            TicTacToe myTTT = new TicTacToe();
            Assert.Equal("A new game has been started", myTTT.startNewGame());
        }
        
        [Fact]
        public void newInstancesOfPlayerAreCreatedWhenAMarkerIsChosen()
        {
            TicTacToe myTTT = new TicTacToe();
            Assert.Null(myTTT.playerOne);
            myTTT.chooseMarker();
            Assert.NotNull(myTTT.playerOne.marker);
            Assert.NotNull(myTTT.playerTwo.marker);
        }

        [Fact]
        public void userCanReadInstructions()
        {
            TicTacToe myTTT = new TicTacToe();
            Assert.Contains("Players alternate placing", myTTT.displayInstructions());
        }

        [Fact]
        public void aNewGameHasAnEmptyBoard()
        {
            TicTacToe myTTT = new TicTacToe();
            myTTT.startNewGame();
            Assert.True(myTTT.currentBoard.isEmpty());
        }

        [Fact]
        public void userCanViewTheBoard()
        {
            TicTacToe myTTT = new TicTacToe();
            myTTT.startNewGame();
            Assert.Contains( "  ———————————  \n | " , myTTT.displayBoard());
        }

        [Fact]
        public void userCanEnterASpaceAndItsReturnsAnInteger()
        {
            TicTacToe myTTT = new TicTacToe();
            myTTT.startNewGame();
            Assert.Equal(typeof(int), myTTT.getSpace().GetType());
        }


        [Fact]
        public void userCanEnterASpaceAndANewCurrentInstanceIsCreated()
        {
            TicTacToe myTTT = new TicTacToe();
            myTTT.startNewGame();
            Assert.Null(myTTT.currentSpace);
            myTTT.getSpace();
            Assert.NotNull(myTTT.currentSpace);
        }

        [Fact]
        public void whenANewSpaceIsEnteredTheCurrentLocationIsChanged()
        {
            TicTacToe myTTT = new TicTacToe();
            myTTT.startNewGame();
            Assert.Null(myTTT.currentSpace);
            myTTT.getSpace(); // Enter 3
            Assert.Equal(3, myTTT.currentSpace.location);
            myTTT.getSpace(); // Enter 5
            Assert.Equal(5, myTTT.currentSpace.location);
        }

        [Fact]
        public void userCanKnowIfSelectedSpaceIsValid()
        {
            TicTacToe myTTT = new TicTacToe();
            myTTT.startNewGame();
            Assert.True(myTTT.isValidSpace("9"));   
            Assert.False(myTTT.isValidSpace("-1"));
            Assert.False(myTTT.isValidSpace("11"));
            Assert.False(myTTT.isValidSpace("Q"));   
        }
        
        [Fact]
        public void userCanKnowIfSpaceIsEmpty()
        {
            TicTacToe myTTT = new TicTacToe();
            myTTT.startNewGame();
            Assert.True(myTTT.currentBoard.isSpaceEmpty(3));
        }

        [Fact]
        public void userCanPlaceMarkerOnASpace() //toggle successfulMove?
        {
            TicTacToe myTTT = new TicTacToe();
            myTTT.startNewGame();
            Space mySpace = new Space(3, "O");
            Assert.True(myTTT.currentBoard.placeMarker(mySpace));
            myTTT.displayBoard();
        }

        [Fact]
        public void userCanKnowIfAMoveWasSuccessful()
        {
            TicTacToe myTTT = new TicTacToe();
            myTTT.startNewGame();
            Space mySpace = new Space(3);
            myTTT.currentBoard.placeMarker(mySpace);
            Assert.True(myTTT.currentBoard.successfulMove);
        }

        [Fact] //Test behaviour not state
        public void aSpecificLocationisFilledafterAMove()
        {
            TicTacToe myTTT = new TicTacToe();
            myTTT.startNewGame();
            Space mySpace = new Space(6);
            myTTT.currentBoard.placeMarker(mySpace);
            myTTT.displayBoard();
            Assert.False(myTTT.currentBoard.isSpaceEmpty(6));
        }

        [Fact] //Test behaviour not state
        public void aBoardIsNotEmptyafterAMoves()
        {
            TicTacToe myTTT = new TicTacToe();
            myTTT.startNewGame();
            Space mySpace = new Space(6);
            myTTT.currentBoard.placeMarker(mySpace);
            // mySpace.location = 8;
            // mySpace.marker = "O";
            mySpace = new Space(8, "O");
            myTTT.currentBoard.placeMarker(mySpace);
            myTTT.displayBoard();
            Assert.False(myTTT.currentBoard.isEmpty());
        }

        [Fact] //Implement a way to add in a mock board with pre-filled spaces??
        public void userIsShownIfTheirLatestMoveWinsTheGame()
        {
            TicTacToe myTTT = new TicTacToe();
            myTTT.startNewGame();
            Space mySpace = new Space(6);
            myTTT.currentBoard.placeMarker(mySpace);
            mySpace.location = 9;
            myTTT.currentBoard.placeMarker(mySpace);
            mySpace.location = 3;
            myTTT.currentBoard.placeMarker(mySpace);
            myTTT.displayBoard();
            Assert.True(myTTT.currentBoard.isRowComplete());
        }

    }
}

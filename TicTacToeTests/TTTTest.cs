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
        public void playerOneCanChooseAMarker()
        {
            TicTacToe myTTT = new TicTacToe();
            myTTT.chooseMarker();
            Assert.NotNull(myTTT.playerOneMarker);
            Assert.NotNull(myTTT.playerTwoMarker);
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
        public void userCanEnterASpaceAndReturnAnInteger()
        {
            TicTacToe myTTT = new TicTacToe();
            Assert.Equal(typeof(int), myTTT.getSpace().GetType());
        }

        [Fact]
        public void userCanKnowIfSelectedSpaceIsValid()
        {
            TicTacToe myTTT = new TicTacToe();
            Assert.True(myTTT.isValidSpace(9));   
            Assert.False(myTTT.isValidSpace(-1));
            Assert.False(myTTT.isValidSpace(11));   
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
            Assert.True(myTTT.currentBoard.placeMarker(3, "X"));
            myTTT.displayBoard();
            // myTTT.currentBoard.checkBoardArray();
        }

        [Fact]
        public void userKnowIfAMoveWasValid()
        {
            TicTacToe myTTT = new TicTacToe();
            myTTT.startNewGame();
            myTTT.currentBoard.placeMarker(3, "X");
            Assert.True(myTTT.currentBoard.successfulMove);
        }

    }
}

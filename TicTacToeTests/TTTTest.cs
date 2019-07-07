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
        public const string P2_MARKER = "o";

        [Fact]
        public void anHvHGameInitializesProvidedPlayerMarkers()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};
            var subject = new TicTacToe(players);

            Assert.Equal(P1_MARKER, subject.playerOne.Marker);
            Assert.Equal(P2_MARKER, subject.playerTwo.Marker);
        }
        
        [Fact]
        public void currentMarkerInANewGameIsPlayerOne()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};

            var subject = new TicTacToe(players);

            Assert.Equal(P1_MARKER, subject.currentPlayer.Marker);
        }

        [Fact]
        public void gameInitializesWithAnEmptyBoard()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};
            var subject = new TicTacToe(players);

            Assert.True(subject.currentBoard.isBoardEmpty());
        }

        [Fact]
        public void aNewGameCanMarkaSpace()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};
            var subject = new TicTacToe(players);
            subject.moveMarker(3, P1_MARKER);

            Assert.Equal(P1_MARKER, subject.currentBoard.markerAtLocation(3));
        }

        [Fact]
        public void anHvHGamePlayersCanBeSwitched()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};
            var subject = new TicTacToe(players);
            Assert.Equal("+", subject.currentPlayer.Marker);

            subject.switchPlayer();
            Assert.Equal(P2_MARKER, subject.currentPlayer.Marker);
        }

        [Fact]
        public void aTurnCanBePlayedAndThePlayerIsSwitched()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};
            var subject = new TicTacToe(players);    

            Assert.Equal(P1_MARKER, subject.currentPlayer.Marker);
            subject.turn(1);
            Assert.Equal(P2_MARKER, subject.currentPlayer.Marker);
        }

        [Fact]
        public void RowOfThreeSameMarkersReturnsTrue()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};
            var subject = new TicTacToe(players); 
            var row = new List<string> {P1_MARKER, P1_MARKER, P1_MARKER};

            Assert.True(subject.rules.isRowComplete(row, P1_MARKER));
        }

        [Fact]
        public void aBoardWithThreeHorizontalMarkersInARowWinsGame()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};
            var subject = new TicTacToe(players);           
            subject.moveMarker(4, subject.playerOne.Marker);
            subject.moveMarker(5, subject.playerOne.Marker);
            subject.moveMarker(6, subject.playerOne.Marker);
            
            Assert.True(subject.rules.checkIfWon(subject.currentBoard.spaces, subject.currentPlayer.Marker));
        }

        [Fact]
        public void aBoardWithThreeDiagonalMarkersInARowWinsGame()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};
            var subject = new TicTacToe(players);            
            subject.moveMarker(1, subject.playerOne.Marker);
            subject.moveMarker(5, subject.playerOne.Marker);
            subject.moveMarker(9, subject.playerOne.Marker);

            Assert.True(subject.rules.checkIfWon(subject.currentBoard.spaces, subject.currentPlayer.Marker));
        }

        [Fact]
        public void aBoardWithThreeVerticalMarkersInARowWinsGame()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};
            var subject = new TicTacToe(players);            
            subject.moveMarker(3, subject.playerOne.Marker);
            subject.moveMarker(6, subject.playerOne.Marker);
            subject.moveMarker(9, subject.playerOne.Marker);

            Assert.False(subject.rules.checkIfDraw(subject.currentBoard, subject.currentPlayer.Marker));
            Assert.True(subject.rules.checkIfWon(subject.currentBoard.spaces, subject.currentPlayer.Marker));
        }

        [Fact]
        public void aFullBoardWithNoWinnerIsADraw()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};
            var subject = new TicTacToe(players);            
            subject.moveMarker(1, subject.playerOne.Marker);
            subject.moveMarker(2, subject.playerOne.Marker);
            subject.moveMarker(6, subject.playerOne.Marker);
            subject.moveMarker(7, subject.playerOne.Marker);
            subject.moveMarker(9, subject.playerOne.Marker);
            subject.moveMarker(3, subject.playerTwo.Marker);
            subject.moveMarker(4, subject.playerTwo.Marker);
            subject.moveMarker(5, subject.playerTwo.Marker);
            subject.moveMarker(8, subject.playerTwo.Marker);

            Assert.True(subject.rules.checkIfDraw(subject.currentBoard, subject.currentPlayer.Marker));
        }

        [Fact]
        public void anHvHGameCanBeADrawWithPlayersSwitchingTurns()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};
            var subject = new TicTacToe(players);            
            subject.turn(1);
            subject.turn(3);
            subject.turn(2);
            subject.turn(4);
            subject.turn(6);
            subject.turn(5);
            subject.turn(7);
            subject.turn(8);
            subject.turn(9);

            Assert.False(subject.rules.checkIfWon(subject.currentBoard.spaces, subject.currentPlayer.Marker));
            Assert.True(subject.rules.checkIfDraw(subject.currentBoard, subject.currentPlayer.Marker));
        }

        [Fact]
        public void anHvHGameCanBeWonWithPlayersSwitchingTurns()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};
            var subject = new TicTacToe(players);            
            subject.turn(1);
            subject.turn(6);
            subject.turn(9);
            subject.turn(4);
            subject.turn(3);
            subject.turn(5);

            Assert.True(subject.rules.checkIfWon(subject.currentBoard.spaces, subject.currentPlayer.Marker));
            Assert.False(subject.rules.checkIfDraw(subject.currentBoard, subject.currentPlayer.Marker));
        }

        [Fact]
        public void singlePlayerGameInitializesProvidedPlayerMarkers()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new ComputerPlayer(P2_MARKER, new EasyStrategy())};
            var subject = new TicTacToe(players); 

            Assert.Equal(P1_MARKER, subject.playerOne.Marker);
            Assert.Equal(P2_MARKER, subject.playerTwo.Marker);
        }
        

        [Fact]
        public void singlePlayerGameAPlayerCanBeSwitched()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new ComputerPlayer(P2_MARKER, new EasyStrategy())};
            var subject = new TicTacToe(players);           
            Assert.Equal(P1_MARKER, subject.currentPlayer.Marker);
            
            subject.switchPlayer();
            Assert.Equal(P2_MARKER, subject.currentPlayer.Marker);
        }

        [Fact]
        public void aSinglePlayerGameCanBeADrawWithMockedLocations()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new ComputerPlayer(P2_MARKER, new EasyStrategy())};
            var subject = new TicTacToe(players);            
            subject.turn(1);
            subject.turn(3);
            subject.turn(2);
            subject.turn(4);
            subject.turn(6);
            subject.turn(5);
            subject.turn(7);
            subject.turn(8);
            subject.turn(9);

            Assert.False(subject.rules.checkIfWon(subject.currentBoard.spaces, subject.currentPlayer.Marker));
            Assert.True(subject.rules.checkIfDraw(subject.currentBoard, subject.currentPlayer.Marker));
        }

        [Fact]
        public void aSinglePlayerGameCanBeWonWithMockedLocations()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new ComputerPlayer(P2_MARKER, new EasyStrategy())};
            var subject = new TicTacToe(players);            
            subject.turn(1);
            subject.turn(6);
            subject.turn(9);
            subject.turn(4);
            subject.turn(3);
            subject.turn(5);

            Assert.True(subject.rules.checkIfWon(subject.currentBoard.spaces, subject.currentPlayer.Marker));
            Assert.False(subject.rules.checkIfDraw(subject.currentBoard, subject.currentPlayer.Marker));
        }

    }
}

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
        public void HvHGameInitializesProvidedPlayerMarkers()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};
            var subject = new TicTacToe(players);

            Assert.Equal(P1_MARKER, subject.playerOne.Marker);
            Assert.Equal(P2_MARKER, subject.playerTwo.Marker);
        }
        
        [Fact]
        public void CurrentMarkerInANewGameIsPlayerOne()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};

            var subject = new TicTacToe(players);

            Assert.Equal(P1_MARKER, subject.currentPlayer.Marker);
        }

        [Fact]
        public void GameInitializesWithAnEmptyBoard()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};
            var subject = new TicTacToe(players);

            Assert.True(subject.currentBoard.IsBoardEmpty());
        }

        [Fact]
        public void NewGameCanMarkaSpace()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};
            var subject = new TicTacToe(players);
            subject.MoveMarker(3, P1_MARKER);

            Assert.Equal(P1_MARKER, subject.currentBoard.MarkerAtLocation(3));
        }

        [Fact]
        public void HvHGamePlayersCanBeSwitched()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};
            var subject = new TicTacToe(players);
            Assert.Equal("+", subject.currentPlayer.Marker);

            subject.SwitchPlayer();
            Assert.Equal(P2_MARKER, subject.currentPlayer.Marker);
        }

        [Fact]
        public void TurnCanBePlayedAndThePlayerIsSwitched()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};
            var subject = new TicTacToe(players);    

            Assert.Equal(P1_MARKER, subject.currentPlayer.Marker);
            subject.Turn(1);
            Assert.Equal(P2_MARKER, subject.currentPlayer.Marker);
        }

        [Fact]
        public void RowOfThreeSameMarkersReturnsTrue()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};
            var subject = new TicTacToe(players); 
            var row = new List<string> {P1_MARKER, P1_MARKER, P1_MARKER};

            Assert.True(subject.rules.IsRowComplete(row, P1_MARKER));
        }

        [Fact]
        public void BoardWithThreeHorizontalMarkersInARowWinsGame()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};
            var subject = new TicTacToe(players);           
            subject.MoveMarker(4, subject.playerOne.Marker);
            subject.MoveMarker(5, subject.playerOne.Marker);
            subject.MoveMarker(6, subject.playerOne.Marker);
            
            Assert.True(subject.rules.CheckIfWon(subject.currentBoard.spaces, subject.currentPlayer.Marker));
        }

        [Fact]
        public void BoardWithThreeDiagonalMarkersInARowWinsGame()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};
            var subject = new TicTacToe(players);            
            subject.MoveMarker(1, subject.playerOne.Marker);
            subject.MoveMarker(5, subject.playerOne.Marker);
            subject.MoveMarker(9, subject.playerOne.Marker);

            Assert.True(subject.rules.CheckIfWon(subject.currentBoard.spaces, subject.currentPlayer.Marker));
        }

        [Fact]
        public void BoardWithThreeVerticalMarkersInARowWinsGame()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};
            var subject = new TicTacToe(players);            
            subject.MoveMarker(3, subject.playerOne.Marker);
            subject.MoveMarker(6, subject.playerOne.Marker);
            subject.MoveMarker(9, subject.playerOne.Marker);

            Assert.False(subject.rules.CheckIfDraw(subject.currentBoard, subject.currentPlayer.Marker));
            Assert.True(subject.rules.CheckIfWon(subject.currentBoard.spaces, subject.currentPlayer.Marker));
        }

        [Fact]
        public void FullBoardWithNoWinnerIsADraw()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};
            var subject = new TicTacToe(players);            
            subject.MoveMarker(1, subject.playerOne.Marker);
            subject.MoveMarker(2, subject.playerOne.Marker);
            subject.MoveMarker(6, subject.playerOne.Marker);
            subject.MoveMarker(7, subject.playerOne.Marker);
            subject.MoveMarker(9, subject.playerOne.Marker);
            subject.MoveMarker(3, subject.playerTwo.Marker);
            subject.MoveMarker(4, subject.playerTwo.Marker);
            subject.MoveMarker(5, subject.playerTwo.Marker);
            subject.MoveMarker(8, subject.playerTwo.Marker);

            Assert.True(subject.rules.CheckIfDraw(subject.currentBoard, subject.currentPlayer.Marker));
        }

        [Fact]
        public void HvHGameCanBeADrawWithPlayersSwitchingTurns()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};
            var subject = new TicTacToe(players);            
            subject.Turn(1);
            subject.Turn(3);
            subject.Turn(2);
            subject.Turn(4);
            subject.Turn(6);
            subject.Turn(5);
            subject.Turn(7);
            subject.Turn(8);
            subject.Turn(9);

            Assert.False(subject.rules.CheckIfWon(subject.currentBoard.spaces, subject.currentPlayer.Marker));
            Assert.True(subject.rules.CheckIfDraw(subject.currentBoard, subject.currentPlayer.Marker));
        }

        [Fact]
        public void HvHGameCanBeWonWithPlayersSwitchingTurns()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new HumanPlayer(P2_MARKER)};
            var subject = new TicTacToe(players);            
            subject.Turn(1);
            subject.Turn(6);
            subject.Turn(9);
            subject.Turn(4);
            subject.Turn(3);
            subject.Turn(5);

            Assert.True(subject.rules.CheckIfWon(subject.currentBoard.spaces, subject.currentPlayer.Marker));
            Assert.False(subject.rules.CheckIfDraw(subject.currentBoard, subject.currentPlayer.Marker));
        }

        [Fact]
        public void SinglePlayerGameInitializesProvidedPlayerMarkers()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new ComputerPlayer(P2_MARKER, new EasyStrategy())};
            var subject = new TicTacToe(players); 

            Assert.Equal(P1_MARKER, subject.playerOne.Marker);
            Assert.Equal(P2_MARKER, subject.playerTwo.Marker);
        }
        

        [Fact]
        public void SinglePlayerGameAPlayerCanBeSwitched()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new ComputerPlayer(P2_MARKER, new EasyStrategy())};
            var subject = new TicTacToe(players);           
            Assert.Equal(P1_MARKER, subject.currentPlayer.Marker);
            
            subject.SwitchPlayer();
            Assert.Equal(P2_MARKER, subject.currentPlayer.Marker);
        }

        [Fact]
        public void SinglePlayerGameCanBeADrawWithMockedLocations()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new ComputerPlayer(P2_MARKER, new EasyStrategy())};
            var subject = new TicTacToe(players);            
            subject.Turn(1);
            subject.Turn(3);
            subject.Turn(2);
            subject.Turn(4);
            subject.Turn(6);
            subject.Turn(5);
            subject.Turn(7);
            subject.Turn(8);
            subject.Turn(9);

            Assert.False(subject.rules.CheckIfWon(subject.currentBoard.spaces, subject.currentPlayer.Marker));
            Assert.True(subject.rules.CheckIfDraw(subject.currentBoard, subject.currentPlayer.Marker));
        }

        [Fact]
        public void SinglePlayerGameCanBeWonWithMockedLocations()
        {
            var players = new List<IPlayer>() { new HumanPlayer(P1_MARKER), new ComputerPlayer(P2_MARKER, new EasyStrategy())};
            var subject = new TicTacToe(players);            
            subject.Turn(1);
            subject.Turn(6);
            subject.Turn(9);
            subject.Turn(4);
            subject.Turn(3);
            subject.Turn(5);

            Assert.True(subject.rules.CheckIfWon(subject.currentBoard.spaces, subject.currentPlayer.Marker));
            Assert.False(subject.rules.CheckIfDraw(subject.currentBoard, subject.currentPlayer.Marker));
        }

    }
}

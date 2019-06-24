﻿using Xunit;
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
        public const bool IS_SINGLE_PLAYER = true;

        [Fact]
        public void twoPlayerGameInitializesWithDefaultPlayerMarkersXandO()
        {
            var subject = new TicTacToe();
            
            Assert.Equal("X", subject.playerOne.marker);
            Assert.Equal("O", subject.playerTwo.marker);
        }

        [Fact]
        public void twoPlayerGameInitializesProvidedPlayerMarkers()
        {
            var subject = new TicTacToe(P1_MARKER, P2_MARKER);

            Assert.Equal(P1_MARKER, subject.playerOne.marker);
            Assert.Equal(P2_MARKER, subject.playerTwo.marker);
        }
        
        [Fact]
        public void currentMarkerInTwoPlayerGameIsPlayerOne()
        {
            var subject = new TicTacToe(P1_MARKER, P2_MARKER);

            Assert.Equal(P1_MARKER, subject.currentPlayer.marker);
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
            subject.moveMarker(3, P1_MARKER);

            Assert.Equal(P1_MARKER, subject.currentBoard.markerAtLocation(3));
        }

        [Fact]
        public void twoPlayerGameAPlayerCanBeSwitched()
        {
            var subject = new TicTacToe(P1_MARKER, P2_MARKER);
            Assert.Equal("+", subject.currentPlayer.marker);

            subject.switchPlayer();
            Assert.Equal(P2_MARKER, subject.currentPlayer.marker);
        }

        [Fact]
        public void twoPlayerGameATurnCanBePlayedAndThePlayerIsSwitched()
        {
            var subject = new TicTacToe(P1_MARKER, P2_MARKER);           
            Assert.Equal("+", subject.currentPlayer.marker);
            subject.turn(1);
            Assert.Equal(P2_MARKER, subject.currentPlayer.marker);
        }

        [Fact]
        public void RowOfThreeSameMarkersReturnsTrue()
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

            Assert.True(subject.rules.checkIfDraw(subject.currentBoard, subject.currentPlayer.marker));
        }

        [Fact]
        public void aTwoPlayerGameCanBeADrawWithPlayersSwitchingTurns()
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

        [Fact]
        public void aTwoPlayerGameCanBeWonWithPlayersSwitchingTurns()
        {
            var subject = new TicTacToe(P1_MARKER, P2_MARKER);           
            subject.turn(1);
            subject.turn(6);
            subject.turn(9);
            subject.turn(4);
            subject.turn(3);
            subject.turn(5);

            Assert.True(subject.rules.checkIfWon(subject.currentBoard.board, subject.currentPlayer.marker));
            Assert.False(subject.rules.checkIfDraw(subject.currentBoard, subject.currentPlayer.marker));
        }

        [Fact]
        public void singlePlayerGameInitializesProvidedPlayerMarkers()
        {
            var subject = new TicTacToe(P1_MARKER, P2_MARKER, IS_SINGLE_PLAYER);

            Assert.Equal(P1_MARKER, subject.playerOne.marker);
            Assert.Equal(P2_MARKER, subject.playerTwo.marker);
        }
        
        [Fact]
        public void currentMarkerInSinglePlayerGameIsPlayerOne()
        {
            var subject = new TicTacToe(P1_MARKER, P2_MARKER, IS_SINGLE_PLAYER);

            Assert.Equal(P1_MARKER, subject.currentPlayer.marker);
        }

        [Fact]
        public void singlePlayerGameAPlayerCanBeSwitched()
        {
            var subject = new TicTacToe(P1_MARKER, P2_MARKER, IS_SINGLE_PLAYER);           
            Assert.Equal("+", subject.currentPlayer.marker);
            
            subject.switchPlayer();
            Assert.Equal(P2_MARKER, subject.currentPlayer.marker);
        }

        [Fact]
        public void aSinglePlayerGameCanBeADrawWithMockedLocations()
        {
            var subject = new TicTacToe(P1_MARKER, P2_MARKER, IS_SINGLE_PLAYER);           
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

        [Fact]
        public void aSinglePlayerGameCanBeWonWithMockedLocations()
        {
            var subject = new TicTacToe(P1_MARKER, P2_MARKER, IS_SINGLE_PLAYER);           
            subject.turn(1);
            subject.turn(6);
            subject.turn(9);
            subject.turn(4);
            subject.turn(3);
            subject.turn(5);

            Assert.True(subject.rules.checkIfWon(subject.currentBoard.board, subject.currentPlayer.marker));
            Assert.False(subject.rules.checkIfDraw(subject.currentBoard, subject.currentPlayer.marker));
        }

        [Fact]
        public void aNewGameCanBeConstructedFromAnOriginal()
        {
            var originalGame = new TicTacToe(P1_MARKER, P2_MARKER, IS_SINGLE_PLAYER);
            var p1_moves = new [] { 3, 4, 7 };
            var p2_moves = new [] { 1, 8, 9 };
            originalGame.currentBoard.partiallyFillBoard(p1_moves, P1_MARKER);
            originalGame.currentBoard.partiallyFillBoard(p2_moves, P2_MARKER);
            var newGame = new TicTacToe(originalGame);

            Assert.Equal(newGame.currentBoard.getAvailableSpaces(), originalGame.currentBoard.getAvailableSpaces());
        }

        [Fact]
        public void aNewGameCanBeAlteredAndTheOriginalBoardIsUnchanged()
        {
            var originalGame = new TicTacToe(P1_MARKER, P2_MARKER, IS_SINGLE_PLAYER);
            var p1_moves = new [] { 3, 4, 7 };
            var p2_moves = new [] { 1, 8, 9 };

            originalGame.currentBoard.partiallyFillBoard(p1_moves, P1_MARKER);
            originalGame.currentBoard.partiallyFillBoard(p2_moves, P2_MARKER);

            var newGame = new TicTacToe(originalGame);
            newGame.currentBoard.placeMarker(2, newGame.currentPlayer.marker);

            Assert.NotEqual(originalGame.currentBoard.markerAtLocation(2), newGame.currentBoard.markerAtLocation(2));
            Assert.Equal(P1_MARKER, newGame.currentBoard.markerAtLocation(2));
            Assert.True(originalGame.currentBoard.isSpaceOnBoardEmpty(2));
        }

        [Fact]
        public void aNewGameStateCanBeCreatedWithANewMovePlayed()
        {
            var originalGame = new TicTacToe(P1_MARKER, P2_MARKER, IS_SINGLE_PLAYER);
            var p1_moves = new [] { 3, 4, 7 };
            var p2_moves = new [] { 1, 8, 9 };

            originalGame.currentBoard.partiallyFillBoard(p1_moves, P1_MARKER);
            originalGame.currentBoard.partiallyFillBoard(p2_moves, P2_MARKER);
            var newGame = originalGame.getNewState(originalGame, 2);

            Assert.NotEqual(originalGame.currentBoard.markerAtLocation(2), newGame.currentBoard.markerAtLocation(2));
            Assert.Equal(P1_MARKER, newGame.currentBoard.markerAtLocation(2));
            Assert.True(originalGame.currentBoard.isSpaceOnBoardEmpty(2));
        }
    }
}

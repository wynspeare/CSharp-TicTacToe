using Xunit;
using System;
using System.Collections.Generic;
using TicTacToeApp;
using TicTacToeUserInterface;

namespace TicTacToeTests
{
    public class ComputerPlayerTest
    {
        public const string P1_MARKER = "+";
        public const string P2_MARKER = "*";

        [Fact]
        public void aComputerPlayerInstantiatesWithAMarker()
        {
            var subject = new ComputerPlayer("X");
            Assert.Equal("X", subject.marker);
        }

        [Fact]
        public void aComputerPlayerCanGenerateARandomNumberBetweenOneAndNine()
        {
            var subject = new ComputerPlayer();
            Assert.InRange(subject.getRandomSpace(), 1, 9);
        }

        [Fact]
        public void aComputerPlayerKnowsIfSelectedSpaceIsAlreadyFilled()
        {
            var subject = new ComputerPlayer();
            var myBoard = new Board();
            myBoard.placeMarker(1, P1_MARKER);
            Assert.True(subject.isFilledSpace(1, myBoard.board));
        }

        [Fact]
        public void aComputerPlayerCanFindAValidMove()
        {
            var subject = new ComputerPlayer();
            var myBoard = new Board();
            myBoard.placeMarker(1, P1_MARKER);
            myBoard.placeMarker(2, P1_MARKER);
            myBoard.placeMarker(6, P1_MARKER);
            myBoard.placeMarker(7, P1_MARKER);
            myBoard.placeMarker(9, P1_MARKER);
            myBoard.placeMarker(3, P2_MARKER);
            myBoard.placeMarker(4, P2_MARKER);
            myBoard.placeMarker(5, P2_MARKER);
            
            Assert.Equal(8, subject.getValidSpace(myBoard.board));
        }

    }
}

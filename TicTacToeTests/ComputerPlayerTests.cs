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
        
        Dictionary<int, string> MY_BOARD = new Dictionary<int, string>()
                                            {
                                                {1,"_"},
                                                {2,"_"},
                                                {3,"_"},
                                                {4,"_"},
                                                {5,"_"},
                                                {6,"_"},
                                                {7,"_"},
                                                {8,"_"},
                                                {9,"_"}
                                            };

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
        public void aComputerPlayerKnowIfSelectedSpaceIsValid()
        {
            var subject = new ComputerPlayer();
            Assert.True(subject.isValidSpace(1, MY_BOARD));
        }

        [Fact]
        public void aComputerPlayerCanFindAValidMove()
        {
            var subject = new ComputerPlayer();
            Dictionary<int, string> myBoard = new Dictionary<int, string>()
                                            {
                                                {1,"X"},
                                                {2,"X"},
                                                {3,"X"},
                                                {4,"X"},
                                                {5,"X"},
                                                {6,"X"},
                                                {7,"X"},
                                                {8,"_"},
                                                {9,"X"}
                                            };
            Assert.Equal(8, subject.getValidSpace(myBoard));
        }

    }
}

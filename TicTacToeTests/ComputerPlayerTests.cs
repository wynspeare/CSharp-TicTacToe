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
        List<int> AVAILABLE_SPACES = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };                                            
        [Fact]
        public void aComputerPlayerInstantiatesWithAMarker()
        {
            var subject = new ComputerPlayer("X");
            Assert.Equal("X", subject.marker);
        }

        [Fact]
        public void aComputerPlayerCanGenerateARandomNumberBetweenOneAndNine()
        {
            var subject = new ComputerPlayer("X");
            string selectedSpace = subject.getMove(AVAILABLE_SPACES);
            Assert.InRange(Convert.ToInt32(selectedSpace), 1, 9);
        }

    }
}

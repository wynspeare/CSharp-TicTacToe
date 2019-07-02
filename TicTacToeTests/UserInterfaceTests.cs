using Xunit;
using System;
using System.Collections.Generic;
using TicTacToeApp;
using TicTacToeUserInterface;

namespace TicTacToeTests
{
    public class UITest
    {
        public const string P1_MARKER = "+";
        public const string P2_MARKER = "o";
        List<int> AVAILABLE_SPACES = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };                                          

        [Trait("Category", "UITest")]
        [Fact]
        public void markersCanBeSetWithGivenSymbols()
        {
            var subject = new UserInterface();
            var markers = new Tuple<string, string> ( P1_MARKER, P2_MARKER );
            var options = new Options(markers);
            Assert.Equal("+", options.P1_MARKER);
            Assert.Equal("o", options.P2_MARKER);
        }

        [Trait("Category", "UITest")]
        [Fact]
        public void markersCannotBeTheSame()
        {
            var subject = new UserInterface();
            Assert.True(subject.isMarkerDifferent(P1_MARKER, P2_MARKER));
            Assert.False(subject.isMarkerDifferent(P1_MARKER, P1_MARKER));
        }

        [Trait("Category", "UITest")]
        [Fact]
        public void singlePlayerGameCanBeSelected()
        {
            var subject = new UserInterface();
            var typeOfGame = "Y";
            Assert.True(subject.isSinglePlayerGame(typeOfGame));
        }
    }
}

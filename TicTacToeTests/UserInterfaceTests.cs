using Xunit;
using System;
using System.Collections.Generic;
using TicTacToeApp;
using TicTacToeUserInterface;

namespace TicTacToeTests
{
    public class UITest
    {

        public const string EMPTY = "_";
        public const string P1_MARKER = "+";
        public const string P2_MARKER = "o";
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

        [Trait("Category", "UITest")]
        [Fact]
        public void markersCanBeSetWithUserProvidedSymbols()
        {
            var subject = new UserInterface();
            var options = new Options(subject.setMarkers());

            Assert.Equal(typeof(string), options.P1_MARKER.GetType());
        }

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
        public void userCanKnowIfSelectedSpaceIsValid()
        {
            var subject = new UserInterface();

            Assert.True(subject.isValidSpace("9", MY_BOARD));   
            Assert.False(subject.isValidSpace("-1", MY_BOARD));
            Assert.False(subject.isValidSpace("11", MY_BOARD));
            Assert.False(subject.isValidSpace("Q", MY_BOARD));   
        }

        [Trait("Category", "UITest")]
        [Fact]
        public void userCanEnterASpaceAndItsReturnsAnInteger()
        {
            var subject = new UserInterface();
            Assert.Equal(typeof(int), subject.getValidSpace(MY_BOARD, P1_MARKER).GetType());
        }

        [Trait("Category", "UITest")]
        [Fact]
        public void userCanReadInstructions()
        {
            var subject = new UserInterface();
            Assert.Contains("Players alternate placing", subject.displayInstructions());
        }

        [Trait("Category", "UITest")]
        [Fact]
        public void singlePlayerGameCanBeSelected()
        {
            var subject = new UserInterface();
            var typeOfGame = "Y";
            Assert.True(subject.isSinglePlayerGame(typeOfGame));
        }

        [Trait("Category", "UITest")]
        [Fact]
        public void userCanEnterYesIfSinglePlayerGame()
        {
            var subject = new UserInterface();            
            Assert.Equal(("Y"), subject.getTypeOfGame());
        }

    }
}

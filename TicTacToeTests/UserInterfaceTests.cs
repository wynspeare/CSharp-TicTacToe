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
            var myBoard = new Board();

            Assert.True(subject.isValidSpace("9", myBoard.board));   
            Assert.False(subject.isValidSpace("-1", myBoard.board));
            Assert.False(subject.isValidSpace("11", myBoard.board));
            Assert.False(subject.isValidSpace("Q", myBoard.board));   
        }


        [Trait("Category", "UITest")]
        [Fact]
        public void userCanEnterASpaceAndItsReturnsAnInteger()
        {
            var subject = new UserInterface();
            var myBoard = new Board();
            Assert.Equal(typeof(int), subject.getValidSpace(myBoard.board, P1_MARKER).GetType());
        }

        [Trait("Category", "UITest")]
        [Fact]
        public void userCanReadInstructions()
        {
            var subject = new UserInterface();
            Assert.Contains("Players alternate placing", subject.displayInstructions());
        }

    }
}

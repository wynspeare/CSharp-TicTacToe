using Xunit;
using System;
using System.Collections.Generic;
using TicTacToeApp;
using TicTacToeUserInterface;

namespace TicTacToeTests
{
    public class ComputerPlayerTest
    {

        [Fact]
        public void aComputerCanGenerateANumberBetweenOneAndNine()
        {
            var subject = new Space(1);
            Assert.True(subject.isSpaceEmpty());
        }

    }

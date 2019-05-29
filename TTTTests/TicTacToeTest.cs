using Xunit;
using System;
using TicTacToeApp;

namespace TicTacToeTests
{
    public class TTTTest
    {
        [Fact]
        public void userCanStartNewGame()
        {
            TicTacToe myTTT = new TicTacToe();
            Assert.Equal("A new game has been started", myTTT.Main());
        }

        // [Fact]
        // public void playerOneCanChooseAMarker()
        // {
        //     TicTacToe myTTT = new TicTacToe();
        //     myTTT.chooseMarker();
        //     Assert.NotNull(myTTT.playerOneMarker);
        //     Assert.NotNull(myTTT.playerTwoMarker);
        // }

        // [Fact]
        // public void userCanReadInstructions()
        // {
        //     TicTacToe myTTT = new TicTacToe();
        //     Assert.Contains("Players alternate placing", myTTT.displayInstructions());
        // }


        // [Fact]
        // public void aNewGameHasAnEmptyBoard()
        // {
        //     TicTacToe myTTT = new TicTacToe();
        //     myTTT.startNewGame();
        //     Assert.True(myTTT.currentBoard.isEmpty());
        // }

        // [Fact]
        // public void userCanViewTheBoard()
        // {
        //     TicTacToe myTTT = new TicTacToe();
        //     myTTT.startNewGame();
        //     Assert.Equal( " _ _ _ \n _ _ _ \n _ _ _ " , myTTT.currentBoard.displayBoard());
        // }

    }
}

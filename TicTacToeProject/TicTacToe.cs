using System;
using System.Collections;
using System.Collections.Generic;

namespace TicTacToeApp
{
    public class TicTacToe
    {

        public Board currentBoard;
        // public string currentTurn;
        public Player playerOne;
        public Player playerTwo;

        public Space currentSpace;


        public TicTacToe(string playerOneMarker)
        {
            this.currentBoard = new Board();
            this.playerOne = new Player(playerOneMarker);
            this.playerTwo = new Player("O"); 
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public void moveMarker(int location)
        {
            currentSpace = new Space(location);
            currentBoard.placeMarker(currentSpace);
        }

    }
}


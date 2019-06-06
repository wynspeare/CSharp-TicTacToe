using System;
using TicTacToeApp;

namespace TicTacToeUserInterface
{
  public class Options {

    public string P1_MARKER;
    public string P2_MARKER;

    public const string EMPTY = Symbols.EMPTY;
    public const int BOARD_SIZE = Symbols.BOARD_SIZE;

    public Options (string playerOneMarker, string playerTwoMarker)
    {
      this.P1_MARKER = playerOneMarker;
      this.P2_MARKER = playerTwoMarker;
    }

  }
}
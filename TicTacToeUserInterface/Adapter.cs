using System;
using TicTacToeApp;

namespace TicTacToeUserInterface
{
  public class Adapter {

    public string X_MARKER;
    public string O_MARKER;

    public const string EMPTY = Symbols.EMPTY;
    public const int BOARD_SIZE = Symbols.BOARD_SIZE;

    public Adapter (string playerOneMarker, string playerTwoMarker)
    {
      this.X_MARKER = playerOneMarker;
      this.O_MARKER = playerTwoMarker;
    }

  }
}
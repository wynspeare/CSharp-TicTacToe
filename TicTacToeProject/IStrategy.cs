namespace TicTacToeApp
{
    public interface IStrategy
    {
        string GetMove(string Marker, Board Board);
    }
}
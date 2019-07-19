namespace TicTacToeApp
{
    public interface IPlayer
    {
        string Marker { get; set; }

        string GetMove(Board Board);
    }
}
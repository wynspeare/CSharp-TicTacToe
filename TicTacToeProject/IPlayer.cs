namespace TicTacToeApp
{
    public interface IPlayer
    {
        string Marker { get; set; }

        string getMove(Board Board);
    }
}
namespace TicTacToeApp
{
    public interface PlayerInterface
    {
        string marker
        {
            get;
            set;
        }

        string getMove();
    }
}
namespace TicTacToeApp
{
    public interface IStrategy
    {
        string getMove();
        void setPlayers(IPlayer playerTwo, IPlayer playerOne);
    }
}
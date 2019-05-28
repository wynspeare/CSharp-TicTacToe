using Xunit;

namespace TicTacToe
{
    public class TicTacToeTest
    {
        [Fact]
        public void PassingTest()
        {
            TicTacToe myTTT = new TicTacToe();
            Assert.Equal(1, myTTT.method());

        }
    }
}

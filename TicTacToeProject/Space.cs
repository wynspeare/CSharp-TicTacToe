namespace TicTacToeApp
{
    public class Space
    {
        public int location;
        public string marker;

        public Space(int location, string marker = Symbols.EMPTY)
        {
            this.location = location;
            this.marker = marker;
        }

        public bool IsSpaceEmpty()
        {
            return marker == Symbols.EMPTY;
        }

        public bool IsSpaceFilled()
        {
            return marker != Symbols.EMPTY;
        }

    }
}  

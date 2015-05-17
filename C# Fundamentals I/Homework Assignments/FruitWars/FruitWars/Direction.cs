namespace FruitWars
{
    public class Direction
    {
        public Direction(int deltaRow, int deltaCol)
        {
            DeltaRow = deltaRow;
            DeltaCol = deltaCol;
        }

        public static Direction Left
        {
            get
            {
                return new Direction(0, -1);
            }
        }

        public static Direction Up
        {
            get
            {
                return new Direction(-1, 0);
            }
        }

        public static Direction Right
        {
            get
            {
                return new Direction(0, 1);
            }
        }

        public static Direction Down
        {
            get
            {
                return new Direction(1, 0);
            }
        }

        public int DeltaRow { get; private set; }

        public int DeltaCol { get; private set; }
    }
}

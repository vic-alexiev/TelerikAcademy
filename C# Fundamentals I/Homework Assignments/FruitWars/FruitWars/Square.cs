using FruitWars.Warriors;

namespace FruitWars
{
    public class Square<T> where T : GameObject
    {
        public Square(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public Square(int row, int col, T gameObject)
            : this(row, col)
        {
            GameObject = gameObject;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public T GameObject { get; set; }

        public static bool operator ==(Square<T> left, Square<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Square<T> left, Square<T> right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Square<T> square = (Square<T>)obj;
            return Row == square.Row && Col == square.Col;
        }

        public override int GetHashCode()
        {
            int prime = 83;
            int result = 1;

            unchecked
            {
                result = result * prime + Row.GetHashCode();
                result = result * prime + Col.GetHashCode();
            }

            return result;
        }
    }
}

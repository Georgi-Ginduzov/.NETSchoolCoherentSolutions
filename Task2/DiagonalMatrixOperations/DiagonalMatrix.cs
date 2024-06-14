namespace DiagonalMatrixOperations
{
    public class DiagonalMatrix<T>
    {
        private T[] _diagonal;

        public DiagonalMatrix(int size)
        {
            if (size < 0)
                throw new ArgumentException("Size must be non-negative.");

            _diagonal = new T[size];
        }

        public int Size
        {
            get
            {
                return _diagonal.Length;
            }
        }

        public event Action<int, int, T, T> ElementChanged;
        public T this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i >= Size || j >= Size)
                    throw new IndexOutOfRangeException();
                if (i != j)
                    return default(T);
                return _diagonal[i];
            }
            set
            {
                if (i < 0 || j < 0 || i >= Size || j >= Size)
                    throw new IndexOutOfRangeException();
                if (i == j && !EqualityComparer<T>.Default.Equals(_diagonal[i], value))
                {
                    ElementChanged?.Invoke(i, j, _diagonal[i], value);
                    _diagonal[i] = value;
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is DiagonalMatrix<T> other)
            {
                return Size == other.Size && _diagonal.SequenceEqual(other._diagonal);
            }
            return false;
        }

        public override string ToString()
        {
            return string.Join(", ", _diagonal);
        }

    }
}

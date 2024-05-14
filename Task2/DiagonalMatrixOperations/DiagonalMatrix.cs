using System.Runtime.CompilerServices;

namespace DiagonalMatrixOperations
{
    public class DiagonalMatrix
    {
        private int[] _diagonal;

        public DiagonalMatrix(params int[] elements)
        {
            _diagonal = elements ?? new int[0];
        }

        public int Size
        {
            get
            {
                return _diagonal.Length;
            }
        }

        public int this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i >= Size || j >= Size)
                    return 0;
                if (i != j)
                    return 0;
                return _diagonal[i];
            }
            set
            {
                if (i >= 0 && j >= 0 && i < Size && j < Size && i == j)
                    _diagonal[i] = value;
            }
        }

        public int Track()
        {
            return _diagonal.Sum();
        }

        public override bool Equals(object obj)
        {
            if (obj is DiagonalMatrix other)
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

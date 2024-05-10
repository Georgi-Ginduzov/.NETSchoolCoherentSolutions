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
                    throw new IndexOutOfRangeException();
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

        public DiagonalMatrix Add(DiagonalMatrix matrixB)
        {
            int[] result;
            DiagonalMatrix smallerMatrix;

            if (Size >= matrixB.Size)
            {
                result = this._diagonal;
                smallerMatrix = matrixB;
            }
            else
            {
                result = matrixB._diagonal;
                smallerMatrix = this;
            }

            for (int i = 0; i < smallerMatrix.Size; i++)
            {
                result[i] += smallerMatrix[i, i];
            }

            return new DiagonalMatrix(result);
        }

        public override string ToString()
        {
            return string.Join(", ", _diagonal);
        }
    }
}

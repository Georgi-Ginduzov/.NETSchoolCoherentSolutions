using System.ComponentModel;

namespace DiagonalMatrixOperations
{
    public class DiagonalMatrix
    {
        private int[] _diagonal;
        private int _size;


        public int Size
        {
            get => _size;
            private set
            {
                if (value < 0)
                {
                    _size = 0;
                }
            }
        }



























































        /*private readonly int[] _diagonal;

        public DiagonalMatrix(int[] diagonal)
        {
            _diagonal = diagonal;
        }

        public int[] GetDiagonal()
        {
            return _diagonal;
        }

        public void SetDiagonal(int[] diagonal)
        {
            _diagonal = diagonal;
        }

        public int GetElement(int row, int column)
        {
            return row == column ? _diagonal[row] : 0;
        }

        public void SetElement(int row, int column, int value)
        {
            if (row == column)
            {
                _diagonal[row] = value;
            }
        }

        public override string ToString()
        {
            var result = "";
            for (var i = 0; i < _diagonal.Length; i++)
            {
                for (var j = 0; j < _diagonal.Length; j++)
                {
                    result += GetElement(i, j) + " ";
                }

                result += "\n";
            }

            return result;
        }*/
    }
}

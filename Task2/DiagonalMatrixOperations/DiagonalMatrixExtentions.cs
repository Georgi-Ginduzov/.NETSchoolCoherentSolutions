namespace DiagonalMatrixOperations
{
    public static class DiagonalMatrixExtentions
    {
        public static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> matrixA, DiagonalMatrix<T> matrixB, Func<T, T, T> add)
        {
            DiagonalMatrix<T> resultMatrix;
            DiagonalMatrix<T> smallerMatrix;

            if (matrixA.Size >= matrixB.Size)
            {
                resultMatrix = new DiagonalMatrix<T>(matrixA.Size);
                smallerMatrix = new DiagonalMatrix<T>(matrixB.Size);
            }
            else
            {
                resultMatrix = new DiagonalMatrix<T>(matrixB.Size);
                smallerMatrix = new DiagonalMatrix<T>(matrixA.Size);
            }

            for (int i = 0; i < smallerMatrix.Size; i++)
            {
                resultMatrix[i, i] = add(matrixA[i,i], matrixB[i,i]);
            }

            return resultMatrix;
        }

        private static T[] GetArrayFromMatrix<T>(DiagonalMatrix<T> matrix)
        {
            T[] array = new T[matrix.Size];
            for (int i = 0; i < matrix.Size; i++)
            {
                array[i] = matrix[i, i];
            }

            return array;
        }

        
    }
}

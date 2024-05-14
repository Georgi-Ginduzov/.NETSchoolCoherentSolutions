namespace DiagonalMatrixOperations
{
    public static class DiagonalMatrixExtentions
    {
        public static DiagonalMatrix Add(this DiagonalMatrix matrixA, DiagonalMatrix matrixB)
        {
            DiagonalMatrix resultMatrix;
            DiagonalMatrix smallerMatrix;

            if (matrixA.Size >= matrixB.Size)
            {

                resultMatrix = new DiagonalMatrix(GetArrayFromMatrix(matrixA));
                smallerMatrix = new DiagonalMatrix(GetArrayFromMatrix(matrixB));
            }
            else
            {
                resultMatrix = new DiagonalMatrix(GetArrayFromMatrix(matrixB));
                smallerMatrix = new DiagonalMatrix(GetArrayFromMatrix(matrixA));
            }

            for (int i = 0; i < smallerMatrix.Size; i++)
            {
                resultMatrix[i, i] += smallerMatrix[i, i];
            }

            return resultMatrix;
        }

        private static int[] GetArrayFromMatrix(DiagonalMatrix matrix)
        {
            int[] array = new int[matrix.Size];
            for (int i = 0; i < matrix.Size; i++)
            {
                array[i] = matrix[i, i];
            }

            return array;
        }
    }
}

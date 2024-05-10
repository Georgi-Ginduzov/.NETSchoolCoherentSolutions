using DiagonalMatrixOperations;

namespace DiagonalMatrixOperationsTests
{
    public class Tests
    {
        [Test]
        public void ConstructorWithElementsShouldCreatesCorrectSize()
        {
            int[] elements = { 1, 2, 3 };
            DiagonalMatrix matrix = new DiagonalMatrix(elements);

            Assert.AreEqual(3, matrix.Size);
        }

        [Test]
        public void ConstructorWithNoElementsShouldCreatesEmptyMatrix()
        {
            DiagonalMatrix matrix = new DiagonalMatrix();

            Assert.AreEqual(0, matrix.Size);
        }

        [Test]
        public void IndexerOutOfBoundsShouldReturnZero()
        {
            DiagonalMatrix matrix = new DiagonalMatrix(3);

            Assert.AreEqual(0, matrix[-1, -1]);
            Assert.AreEqual(0, matrix[3, 3]);
        }

        [Test]
        public void AddDifferentSizesMatricesShouldMakePadsWithZeros()
        {
            DiagonalMatrix matrixA = new DiagonalMatrix(2, 1, 2);
            DiagonalMatrix matrixB = new DiagonalMatrix(1, 3);

            Assert.AreEqual(new DiagonalMatrix(2, 1, 2, 3), matrixA.Add(matrixB));
        }

        [Test]
        public void AddingEmptyMatrixShouldReturnNonEmptyMatrix()
        {
            DiagonalMatrix matrixA = new DiagonalMatrix(1, 2);
            DiagonalMatrix matrixB = new DiagonalMatrix();

            Assert.AreEqual(new DiagonalMatrix(1, 2), matrixA.Add(matrixB));
        }

        [Test]
        public void EqualsWithDifferentSizesShouldReturnFalse()
        {
            DiagonalMatrix matrixA = new DiagonalMatrix(2, 1, 2);
            DiagonalMatrix matrixB = new DiagonalMatrix(1, 3);

            Assert.IsFalse(matrixA.Equals(matrixB));
        }

        [Test]
        public void EqualsWithDifferentElementsShouldReturnFalse()
        {
            DiagonalMatrix matrixA = new DiagonalMatrix(2, 1, 2);
            DiagonalMatrix matrixB = new DiagonalMatrix(2, 1, 3);

            Assert.IsFalse(matrixA.Equals(matrixB));
        }

        [Test]
        public void TrackOfEmptyMatrixShouldReturnZero()
        {
            DiagonalMatrix matrix = new DiagonalMatrix();

            Assert.AreEqual(0, matrix.Track());
        }
    }
}
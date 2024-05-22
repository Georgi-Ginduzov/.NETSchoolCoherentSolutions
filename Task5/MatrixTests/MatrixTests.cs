namespace MatrixTests
{
    public class SparseMatrixTests
    {
        [Test]
        public void TestConstructor_ValidDimensions_ShouldCreateMatrix()
        {
            var matrix = new SparseMatrix(5, 5);
            Assert.AreEqual(0, matrix[0, 0]);
            Assert.AreEqual(0, matrix[4, 4]);
        }

        [Test]
        public void TestIndexer_SetAndGetElement_ShouldWorkCorrectly()
        {
            var matrix = new SparseMatrix(5, 5);
            matrix[1, 1] = 10;
            Assert.AreEqual(10, matrix[1, 1]);
        }

        [Test]
        public void TestIndexer_SetZero_ShouldRemoveElement()
        {
            var matrix = new SparseMatrix(5, 5);
            matrix[2, 2] = 20;
            Assert.AreEqual(20, matrix[2, 2]);
            matrix[2, 2] = 0;
            Assert.AreEqual(0, matrix[2, 2]);
        }

        [Test]
        public void TestToString_ShouldReturnCorrectString()
        {
            var matrix = new SparseMatrix(2, 2);
            matrix[0, 0] = 1;
            matrix[1, 1] = 2;
            string expected = "1 0 \n0 2 \n";
            Assert.AreEqual(expected, matrix.ToString());
        }

        [Test]
        public void TestGetNonzeroElements_ShouldReturnCorrectElements()
        {
            var matrix = new SparseMatrix(3, 3);
            matrix[0, 1] = 5;
            matrix[1, 0] = 3;
            matrix[2, 2] = 1;
            var expected = new List<(int, int, long)>
        {
            (1, 0, 3),
            (0, 1, 5),
            (2, 2, 1)
        };

            var result = matrix.GetNonzeroElements().ToList();
            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void TestGetCount_ShouldReturnCorrectCount()
        {
            var matrix = new SparseMatrix(3, 3);
            matrix[0, 0] = 4;
            matrix[1, 1] = 4;
            matrix[2, 2] = 4;
            matrix[0, 1] = 0;
            Assert.AreEqual(3, matrix.GetCount(4));
            Assert.AreEqual(6, matrix.GetCount(0));
        }

        [Test]
        public void TestGetEnumerator_ShouldEnumerateAllElements()
        {
            var matrix = new SparseMatrix(2, 2);
            matrix[0, 0] = 1;
            matrix[1, 1] = 2;
            var expected = new List<long> { 1, 0, 0, 2 };
            var result = matrix.ToList();
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void TestConstructor_InvalidDimensions_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new SparseMatrix(0, 5));
            Assert.Throws<ArgumentException>(() => new SparseMatrix(5, 0));
        }

        [Test]
        public void TestIndexer_InvalidIndex_ShouldThrowException()
        {
            var matrix = new SparseMatrix(2, 2);
            Assert.Throws<IndexOutOfRangeException>(() => { var value = matrix[2, 2]; });
            Assert.Throws<IndexOutOfRangeException>(() => { matrix[2, 2] = 10; });
        }
    }
}
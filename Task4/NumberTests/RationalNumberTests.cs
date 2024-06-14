using Number;

namespace NumberTests
{
    public class Tests
    {
        [Test]
        public void Constructor_ReducesFraction()
        {
            var rational = new RationalNumber(2, 6);
            Assert.AreEqual(1, rational.Numerator);
            Assert.AreEqual(3, rational.Denominator);
        }

        [Test]
        public void Constructor_ThrowsExceptionOnZeroDenominator()
        {
            Assert.Throws<ArgumentException>(() => new RationalNumber(1, 0));
        }

        [Test]
        public void Equals_ReturnsTrueForEqualRationals()
        {
            var rational1 = new RationalNumber(1, 2);
            var rational2 = new RationalNumber(2, 4);
            Assert.IsTrue(rational1.Equals(rational2));
        }

        [Test]
        public void ToString_ReturnsCorrectFormat()
        {
            var rational = new RationalNumber(1, 2);
            Assert.AreEqual("1/2", rational.ToString());
        }

        [Test]
        public void OperatorPlus_ReturnsCorrectResult()
        {
            var rational1 = new RationalNumber(1, 2);
            var rational2 = new RationalNumber(1, 3);
            var result = rational1 + rational2;
            Assert.AreEqual(5, result.Numerator);
            Assert.AreEqual(6, result.Denominator);
        }
        [Test]
        public void OperatorMinus_ReturnsCorrectResult()
        {
            var rational1 = new RationalNumber(1, 2);
            var rational2 = new RationalNumber(1, 3);
            var result = rational1 - rational2;
            Assert.AreEqual(1, result.Numerator);
            Assert.AreEqual(6, result.Denominator);
        }

        [Test]
        public void OperatorMultiply_ReturnsCorrectResult()
        {
            var rational1 = new RationalNumber(1, 2);
            var rational2 = new RationalNumber(1, 3);
            var result = rational1 * rational2;
            Assert.AreEqual(1, result.Numerator);
            Assert.AreEqual(6, result.Denominator);
        }

        [Test]
        public void OperatorDivide_ReturnsCorrectResult()
        {
            var rational1 = new RationalNumber(1, 2);
            var rational2 = new RationalNumber(1, 3);
            var result = rational1 / rational2;
            Assert.AreEqual(3, result.Numerator);
            Assert.AreEqual(2, result.Denominator);
        }

        [Test]
        public void OperatorExplicitCastToDouble_ReturnsCorrectResult()
        {
            var rational = new RationalNumber(1, 2);
            double result = (double)rational;
            Assert.AreEqual(0.5, result);
        }

        [Test]
        public void OperatorImplicitCastFromInt_ReturnsCorrectResult()
        {
            RationalNumber rational = 5;
            Assert.AreEqual(5, rational.Numerator);
            Assert.AreEqual(1, rational.Denominator);
        }
    }
}
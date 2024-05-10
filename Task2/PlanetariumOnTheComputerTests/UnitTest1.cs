using PlanetariumOnTheComputer;

namespace PlanetariumOnTheComputerTests
{
    public class PointClassTests
    {
        private Point point;

        [SetUp]
        public void Setup()
        {
            point = new Point(1, 2, 3, 4);
        }

        [Test]
        public void XGetterShouldReturnCorrectValue()
        {
            int expectedXValue = 1;
            int actualXValue = point.X;

            Assert.AreEqual(expectedXValue, actualXValue);
        }
        [Test]
        public void YGetterShouldReturnCorrectValue()
        {
            int expectedYValue = 2;
            int actualYValue = point.Y;

            Assert.AreEqual(expectedYValue, actualYValue);
        }
        [Test]
        public void ZGetterShouldReturnCorrectValue()
        {
            int expectedZValue = 3;
            int actualZValue = point.Z;

            Assert.AreEqual(expectedZValue, actualZValue);
        }
        [Test]
        public void MassGetterShouldReturnCorrectValue()
        {
            double expectedMassValue = 4;
            double actualMassValue = point.Mass;

            Assert.AreEqual(expectedMassValue, actualMassValue);
        }

        public void XSetterShouldSetCorrectValue()
        {
            int newValue = 5;
            int expectedXValue = newValue;

            point.X = newValue;

            int actualXValue = point.X;

            Assert.AreEqual(expectedXValue, actualXValue);
        }
        public void YSetterShouldSetCorrectValue()
        {
            int newValue = 5;
            int expectedXValue = newValue;

            point.Y = newValue;

            int actualXValue = point.Y;

            Assert.AreEqual(expectedXValue, actualXValue);
        }
        public void ZSetterShouldSetCorrectValue()
        {
            int newValue = 5;
            int expectedXValue = newValue;

            point.Z = newValue;

            int actualXValue = point.Z;

            Assert.AreEqual(expectedXValue, actualXValue);
        }
        public void MassSetterShouldSetCorrectValue()
        {
            double newValue = 5;
            double expectedXValue = newValue;

            point.Mass = newValue;

            double actualXValue = point.Mass;

            Assert.AreEqual(expectedXValue, actualXValue);
        }

        [Test]
        public void MassSeterShouldSetsToZeroIfNegative()
        {
            double negativeMass = -154;
            double expectedMass = 0;

            point.Mass = negativeMass;
            double actualMass = point.Mass;

            Assert.AreEqual(expectedMass, actualMass);
        }

        [Test]
        public void IsZeroShouldReturnTrueForOrigin()
        {
            point = new Point(0, 0, 0, 0);

            Assert.IsTrue(point.IsZero());
        }
        [Test]
        public void IsZeroShouldReturnFalseForNonOrigin()
        {
            Assert.IsFalse(point.IsZero());
        }

        [Test]
        public void DistanceToShouldCalculateCorrectlyTheDistance()
        {
            Point pointB = new Point(3, 5, 7, 0); // coordinates differences are (2, 3, 4)

            double expectedDistance = Math.Sqrt(29);
            double actualDistance = point.DistanceTo(pointB);

            Assert.AreEqual(expectedDistance, actualDistance);
        }
    }
}
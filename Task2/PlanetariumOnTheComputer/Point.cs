namespace PlanetariumOnTheComputer
{
    public class Point
    {
        private const int Dimensions = 3;
        private int[] _coordinates;
        private double _mass;

        public Point(int x, int y, int z, double mass)
        {
            _coordinates = new int[Dimensions];

            X = x;
            Y = y;
            Z = z;
            Mass = mass;
        }

        public int X { get => _coordinates[0]; set => _coordinates[0] = value; }
        public int Y { get => _coordinates[1]; set => _coordinates[1] = value; }
        public int Z { get => _coordinates[2]; set => _coordinates[2] = value; }
        public double Mass
        {
            get => _mass;
            set
            {
                _mass = value;

                if (value < 0)
                {
                    _mass = 0;
                }
            }
        }

        public bool IsZero()
        {
            return X == 0 && Y == 0 && Z == 0;
        }

        public double DistanceTo(Point pointB)
        {
            int xDifference = pointB.X - X;
            int yDifference = pointB.Y - Y;
            int zDifference = pointB.Z - Z;

            double distance = Math.Sqrt((xDifference * xDifference) + (yDifference * yDifference) + (zDifference * zDifference));
            return distance;
        }


    }
}

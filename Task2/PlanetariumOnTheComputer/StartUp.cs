using System.Drawing;

namespace PlanetariumOnTheComputer
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Point pointA = new Point(1, 2, 3, 4);
            Point pointB = new Point(3, 5, 7, 0);

            double distance = pointA.DistanceTo(pointB);

            Console.WriteLine(distance);
        }
    }
}

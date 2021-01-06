using MarsRover.Core.Rover;
using MarsRover.Core.Surface;
using System;

namespace MarsRover.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Enter Surface X Coordinate");
            string surfaceX = Console.ReadLine();
            Console.WriteLine("Enter Surface Y Coordinate");
            string surfaceY = Console.ReadLine();
            Size size = new Size(Convert.ToInt32(surfaceX), Convert.ToInt32(surfaceY));
            ISurface surface = new MarsSurface(size);
            Position position = new Position();
            Console.WriteLine("Enter Rover Landing Position");
            Console.WriteLine("Enter Rover Landing Position X");
            string roverx = Console.ReadLine();
            Console.WriteLine("Enter Rover Landing Position Y");
            string rovery = Console.ReadLine();
            position.Coordinate = new Coordinate(Convert.ToInt32(roverx), Convert.ToInt32(rovery));
            Console.WriteLine("Enter Rover Landing Position");
            Console.WriteLine("North -> 0");
            Console.WriteLine("East ->  1");
            Console.WriteLine("South -> 2");
            Console.WriteLine("West ->  3");
            string direction = Console.ReadLine();
            position.Direction = (Directions)(Convert.ToInt32(direction));
            Core.Rover.MarsRover marsRover = new Core.Rover.MarsRover();
            marsRover.LandingSurface(surface, position);
            Console.WriteLine("Command:");
            string cmmds = Console.ReadLine();
            marsRover.Action(cmmds);
            Console.WriteLine(marsRover.Position.Coordinate.CoordinateX.ToString() + " " + marsRover.Position.Coordinate.CoordinateY.ToString() + " " + marsRover.Position.Direction.ToString());
            Console.ReadLine();
        }
    }
}

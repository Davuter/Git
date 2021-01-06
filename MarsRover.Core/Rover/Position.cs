using MarsRover.Core.Surface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Rover
{
    public class Position
    {
        public Position()
        {

        }

        public Position(Coordinate coordinate, Directions direction)
        {
            Coordinate = coordinate;
            Direction = direction;
        }
        public Coordinate Coordinate { get; set; }
        public Directions Direction { get; set; }
    }
}

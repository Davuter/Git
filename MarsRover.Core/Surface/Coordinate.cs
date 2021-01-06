using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Surface
{
    public class Coordinate
    {
        public Coordinate() { }
        public Coordinate(long x, long y)
        {
            this.CoordinateX = x;
            this.CoordinateY = y;
        }
        public long CoordinateX { get; set; }
        public long CoordinateY { get; set; }

        public override string ToString()
        {
            return $"Coordinates: x:{CoordinateX}-y:{CoordinateY}";
        }
    }
}

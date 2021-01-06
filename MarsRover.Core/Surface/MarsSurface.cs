using MarsRover.Core.Rover;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Surface
{
    public class MarsSurface : ISurface
    {
        private List<IRover> Rovers { get; set; }
        public MarsSurface(Size size)
        {
            SetSize(size);
            Rovers = new List<IRover>();
        }
        private Size _size { get; set; }

        public void AddRovers(IRover rover)
        {
            Rovers.Add(rover);
        }
        public void RemoveRovers(IRover rover)
        {
            Rovers.Remove(rover);
        }

        public Size GetSize()
        {
            return _size;
        }

        public bool isValidCoordinate(Coordinate coordinate)
        {
            var isvalidX = coordinate.CoordinateX >= 0 && coordinate.CoordinateX <= _size.Width;
            var isValidY = coordinate.CoordinateY >= 0 && coordinate.CoordinateY <= _size.Height;
            return isvalidX && isValidY;
        }

        public void SetSize(Size size)
        {
            if ((size.Height < 0 || size.Width < 0) || (size.Height == 0 && size.Width == 0))
            {
                throw new ArgumentException("Invalid Surface Size");
            }
            _size = size;
        }
    }
}

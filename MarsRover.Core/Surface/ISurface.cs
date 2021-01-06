using MarsRover.Core.Rover;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Surface
{
    public interface ISurface
    {
        void SetSize(Size size);
        Size GetSize();
        bool isValidCoordinate(Coordinate coordinate);
        void AddRovers(IRover rover);
        void RemoveRovers(IRover rover);
    }
}

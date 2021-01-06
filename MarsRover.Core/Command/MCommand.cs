using MarsRover.Core.Rover;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Command
{
    public class MCommand : ICommand
    {
        public CommandTypes GetCommandType()
        {
            return CommandTypes.M;
        }

        public Position Run(IRover rover)
        {
            Position position = new Position();
            position = rover.Position;
            switch (rover.Position.Direction)
            {
                case Surface.Directions.E:
                    position.Coordinate.CoordinateX++;
                    break;
                case Surface.Directions.N:
                    position.Coordinate.CoordinateY++;
                    break;
                case Surface.Directions.S:
                    position.Coordinate.CoordinateY--;
                    break;
                case Surface.Directions.W:
                    position.Coordinate.CoordinateX--;
                    break;
            }
            // we are checking new position is valid for surface
            if (rover.Surface != null && rover.Surface.isValidCoordinate(position.Coordinate))
            {
                return position;
            }
            else
            {
                // We don't change rover position.
                return rover.Position;
            }
        }
    }
}

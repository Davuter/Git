using MarsRover.Core.Rover;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Command
{
    public class RCommand : ICommand
    {
        public CommandTypes GetCommandType()
        {
            return CommandTypes.R;
        }

        public Position Run(IRover rover)
        {
            Position roverPosition = rover.Position;

            switch (rover.Position.Direction)
            {
                case Surface.Directions.E:
                    roverPosition.Direction = Surface.Directions.S;
                    break;
                case Surface.Directions.S:
                    roverPosition.Direction = Surface.Directions.W;
                    break;
                case Surface.Directions.W:
                    roverPosition.Direction = Surface.Directions.N;
                    break;
                case Surface.Directions.N:
                    roverPosition.Direction = Surface.Directions.E;
                    break;
            }
            return roverPosition;
        }
    }
}

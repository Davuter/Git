using MarsRover.Core.Command;
using MarsRover.Core.Surface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Core.Rover
{
    public class MarsRover : IRover
    {
        public MarsRover()
        {

        }
        public Position Position { get; set; }
        public ISurface Surface { get; set; }
        public void Action(string commands)
        {
            List<char> commandList = commands.ToCharArray().ToList();
            CommandCreater commandCreater = new CommandCreater();
            foreach (var commandBtn in commandList)
            {
                ICommand command = commandCreater.GetCommand(commandBtn.ToString());
                this.Position = command.Run(this);
            }
        }

        public bool LandingSurface(ISurface surface, Position position)
        {
            Position = position;
            Surface = surface;
            if (surface.isValidCoordinate(position.Coordinate))
            {
                surface.AddRovers(this);
                return true;
            }
            return false;
           
        }
        public void DepartureSurface()
        {
            Surface.RemoveRovers(this);
        }
        public void SetPosition(Position position)
        {
            Position = position;
        }

        public void SetSurface(ISurface surface)
        {
            Surface = surface;
        }
    }
}

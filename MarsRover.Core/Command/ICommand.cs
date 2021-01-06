using MarsRover.Core.Rover;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Command
{
    public interface ICommand
    {
        CommandTypes GetCommandType();
        Position Run(IRover rover);
    }
}

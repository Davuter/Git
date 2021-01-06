using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Command
{
    public class CommandCreater
    {
        public ICommand GetCommand(string commandPrefix)
        {
            ICommand command = null;
            switch (commandPrefix)
            {
                case "L":
                    command = new LCommand();
                    break;
                case "R":
                    command = new RCommand();
                    break;
                case "M":
                    command = new MCommand();
                    break;
                default:
                    throw new InvalidOperationException("Invalid Command");
                   
            }
            return command;
        }
    }
}

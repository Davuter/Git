using MarsRover.Core.Command;
using MarsRover.Core.Rover;
using MarsRover.Core.Surface;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.Test
{
    public class CommandUnitTests
    {
        [Theory]
        [InlineData("K")]
        [InlineData("B")]
        public void Invalid_Command(string command)
        {
            var commandCreate = new Mock<CommandCreater>();
            Assert.Throws<InvalidOperationException>(() => commandCreate.Object.GetCommand(command));
        }
        [Theory]
        [InlineData("M","M")]
        [InlineData("L", "L")]
        [InlineData("R", "R")]
        public void ValidCommand(string command,string expectedCommandType)
        {
            var commandCreate = new Mock<CommandCreater>();
            var actualCommand = commandCreate.Object.GetCommand(command);
            Assert.Equal(actualCommand.GetCommandType().ToString(), expectedCommandType);
        }
        [Theory]
        [InlineData(1,2,Directions.N, Directions.W)]
        [InlineData(1, 2, Directions.W, Directions.S)]
        [InlineData(1, 2, Directions.S, Directions.E)]
        [InlineData(1, 2, Directions.E, Directions.N)]
        public void LCommandTest(int x, int y, Directions direction , Directions expected)
        {
            var commandCreate = new Mock<CommandCreater>();
            var actualCommand = commandCreate.Object.GetCommand("L");
            var rover = new Mock<Core.Rover.MarsRover>();
            var size = new Mock<Size>(5, 5);
            var surface = new Mock<MarsSurface>(size.Object);
            var currentPosition = new Mock<Position>(new Coordinate(x, y), (direction));
            rover.Object.LandingSurface(surface.Object, currentPosition.Object);

            var position = actualCommand.Run(rover.Object);

            Assert.Equal(position.Direction, expected);
        }


        [Theory]
        [InlineData(1, 2, Directions.N, Directions.E)]
        [InlineData(1, 2, Directions.E, Directions.S)]
        [InlineData(1, 2, Directions.S, Directions.W)]
        [InlineData(1, 2, Directions.W, Directions.N)]
        public void RCommandTest(int x, int y, Directions direction, Directions expected)
        {
            var commandCreate = new Mock<CommandCreater>();
            var actualCommand = commandCreate.Object.GetCommand("R");
            var rover = new Mock<Core.Rover.MarsRover>();
            var size = new Mock<Size>(5, 5);
            var surface = new Mock<MarsSurface>(size.Object);
            var currentPosition = new Mock<Position>(new Coordinate(x, y), (direction));
            rover.Object.LandingSurface(surface.Object, currentPosition.Object);

            var position = actualCommand.Run(rover.Object);

            Assert.Equal(position.Direction, expected);
        }

        [Theory]
        [InlineData(1, 2, Directions.N, 1,3)]
        [InlineData(1, 2, Directions.E, 2,2)]
        [InlineData(1, 2, Directions.S, 1,1)]
        [InlineData(1, 2, Directions.W, 0,2)]
        public void MCommandTest(int x, int y, Directions direction,int ex,int ey)
        {
            var commandCreate = new Mock<CommandCreater>();
            var actualCommand = commandCreate.Object.GetCommand("M");
            var rover = new Mock<Core.Rover.MarsRover>();
            var size = new Mock<Size>(5, 5);
            var surface = new Mock<MarsSurface>(size.Object);
            var currentPosition = new Mock<Position>(new Coordinate(x, y), (direction));
            rover.Object.LandingSurface(surface.Object, currentPosition.Object);

            var position = actualCommand.Run(rover.Object);

            Assert.Equal(position.Coordinate.CoordinateX, ex);
            Assert.Equal(position.Coordinate.CoordinateY, ey);
        }
    }
}

using MarsRover.Core;
using MarsRover.Core.Command;
using MarsRover.Core.Rover;
using MarsRover.Core.Surface;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.Test
{
    public class RoverUnitTests
    {
        [Theory]
        [ClassData(typeof(FailLandingRoverTestData))]
        public void Invalid_Coordinate_Landing_Rover(LandingRover landingRover)
        {
            var surface = new Mock<MarsSurface>(new Size(landingRover.SizeHeigth, landingRover.SizeWidth));
            var coordinate = new Coordinate(landingRover.LandingCoordinateX, landingRover.LandingCoordinateY);
            var position = new Position(coordinate, Directions.N);
            Core.Rover.MarsRover marsRover = new Core.Rover.MarsRover();
            var result = marsRover.LandingSurface(surface.Object, position);
            Assert.True(!result);
        }

        [Theory]
        [ClassData(typeof(SuccessLandingRoverTestData))]
        public void Success_Coordinate_Landing_Rover(LandingRover landingRover)
        {
            var surface = new Mock<MarsSurface>(new Size(landingRover.SizeHeigth, landingRover.SizeWidth));
            var coordinate = new Coordinate(landingRover.LandingCoordinateX, landingRover.LandingCoordinateY);
            var position = new Position(coordinate, Directions.N);
            Core.Rover.MarsRover marsRover = new Core.Rover.MarsRover();
            var result = marsRover.LandingSurface(surface.Object, position);
            Assert.True(result);
            Assert.Equal(position, marsRover.Position);
        }
        [Theory]
        [ClassData(typeof(MoveRoverTestData))]
        public void Move_Mars_Rover(MoveRover rover)
        {
           rover.MarsRover.Action(rover.Commands);
           Assert.Equal( rover.MarsRover.Position.Coordinate.CoordinateX, rover.ExpectedPosition.Coordinate.CoordinateX);
            Assert.Equal(rover.MarsRover.Position.Coordinate.CoordinateY, rover.ExpectedPosition.Coordinate.CoordinateY);
            Assert.Equal(rover.MarsRover.Position.Direction, rover.ExpectedPosition.Direction);
        }
    
    }

    public class FailLandingRoverTestData : TheoryData<LandingRover>
    {
      public FailLandingRoverTestData()
        {
            Add(new LandingRover { SizeHeigth = 5, SizeWidth = 5, LandingCoordinateX = -1, LandingCoordinateY = 0 });
            Add(new LandingRover { SizeHeigth = 2, SizeWidth = 1, LandingCoordinateX = 3, LandingCoordinateY = 4 });
            Add(new LandingRover { SizeHeigth = 4, SizeWidth = 4, LandingCoordinateX = 5, LandingCoordinateY = 0 });
            Add(new LandingRover { SizeHeigth = 3, SizeWidth = 5, LandingCoordinateX = 2, LandingCoordinateY = 6 });

        }
    }
    public class SuccessLandingRoverTestData : TheoryData<LandingRover>
    {
        public SuccessLandingRoverTestData()
        {
            Add(new LandingRover { SizeHeigth = 5, SizeWidth = 5, LandingCoordinateX = 1, LandingCoordinateY = 0 });
            Add(new LandingRover { SizeHeigth = 3, SizeWidth = 1, LandingCoordinateX = 3, LandingCoordinateY = 0 });
            Add(new LandingRover { SizeHeigth = 4, SizeWidth = 4, LandingCoordinateX = 2, LandingCoordinateY = 0 });
            Add(new LandingRover { SizeHeigth = 3, SizeWidth = 5, LandingCoordinateX = 2, LandingCoordinateY = 4 });

        }
    }
    public class LandingRover
    {
        public int SizeHeigth { get; set; }
        public int SizeWidth { get; set; }
        public int LandingCoordinateX { get; set; }
        public int LandingCoordinateY { get; set; }
    }

    public class MoveRoverTestData : TheoryData<MoveRover>
    {
        public MoveRoverTestData()
        {
            Add(new MoveRover() {
                MarsRover = new Core.Rover.MarsRover()
                {
                    Position = new Position(new Coordinate(1, 2), Directions.N),
                    Surface = new MarsSurface(new Size(5, 5))
                },
                Commands = "LMLMLMLMM",
                ExpectedPosition = new Position(new Coordinate(1,3),Directions.N)
            });

            Add(new MoveRover()
            {
                MarsRover = new Core.Rover.MarsRover()
                {
                    Position = new Position(new Coordinate(3, 3), Directions.E),
                    Surface = new MarsSurface(new Size(5, 5))
                },
                Commands = "MMRMMRMRRM",
                ExpectedPosition = new Position(new Coordinate(5, 1), Directions.E)
            });

        }
        
    }


    public class MoveRover
    {
        public Core.Rover.MarsRover MarsRover { get; set; }
        public string Commands { get; set; }
        public Position ExpectedPosition { get; set; }
    }
    public class TestDataGenerator
    {
       
    }  
}

using MarsRover.Core.Surface;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.Test
{
    public class SurfaceUnitTests
    {
        [Theory]
        [InlineData(-5,-5)]
        [InlineData(0, 0)]
     
        public void Invalid_Surface_Size(int x,int y)
        {
            var size = new Size(x, y);
            Assert.Throws<ArgumentException>(() => new MarsSurface(size));                
        }
        [Theory]
        [InlineData(5, 5)]      
        public void Get_Surface_Size(int x,int y)
        {
            var size = new Size(x, y);
            var marsSurface = new MarsSurface(size);
            var marsSurfaceSize = marsSurface.GetSize();
            Assert.Equal(size, marsSurfaceSize);
        }
        [Theory]
        [InlineData(5, 5,1,-1)]
        [InlineData(3, 4, 1, -1)]
        public void Invalid_Coordinate_ForSurface(int height,int width,int coordinatex,int coordinatey)
        {
            var marsSurface = new Mock<MarsSurface>(new Size(height,width));
            var result = marsSurface.Object.isValidCoordinate(new Coordinate(coordinatex, coordinatey));
            Assert.True(!result);
        }
        [Theory]
        [InlineData(5, 5, 1, 3)]
        [InlineData(3, 4, 3, 4)]
        public void Valid_Coordinate_ForSurface(int height, int width, int coordinatex, int coordinatey)
        {
            var marsSurface = new Mock<MarsSurface>(new Size(height, width));
            var result = marsSurface.Object.isValidCoordinate(new Coordinate(coordinatex, coordinatey));
            Assert.True(result);

        }
        [Theory]
        [InlineData(3,3)]
        public void SetSize_Surface(int x, int y)
        {
            var marsSurface = new Mock<MarsSurface>(new Size(5, 5));
            var newSize = new Size(x, y);
            marsSurface.Object.SetSize(newSize);
            Assert.Equal(newSize, marsSurface.Object.GetSize());
        }
    }
}

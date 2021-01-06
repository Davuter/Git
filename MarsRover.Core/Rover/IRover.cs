using MarsRover.Core.Surface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Rover
{
    public interface IRover
    {
        /// <summary>
        /// Rover current Position
        /// </summary>
        Position Position { get; set; }
        void SetPosition(Position position);
        ISurface Surface { get; set; }
        void SetSurface(ISurface surface);
        void Action(string commands);
        bool LandingSurface(ISurface surface,Position position);
        void DepartureSurface();

    }
}

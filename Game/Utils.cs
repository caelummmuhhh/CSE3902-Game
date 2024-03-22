using System;
using Microsoft.Xna.Framework;

namespace MainGame
{
    public enum CardinalAndOrdinalDirection
    {
        North, NorthEast, East, SouthEast, South, SouthWest, West, NorthWest
    }

    public enum CardinalDirections
    {
        North, East, South, West,
    }

    public static class Constants
    {
        /// <summary>
        /// Represents the number that everything will be multiplied by to get
        /// "scaled up". Also represents the size of one "pixel".
        /// </summary>
        public static readonly int UniversalScale = 3;
    }

    public static class Utils
    {
        public static Rectangle CentralizeRectangle(int desiredX, int desiredY, Rectangle rectangle)
        {
            return new(
                desiredX - rectangle.Width / 2, desiredY - rectangle.Height / 2,
                rectangle.Width, rectangle.Height
                );
        }
    }

}


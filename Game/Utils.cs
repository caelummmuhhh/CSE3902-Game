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
        public static readonly int UniversalScale = 3;
    }

    public static class Utils
    {
        public static Rectangle CentralizeRectangle(int desiredX, int desiredY, Rectangle rectangle)
        {
            return new(
                desiredX - rectangle.X / 2, desiredY - rectangle.Y / 2,
                rectangle.Width, rectangle.Height
                );
        }
    }

}


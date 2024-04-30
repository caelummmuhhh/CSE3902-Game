using System;
using System.IO;
using System.Data;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using static System.Net.WebRequestMethods;
using System.Text;

namespace MainGame
{
    public enum Direction
    {
        North, NorthEast, East, SouthEast, South, SouthWest, West, NorthWest
    }

    public enum BlockTypes
    {
        BlueFloor, SquareBlock, StatueOneEntrance, StatueTwoEntrance, StatueOneEnd,
        StatueTwoEnd, BlackSquare, BlueSand, BlueGap, Stairs, WhiteBrick, WhiteLadder,
        PushableBlock
    }

    public enum ItemTypes
    {
        Heart, HeartContainer, Clock, FiveRupees, Rupee, Map, Boomerang, Bomb, Bow,
        Arrow, Key, Compass, TriforcePiece, Fairy, Fire, Candle
    }

    public enum DoorTypes
    {
        WallNormal, OpenDoor, KeyDoor, DiamondDoor, DestroyedWall, WallDestructible = 0
    };

    public static class Constants
    {
        /// <summary>
        /// Represents the number that everything will be multiplied by to get
        /// "scaled up". Also represents the size of one "pixel".
        /// </summary>
        public static readonly int UniversalScale = 3;

        /// <summary>
        /// Represents the size of one grid block.
        /// </summary>
        public static readonly int BlockSize = 16 * UniversalScale;

        public static readonly int HudAndMenuHeight = 56 * UniversalScale;

        public static readonly int RoomScrollingSpeed = 5;
    }

    public static class Utils
    {
        public static Rectangle CentralizeRectangle(int desiredX, int desiredY, Rectangle rectangle)
        {
            return new(
                desiredX + rectangle.Width / 2, desiredY + rectangle.Height / 2,
                rectangle.Width, rectangle.Height
                );
        }

        public static Vector2 CalculateDirectionVector(Vector2 start, Vector2 end)
        {
            double dx = end.X - start.X;
            double dy = end.Y - start.Y;

            double distance = Math.Sqrt(dx * dx + dy * dy);

            dx /= distance;
            dy /= distance;

            return new Vector2((float)dx, (float)dy);
        }

        public static Direction CalculateMoveDirection(double dx, double dy)
        {
            double angle = Math.Atan2(dy, dx);
            int octant = Convert.ToInt32(8d * angle / (2d * Math.PI) + 8d) % 8;

            return octant switch
            {
                0 => Direction.East,
                1 => Direction.NorthEast,
                2 => Direction.North,
                3 => Direction.NorthWest,
                4 => Direction.West,
                5 => Direction.SouthWest,
                6 => Direction.South,
                7 => Direction.SouthEast,

                _ => Direction.North // shouldn't be possible
            };
        }

        public static Direction GetDirectionFrom(Vector2 source, Vector2 target)
        {
            float dx = target.X - source.X;
            float dy = target.Y - source.Y;
            return CalculateMoveDirection(dx, dy);
        }

        public static Direction GetCardinalDirectionFrom(Vector2 source, Vector2 target)
        {
            float dx = target.X - source.X;
            float dy = target.Y - source.Y;
            double angle = Math.Atan2(dy, dx);
            int octant = Convert.ToInt32(4d * angle / (2d * Math.PI) + 4d) % 4;
            return octant switch
            {
                0 => Direction.East,
                1 => Direction.South,
                2 => Direction.West,
                3 => Direction.North,

                _ => Direction.North // shouldn't be possible
            };
        }

        public static Direction OppositeDirection(Direction direction)
        {
            return direction switch
            {
                Direction.North => Direction.South,
                Direction.NorthEast => Direction.SouthWest,
                Direction.East => Direction.West,
                Direction.SouthEast => Direction.NorthWest,
                Direction.South => Direction.North,
                Direction.SouthWest => Direction.NorthEast,
                Direction.West => Direction.East,
                Direction.NorthWest => Direction.SouthEast,
                _ => direction
            };
        }

        public static Vector2 DirectionalMove(Vector2 startingPosition, Direction direction, float speed)
        {
            float x = startingPosition.X;
            float y = startingPosition.Y;
            return direction switch
            {
                Direction.North => new Vector2(x, y - speed),
                Direction.NorthEast => new Vector2(x + speed, y - speed),
                Direction.East => new Vector2(x + speed, y),
                Direction.SouthEast => new Vector2(x + speed, y + speed),
                Direction.South => new Vector2(x, y + speed),
                Direction.SouthWest => new Vector2(x - speed, y + speed),
                Direction.West => new Vector2(x - speed, y),
                Direction.NorthWest => new Vector2(x - speed, y - speed),
                _ => startingPosition
            };
        }

        public static Direction GetRandomCardinalDirection()
        {
            return Randomize(Direction.North, Direction.East, Direction.South, Direction.West);
        }

        public static Direction GetRandomCardinalAndOrdinalDirection()
        {
            return Randomize(Enum.GetValues(typeof(Direction)).Cast<Direction>().ToArray());
        }
        public static ItemTypes GetRandomCollectableItem()
        {
            return Randomize(ItemTypes.HeartContainer, ItemTypes.Map, ItemTypes.Boomerang, ItemTypes.Bomb, ItemTypes.Bow, ItemTypes.Compass);
        }
        public static Direction CharToDirection(char dir)
        {
            switch (dir)
            {
                case 'N':
                    return Direction.North;
                case 'S':
                    return Direction.South;
                case 'W':
                    return Direction.West;
                case 'E':
                    return Direction.East;
                default:
                    throw new IOException("Invalid input char");
            }
        }

        public static T Randomize<T>(params T[] values)
        {
            Random random = new();
            int randomIndex = random.Next(values.Length);
            return values[randomIndex];
        }
    }
}


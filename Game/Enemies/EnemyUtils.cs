using System;
using Microsoft.Xna.Framework;

namespace MainGame.Enemies
{
    // TODO: Add a constants class or something to hold all the magic numbers
    public static class EnemyUtils
	{
        public static CardinalDirections GetRandomCardinalDirection()
        {
            Random random = new();
            int randDirectionInt = random.Next(0, Enum.GetNames(typeof(CardinalDirections)).Length);
            return (CardinalDirections)randDirectionInt;
        }

        public static CardinalAndOrdinalDirection GetRandomCardinalAndOrdinalDirection()
        {
            Random random = new();
            int randDirectionInt = random.Next(0, Enum.GetNames(typeof(CardinalAndOrdinalDirection)).Length);
            return (CardinalAndOrdinalDirection)randDirectionInt;

        }

        public static Vector2 DirectionalMove(Vector2 startingPosition, CardinalAndOrdinalDirection direction, int speed)
        {
            float x = startingPosition.X;
            float y = startingPosition.Y;
            return direction switch
            {
                CardinalAndOrdinalDirection.North => new Vector2(x, y - speed),
                CardinalAndOrdinalDirection.NorthEast => new Vector2(x + speed, y - speed),
                CardinalAndOrdinalDirection.East => new Vector2(x + speed, y),
                CardinalAndOrdinalDirection.SouthEast => new Vector2(x + speed, y + speed),
                CardinalAndOrdinalDirection.South => new Vector2(x, y + speed),
                CardinalAndOrdinalDirection.SouthWest => new Vector2(x - speed, y + speed),
                CardinalAndOrdinalDirection.West => new Vector2(x - speed, y),
                CardinalAndOrdinalDirection.NorthWest => new Vector2(x - speed, y - speed),
                _ => startingPosition
            };
        }

        public static Vector2 DirectionalMove(Vector2 startingPosition, CardinalDirections direction, int speed)
        {
            float x = startingPosition.X;
            float y = startingPosition.Y;
            return direction switch
            {
                CardinalDirections.North => new Vector2(x, y - speed),
                CardinalDirections.East => new Vector2(x + speed, y),
                CardinalDirections.South => new Vector2(x, y + speed),
                CardinalDirections.West => new Vector2(x - speed, y),
                _ => startingPosition
            };
        }
    }
}


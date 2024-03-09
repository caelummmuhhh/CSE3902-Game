using System;
using System.Linq;
using MainGame.Players;
using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MainGame.Enemies
{
    public enum EnemyTypes
    {
        Aquamentus,
        Gel,
        Goriya,
        Keese,
        OldMan,
        SpikeCross,
        Stalfos,
        WallMaster
    }

    // TODO: Add a constants class or something to hold all the magic numbers
    public static class EnemyUtils
	{
        public static CardinalDirections GetRandomCardinalDirection()
        {
            return Randomize(Enum.GetValues(typeof(CardinalDirections)).Cast<CardinalDirections>().ToArray());
        }

        public static CardinalAndOrdinalDirection GetRandomCardinalAndOrdinalDirection()
        {
            return Randomize(Enum.GetValues(typeof(CardinalAndOrdinalDirection)).Cast<CardinalAndOrdinalDirection>().ToArray());
        }

        public static T Randomize<T>(params T[] values)
        {
            Random random = new();
            int randomIndex = random.Next(values.Length);
            return values[randomIndex];
        }

        public static CardinalDirections OppositeDirection(CardinalDirections direction)
        {
            return direction switch
            {
                CardinalDirections.North => CardinalDirections.South,
                CardinalDirections.East => CardinalDirections.West,
                CardinalDirections.South => CardinalDirections.North,
                CardinalDirections.West => CardinalDirections.East,
                _ => direction
            };
        }

        public static CardinalAndOrdinalDirection OppositeDirection(CardinalAndOrdinalDirection direction)
        {
            return direction switch
            {
                CardinalAndOrdinalDirection.North => CardinalAndOrdinalDirection.South,
                CardinalAndOrdinalDirection.NorthEast => CardinalAndOrdinalDirection.SouthWest,
                CardinalAndOrdinalDirection.East => CardinalAndOrdinalDirection.West,
                CardinalAndOrdinalDirection.SouthEast => CardinalAndOrdinalDirection.NorthWest,
                CardinalAndOrdinalDirection.South => CardinalAndOrdinalDirection.North,
                CardinalAndOrdinalDirection.SouthWest => CardinalAndOrdinalDirection.NorthEast,
                CardinalAndOrdinalDirection.West => CardinalAndOrdinalDirection.East,
                CardinalAndOrdinalDirection.NorthWest => CardinalAndOrdinalDirection.SouthEast,
                _ => direction
            };
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

        public static IEnemy CreateEnemy(EnemyTypes enemy, Vector2 position, IPlayer player)
        {
            return enemy switch
            {
                EnemyTypes.Aquamentus => new AquamentusEnemy(position, player),
                EnemyTypes.Gel => new GelEnemy(position),
                EnemyTypes.Goriya => new GoriyaEnemy(position),
                EnemyTypes.Keese => new KeeseEnemy(position),
                EnemyTypes.OldMan => new OldManEnemy(position),
                EnemyTypes.SpikeCross => new SpikeCrossEnemy(position, player),
                EnemyTypes.Stalfos => new StalfosEnemy(position),
                EnemyTypes.WallMaster => new WallMasterEnemy(position, player),
                _ => null,
            };
        }

        /// <summary>
        /// Tries to create an enemy based on given name.
        /// </summary>
        /// <param name="enemyName">The name of the enemy.</param>
        /// <returns>The ISprite object created based on the given enemy name</returns>
        /// <exception cref="ArgumentException">The enemy name does not match to a enemy.</exception>
        public static IEnemy CreateEnemy(string enemyName, Vector2 position, IPlayer player)
        {
            bool conversionSuccess = Enum.TryParse(enemyName, true, out EnemyTypes enemy);

            if (!conversionSuccess)
            {
                throw new ArgumentException("Unable to parse enemy name string into an enemy.");
            }

            return CreateEnemy(enemy, position, player);
        }

    }
}


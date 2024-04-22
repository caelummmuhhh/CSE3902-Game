using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MainGame.SpriteHandlers.ItemSprites;
using System;
using System.Diagnostics;

namespace MainGame.SpriteHandlers
{
    public enum DoorTypes { WallNormal, OpenDoor, KeyDoor, DiamondDoor, DestroyedWall, WallDestructible = 0 };

    public static partial class SpriteFactory
    {
        public static ISprite CreateDoorTopNorthSouth(Direction direction, DoorTypes doorType)
        {
            int dirNum = DirectionToDoorLocationMultiplier(direction);
            return new DoorSegmentNorthSouth(
                TextureMap["RoomSprites"], SpriteBatch,
                textureStartingY: 704 + 32 * dirNum,
                textureStartingX: 32 * (int)doorType,
                scale: Constants.UniversalScale
                );
        }

        public static ISprite CreateDoorBottomNorthSouth(Direction direction, DoorTypes doorType)
        {
            int dirNum = DirectionToDoorLocationMultiplier(direction);
            return new DoorSegmentNorthSouth(
                TextureMap["RoomSprites"], SpriteBatch,
                textureStartingY: 704 + 16 + 32 * dirNum,
                textureStartingX: 32 * (int)doorType,
                scale: Constants.UniversalScale
                );
        }

        public static ISprite CreateDoorTopWestEast(Direction direction, DoorTypes doorType)
        {
            int dirNum = DirectionToDoorLocationMultiplier(direction);
            return new DoorSegmentWestEast(
                TextureMap["RoomSprites"], SpriteBatch,
                textureStartingY: 704 + 32 * dirNum,
                textureStartingX: 32 * (int)doorType,
                scale: Constants.UniversalScale
                );
        }

        public static ISprite CreateDoorBottomWestEast(Direction direction, DoorTypes doorType)
        {
            int dirNum = DirectionToDoorLocationMultiplier(direction);
            return new DoorSegmentWestEast(
                TextureMap["RoomSprites"], SpriteBatch,
                textureStartingY: 704 + 32 * dirNum,
                textureStartingX: 16 + 32 * (int)doorType,
                scale: Constants.UniversalScale
                );
        }

        private static int DirectionToDoorLocationMultiplier(Direction direction)
        {
            return direction switch
            {
                Direction.North => 0,
                Direction.South => 1,
                Direction.West => 2,
                Direction.East => 3,
                _ => 0
            };
        }

        public static DoorTypes DoorTypeFromString(string doorTypeName)
        {
            bool conversionSuccess = Enum.TryParse(doorTypeName, true, out DoorTypes doorType);

            if (!conversionSuccess)
            {
                throw new ArgumentException("Unable to parse door type name string into a door type.");
            }

            return doorType;
        }
    }
}

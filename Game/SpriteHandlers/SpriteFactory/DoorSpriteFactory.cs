using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MainGame.SpriteHandlers.ItemSprites;
using System;

namespace MainGame.SpriteHandlers
{
    public static partial class SpriteFactory
    {
        private enum Dir { North, South, West, East };
        public enum DoorTypes { wallNormal, openDoor, keyDoor, diamondDoor, destroyedWall, wallDestructible = 0};

        public static ISprite CreateDoorTopNorthSouth(string direction, string doorType)
        {
            DoorTypes DoorType = (DoorTypes)Enum.Parse(typeof(DoorTypes), doorType);
            Dir Direction = (Dir)Enum.Parse(typeof(Dir), direction);
            return new DoorSegmentNorthSouth(
                TextureMap["RoomSprites"], SpriteBatch,
                textureStartingY: (704 + 32 * (int)Direction),
                textureStartingX: (32 * (int)DoorType),
                scale: Constants.UniversalScale
                );
        }

        public static ISprite CreateDoorBottomNorthSouth(string direction, string doorType)
        {
            DoorTypes DoorType = (DoorTypes)Enum.Parse(typeof(DoorTypes), doorType);
            Dir Direction = (Dir)Enum.Parse(typeof(Dir), direction);
            return new DoorSegmentNorthSouth(
                TextureMap["RoomSprites"], SpriteBatch,
                textureStartingY: (704 + 16 + 32*(int)Direction),
                textureStartingX: (32*(int)DoorType),
                scale: Constants.UniversalScale
                );
        }

        public static ISprite CreateDoorTopWestEast(string direction, string doorType)
        {
            DoorTypes DoorType = (DoorTypes)Enum.Parse(typeof(DoorTypes), doorType);
            Dir Direction = (Dir)Enum.Parse(typeof(Dir), direction);
            return new DoorSegmentWestEast(
                TextureMap["RoomSprites"], SpriteBatch,
                textureStartingY: (704 + 32 * (int)Direction),
                textureStartingX: (32 * (int)DoorType),
                scale: Constants.UniversalScale
                );
        }

        public static ISprite CreateDoorBottomWestEast(string direction, string doorType)
        {
            DoorTypes DoorType = (DoorTypes)Enum.Parse(typeof(DoorTypes), doorType);
            Dir Direction = (Dir)Enum.Parse(typeof(Dir), direction);
            return new DoorSegmentWestEast(
                TextureMap["RoomSprites"], SpriteBatch,
                textureStartingY: (704 + 32 * (int)Direction),
                textureStartingX: (16 + 32 * (int)DoorType),
                scale: Constants.UniversalScale
                );
        }
    }
}

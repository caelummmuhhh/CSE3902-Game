using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MainGame.SpriteHandlers.ItemSprites;
using System;

namespace MainGame.SpriteHandlers
{
    public static partial class SpriteFactory
    {
        public enum dir { North, South, West, East };
        public enum type { wallNormal, openDoor, keyDoor, diamondDoor, destroyedWall, wallDestructible = 0 };
        public static ISprite CreateDoorTopNorthSouth(String direction, String doorType)
        {
            type DoorType = (type)Enum.Parse(typeof(type), doorType);
            dir Direction = (dir)Enum.Parse(typeof(dir), direction);
            return new DoorSegmentNorthSouth(
                TextureMap["RoomSprites"], SpriteBatch,
                textureStartingY: (704 + 32 * (int)Direction),
                textureStartingX: (32 * (int)DoorType),
                scale: 3
                );
        }
        public static ISprite CreateDoorBottomNorthSouth(String direction, String doorType)
        {
            type DoorType = (type)Enum.Parse(typeof(type), doorType);
            dir Direction = (dir)Enum.Parse(typeof(dir), direction);
            return new DoorSegmentNorthSouth(
                TextureMap["RoomSprites"], SpriteBatch,
                textureStartingY: (704 + 16 + 32*(int)Direction),
                textureStartingX: (32*(int)DoorType),
                scale: 3
                );
        }
        public static ISprite CreateDoorTopWestEast(String direction, String doorType)
        {
            type DoorType = (type)Enum.Parse(typeof(type), doorType);
            dir Direction = (dir)Enum.Parse(typeof(dir), direction);
            return new DoorSegmentWestEast(
                TextureMap["RoomSprites"], SpriteBatch,
                textureStartingY: (704 + 32 * (int)Direction),
                textureStartingX: (32 * (int)DoorType),
                scale: 3
                );
        }
        public static ISprite CreateDoorBottomWestEast(String direction, String doorType)
        {
            type DoorType = (type)Enum.Parse(typeof(type), doorType);
            dir Direction = (dir)Enum.Parse(typeof(dir), direction);
            return new DoorSegmentWestEast(
                TextureMap["RoomSprites"], SpriteBatch,
                textureStartingY: (704 + 32 * (int)Direction),
                textureStartingX: (16 + 32 * (int)DoorType),
                scale: 3
                );
        }
    }
}

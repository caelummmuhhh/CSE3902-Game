using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Xna.Framework;

using MainGame.Doors;
using MainGame.Rooms;
using MainGame.SpriteHandlers;
using MainGame.BlocksAndItems;
using MainGame.Enemies;
using MainGame.Players;
using MainGame.Collision;

namespace MainGame.Rooms
{
    public static class RoomFactory
    {
        /*
         * Method for generating a room object based on a room name as specified in Content/Rooms
         */
        public static IRoom GenerateRoom(string roomFile, IPlayer player)
        {
            string fullPath = Path.GetFullPath(roomFile);
            string[] lines = ParseCsv(fullPath);
            int roomNumber = Path.GetFileNameWithoutExtension(fullPath)[^1];

            if (lines == null)
            {
                throw new IOException($"Could not read CSV file to room: {roomFile}");
            }
            
            IRoom room = ParseRoomType(lines[0]); // Parse and set room to a new room object
            room.RoomId = roomNumber;
            ParseDoors(lines[1], room);
            room.RoomPlayer = player;

            for (int i = 2; i < lines.Length; i++)
            {
                ParseItemsAndBlocks(lines[i], room, i - 2);
                ParseEnemies(lines[i], room, player, i - 2);
            }

            return room;
        }

        /*
         * Method to parse csv into an array of each line
         */
        private static string[] ParseCsv(string csvName)
        {
            if (File.Exists(csvName))
            {
                string[] lines = File.ReadAllLines(csvName);

                return lines;
            }
            return null;
        }

        /*
         * Method for setting the game.Room parameter to the correct room style based on the inputted line
         */
        private static IRoom ParseRoomType(string line)
        {
            string roomName = line.Replace(",", "");
            switch (roomName)
            {
                case "dungeonNormal":
                    return new Room(
                        SpriteFactory.CreateRoomOuterBorderSprite(),
                        SpriteFactory.CreateRoomInnerBorderSprite(),
                        SpriteFactory.CreateDungeonTilesSprite()
                        );
                case "undergroundRoom":
                    return new Room(
                        SpriteFactory.CreateEmptyRoomSprite(),
                        SpriteFactory.CreateEmptyRoomSprite(),
                        SpriteFactory.CreateUndergroundRoomSprite()
                        );
                case "dungeonOldMan":
                    return new Room(
                        SpriteFactory.CreateRoomOuterBorderSprite(),
                        SpriteFactory.CreateRoomInnerBorderSprite(),
                        SpriteFactory.CreateEmptyRoomSprite()
                        );
                default:
                    throw new FormatException($"Unable to read room type from format, unknown room type \"{roomName}\"");
            }
        }

        /* 
         * Method for setting the doors of the room based on csv
         */
        private static void ParseDoors(string line, IRoom room)
        {
            // Parse raw csv line into 4 doors names
            string[] doors = line.Split(',');

            // Create each door
            if (!doors[0].Equals("-"))
            {
                room.NorthDoor = new Door(
                     new Vector2(112 * Constants.UniversalScale, 0 * Constants.UniversalScale),
                     SpriteFactory.CreateDoorTopNorthSouth("North", doors[0]),
                     SpriteFactory.CreateDoorBottomNorthSouth("North", doors[0]),
                     Direction.North
                 );
                room.PlayerBorderHitBox.Add(new TopHorizontalDoorWallHitBox());
            }
            else
            {
                room.NorthDoor = new BlankDoor();
                room.PlayerBorderHitBox.Add(new TopFullHorizontalWallHitBox());
            }

            if (!doors[1].Equals("-"))
            {
                room.SouthDoor = new Door(
                new Vector2(112 * Constants.UniversalScale, 160 * Constants.UniversalScale),
                SpriteFactory.CreateDoorTopNorthSouth("South", doors[1]),
                SpriteFactory.CreateDoorBottomNorthSouth("South", doors[1]),
                Direction.South
                );
                room.PlayerBorderHitBox.Add(new BottomHorizontalDoorWallHitBox());
            }
            else
            {
                room.SouthDoor = new BlankDoor();
                room.PlayerBorderHitBox.Add(new BottomFullHorizontalWallHitBox());
            }

            if (!doors[2].Equals("-"))
            {
                room.EastDoor = new Door(
                new Vector2(0 * Constants.UniversalScale, 72 * Constants.UniversalScale),
                SpriteFactory.CreateDoorTopWestEast("West", doors[2]),
                SpriteFactory.CreateDoorBottomWestEast("West", doors[2]),
                Direction.West
                );
                room.PlayerBorderHitBox.Add(new RightVerticalDoorWallHitBox());
            }
            else
            {
                room.EastDoor = new BlankDoor();
                room.PlayerBorderHitBox.Add(new RightFullVerticalWallHitBox());
            }

            if (!doors[3].Equals("-"))
            {
                room.WestDoor = new Door(
                new Vector2(240 * Constants.UniversalScale, 72 * Constants.UniversalScale),
                SpriteFactory.CreateDoorTopWestEast("East", doors[3]),
                SpriteFactory.CreateDoorBottomWestEast("East", doors[3]),
                Direction.East
                );
                room.PlayerBorderHitBox.Add(new LeftVerticalDoorWallHitBox());
            }
            else
            {
                room.WestDoor = new BlankDoor();
                room.PlayerBorderHitBox.Add(new LeftFullVerticalWallHitBox());
            }
        }

        private static void ParseItemsAndBlocks(string line, IRoom room, int yOffset)
        {
            int wallOffsetX = 32 * Constants.UniversalScale;
            int wallOffsetY = 32 * Constants.UniversalScale;
            int columnWidth = 16 * Constants.UniversalScale;

            string[] objects = line.Split(',');
            // Each block/item in objects[] will try to be parsed into either a block or object
            // if parsed, a new block/item object will be added to game1's current set of objects
            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i].Equals("-"))
                {
                    continue;
                }

                // TODO: Maybe we should have a BlocksFactory instead of using block sprite type, so we can control the collideability
                bool blockSuccess = Enum.TryParse(objects[i], true, out BlockTypes block);
                Vector2 position = new (wallOffsetX + i * columnWidth, wallOffsetY + yOffset * columnWidth);
                if (blockSuccess)
                {
                    room.RoomBlocks.Add(BlockFactory.CreateBlock(block, position));
                }
                else
                {
                    bool itemSuccess = Enum.TryParse(typeof(ItemTypes), objects[i], true, out object item);
                    if (itemSuccess)
                    {
                        room.RoomItems.Add(
                            new Item(
                                    new Vector2(wallOffsetX + i * columnWidth, wallOffsetY + yOffset * columnWidth),
                                    SpriteFactory.CreateItemSprite((ItemTypes)item)
                                ));
                    }
                }
                objects[i] = "-";
            }
        }

        private static void ParseEnemies(string line, IRoom room, IPlayer player, int yOffset)
        {
            int wallOffsetX = 32 * Constants.UniversalScale;
            int wallOffsetY = 32 * Constants.UniversalScale;
            int columnWidth = 16 * Constants.UniversalScale;

            string[] objects = line.Split(',');
            
            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i].Equals("-")) {
                    continue;
                }

                try
                {
                    Vector2 spawnPosition = new(wallOffsetX + i * columnWidth, wallOffsetY + yOffset * columnWidth);
                    IEnemy enemy = EnemyUtils.CreateEnemy(objects[i], spawnPosition, player);
                    room.RoomEnemies.Add(enemy);
                }
                catch { /* nothing to do for now */ }
            }
        }
    }
}
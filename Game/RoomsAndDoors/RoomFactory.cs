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

namespace MainGame.RoomsAndDoors
{
    public static class RoomFactory
    {
        /*
         * Method for generating a room object based on a room name as specified in Content/Rooms
         */
        public static Room GenerateRoom(int roomNum, Game1 game)
        {
            Room room = null;

            string path = Path.Combine("Content", "Rooms", $"Room_{roomNum}.csv");
            string[] lines = ParseCsv(path);
            if (lines == null)
            {
                Debug.WriteLine("Error reading filename");
            }
            else
            {
                room = ParseRoomType(lines[0], game); // Parse and set room to a new room object
                ParseDoors(lines[1], room);
                for (int i = 2; i < lines.Length; i++)
                {
                    ParseItemsAndBlocks(lines[i], room, i - 2);
                    ParseEnemies(lines[i], room, game.Player, i - 2);
                }
            }
            room.CurrentRoom = roomNum;
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
        private static Room ParseRoomType(string line, Game1 game)
        {
            switch (line)
            {
                case "dungeonNormal,,,,,,,,,,,":
                    return new Room(
                        SpriteFactory.CreateRoomOuterBorderSprite(),
                        SpriteFactory.CreateRoomInnerBorderSprite(),
                        SpriteFactory.CreateDungeonTilesSprite(),
                        game
                        );
                case "undergroundRoom,,,,,,,,,,,":
                    return new Room(
                        SpriteFactory.CreateEmptyRoomSprite(),
                        SpriteFactory.CreateEmptyRoomSprite(),
                        SpriteFactory.CreateUndergroundRoomSprite(),
                        game
                        );
                case "dungeonOldMan,,,,,,,,,,,":
                    return new Room(
                        SpriteFactory.CreateRoomOuterBorderSprite(),
                        SpriteFactory.CreateRoomInnerBorderSprite(),
                        SpriteFactory.CreateEmptyRoomSprite(),
                        game
                        );
            }
            return null;
        }

        /* 
         * Method for setting the doors of the room based on csv
         */
        private static void ParseDoors(string line, Room room)
        {
            // Parse raw csv line into 4 doors names
            string[] doors = line.Split(',');

            // Create each door
            if (!doors[0].Equals("-"))
            {
                room.NorthDoor = new Door(
                     new Vector2(336, 0),
                     SpriteFactory.CreateDoorTopNorthSouth("North", doors[0]),
                     SpriteFactory.CreateDoorBottomNorthSouth("North", doors[0]),
                     "North"
                 );
            }

            if (!doors[1].Equals("-"))
            {
                room.SouthDoor = new Door(
                new Vector2(336, 480),
                SpriteFactory.CreateDoorTopNorthSouth("South", doors[1]),
                SpriteFactory.CreateDoorBottomNorthSouth("South", doors[1]),
                "South"
                );
            }

            if (!doors[2].Equals("-"))
            {
                room.EastDoor = new Door(
                new Vector2(0, 216),
                SpriteFactory.CreateDoorTopWestEast("West", doors[2]),
                SpriteFactory.CreateDoorBottomWestEast("West", doors[2]),
                "West"
                );
            }

            if (!doors[3].Equals("-"))
            {
                room.WestDoor = new Door(
                new Vector2(720, 216),
                SpriteFactory.CreateDoorTopWestEast("East", doors[3]),
                SpriteFactory.CreateDoorBottomWestEast("East", doors[3]),
                "East"
                );
            }
        }

        private static void ParseItemsAndBlocks(string line, Room room, int yOffset)
        {
            int wallOffsetX = 32 * Constants.UniversalScale;
            int wallOffsetY = 32 * Constants.UniversalScale;
            int columnWidth = 16 * Constants.UniversalScale;

            string[] objects = line.Split(',');
            // Each block/item in objects[] will try to be parsed into either a block or object
            // if parsed, a new block/item object will be added to game1's current set of objects
            for (int i = 0; i < objects.Length; i++)
            {
                bool blockSuccess = Enum.TryParse(typeof(BlockSpriteTypes), objects[i], true, out object block);
                if (blockSuccess)
                {
                    room.Blocks.Add(
                        new Block(
                                new Vector2(wallOffsetX + i * columnWidth, wallOffsetY + yOffset * columnWidth),
                                SpriteFactory.CreateBlock((BlockSpriteTypes)block)
                            ));
                }
                else
                {
                    bool itemSuccess = Enum.TryParse(typeof(ItemSpriteTypes), objects[i], true, out object item);
                    if (itemSuccess)
                    {
                        room.Items.Add(
                            new Item(
                                    new Vector2(wallOffsetX + i * columnWidth, wallOffsetY + yOffset * columnWidth),
                                    SpriteFactory.CreateItemSprite((ItemSpriteTypes)item)
                                ));
                    }
                }
            }
        }

        private static void ParseEnemies(string line, Room room, IPlayer player, int yOffset)
        {
            int wallOffsetX = 32 * Constants.UniversalScale;
            int wallOffsetY = 32 * Constants.UniversalScale;
            int columnWidth = 16 * Constants.UniversalScale;
            int blockCenter = 30;

            string[] objects = line.Split(',');
            
            for (int i = 0; i < objects.Length; i++)
            {
                try
                {
                    Vector2 spawnPosition = new(wallOffsetX + i * columnWidth + blockCenter, wallOffsetY + yOffset * columnWidth + blockCenter);
                    IEnemy enemy = EnemyUtils.CreateEnemy(objects[i], spawnPosition, player);
                    room.Enemies.Add(enemy);
                }
                catch { /* nothing to do for now */ }
            }
        }
    }
}
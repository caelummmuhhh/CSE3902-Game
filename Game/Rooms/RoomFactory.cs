using System;
using System.IO;
using Microsoft.Xna.Framework;

using MainGame.Doors;
using MainGame.Rooms;
using MainGame.SpriteHandlers;
using MainGame.Blocks;
using MainGame.Items;
using MainGame.Enemies;
using MainGame.Players;
using MainGame.Collision;
using System.Diagnostics;
using System.Collections.Generic;
using MainGame.Particles;

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

            for (int i = 2; i < lines.Length-1; i++)
            {
                ParseItemsAndBlocks(ref lines[i], room, i - 2);
                ParseEnemies(lines[i], room, player, i - 2);
            }

            int[] connectingRooms = ParseConnectingRooms(lines[lines.Length-1]);
            room.ConnectingRooms = connectingRooms;

            room.DoorLocations[0] = room.NorthDoor.Position;
            room.DoorLocations[1] = room.SouthDoor.Position;
            room.DoorLocations[2] = room.EastDoor.Position;
            room.DoorLocations[3] = room.WestDoor.Position;

            // Again still in progress but I have to do some weird stuff to avoid refrences... gonna come back and clean up later
            room.BaseRoomBlocks = new Vector2[room.RoomBlocks.Count];
            room.BaseRoomEnemies = new Vector2[room.RoomEnemies.Count];
            room.BaseRoomItems = new Vector2[room.RoomItems.Count];
            room.BaseRoomParticles = new Vector2[room.RoomParticles.Count];
            for (int i = 0; i < room.RoomBlocks.Count; i++)
            {
                room.BaseRoomBlocks[i] = new Vector2(room.RoomBlocks[i].Position.X, room.RoomBlocks[i].Position.Y);
            }
            for (int i = 0; i < room.RoomEnemies.Count; i++)
            {
                room.BaseRoomEnemies[i] = new Vector2(room.RoomEnemies[i].Position.X, room.RoomEnemies[i].Position.Y);
            }
            for (int i = 0; i < room.RoomItems.Count; i++)
            {
                room.BaseRoomItems[i] = new Vector2(room.RoomItems[i].Position.X, room.RoomItems[i].Position.Y);
            }
            for (int i = 0; i < room.RoomParticles.Count; i++)
            {
                room.BaseRoomParticles[i] = new Vector2(room.RoomParticles[i].Position.X, room.RoomParticles[i].Position.Y);
            }
            return room;
        }

        /*
         * Method for parsing out connecting rooms 
         */
        private static int[] ParseConnectingRooms(string line)
        {
            int[] connectingRoomNumbers = new int[4];
            string[] connections = line.Split(',');
            for (int i = 0; i < connections.Length; i++)
            {
                if (!Int32.TryParse(connections[i], out connectingRoomNumbers[i])) 
                {
                    connectingRoomNumbers[i] = -1; // Room does not exist
                }
            }
            return connectingRoomNumbers;
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
                DoorTypes doorType = SpriteFactory.DoorTypeFromString(doors[0]);
                room.NorthDoor = new Door(
                     new Vector2(112 * Constants.UniversalScale, Constants.HudAndMenuHeight),
                     SpriteFactory.CreateDoorTopNorthSouth(Direction.North, doorType),
                     SpriteFactory.CreateDoorBottomNorthSouth(Direction.North, doorType),
                     Direction.North
                 );
                if (doorType is DoorTypes.OpenDoor || doorType is DoorTypes.DestroyedWall)
                {
                    room.PlayerBorderHitBox.Add(new TopHorizontalDoorWallHitBox());
                }
                else
                {
                    room.PlayerBorderHitBox.Add(new TopFullHorizontalWallHitBox());
                }
            }
            else
            {
                room.NorthDoor = new BlankDoor();
                room.PlayerBorderHitBox.Add(new TopFullHorizontalWallHitBox());
            }

            if (!doors[1].Equals("-"))
            {
                DoorTypes doorType = SpriteFactory.DoorTypeFromString(doors[1]);
                room.SouthDoor = new Door(
                new Vector2(112 * Constants.UniversalScale, 160 * Constants.UniversalScale + Constants.HudAndMenuHeight),
                SpriteFactory.CreateDoorTopNorthSouth(Direction.South, doorType),
                SpriteFactory.CreateDoorBottomNorthSouth(Direction.South, doorType),
                Direction.South
                );
                if (doorType is DoorTypes.OpenDoor || doorType is DoorTypes.DestroyedWall)
                {
                    room.PlayerBorderHitBox.Add(new BottomHorizontalDoorWallHitBox());
                }
                else
                {
                    room.PlayerBorderHitBox.Add(new BottomFullHorizontalWallHitBox());
                }
            }
            else
            {
                room.SouthDoor = new BlankDoor();
                room.PlayerBorderHitBox.Add(new BottomFullHorizontalWallHitBox());
            }

            if (!doors[2].Equals("-"))
            {
                DoorTypes doorType = SpriteFactory.DoorTypeFromString(doors[2]);
                room.EastDoor = new Door(
                new Vector2(0 * Constants.UniversalScale, 72 * Constants.UniversalScale + Constants.HudAndMenuHeight),
                SpriteFactory.CreateDoorTopWestEast(Direction.West, doorType),
                SpriteFactory.CreateDoorBottomWestEast(Direction.West, doorType),
                Direction.West
                );
                if (doorType is DoorTypes.OpenDoor || doorType is DoorTypes.DestroyedWall)
                {
                    room.PlayerBorderHitBox.Add(new LeftVerticalDoorWallHitBox());
                }
                else
                {
                    room.PlayerBorderHitBox.Add(new LeftFullVerticalWallHitBox());
                }
            }
            else
            {
                room.EastDoor = new BlankDoor();
                room.PlayerBorderHitBox.Add(new LeftFullVerticalWallHitBox());
            }

            if (!doors[3].Equals("-"))
            {
                DoorTypes doorType = SpriteFactory.DoorTypeFromString(doors[3]);
                room.WestDoor = new Door(
                new Vector2(240 * Constants.UniversalScale, 72 * Constants.UniversalScale + Constants.HudAndMenuHeight),
                SpriteFactory.CreateDoorTopWestEast(Direction.East, doorType),
                SpriteFactory.CreateDoorBottomWestEast(Direction.East, doorType),
                Direction.East
                );
                if (doorType is DoorTypes.OpenDoor || doorType is DoorTypes.DestroyedWall)
                {
                    room.PlayerBorderHitBox.Add(new RightVerticalDoorWallHitBox());
                }
                else
                {
                    room.PlayerBorderHitBox.Add(new RightFullVerticalWallHitBox());
                }
            }
            else
            {
                room.WestDoor = new BlankDoor();
                room.PlayerBorderHitBox.Add(new RightFullVerticalWallHitBox());
            }
        }

        private static void ParseItemsAndBlocks(ref string line, IRoom room, int yOffset)
        {
            int wallOffsetX = GameConstants.RoomFactoryWallOffsetX * Constants.UniversalScale;
            int wallOffsetY = GameConstants.RoomFactoryWallOffsetY * Constants.UniversalScale + Constants.HudAndMenuHeight;
            int columnWidth = GameConstants.RoomFactoryColumnWidth * Constants.UniversalScale;

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
                    objects[i] = "-";
                }
                else
                {
                    bool itemSuccess = Enum.TryParse(typeof(ItemTypes), objects[i], true, out object item);
                    if (itemSuccess)
                    {
                        room.RoomItems.Add(
                            new GenericItem(
                                    new Vector2(wallOffsetX + i * columnWidth, wallOffsetY + yOffset * columnWidth),
                                    SpriteFactory.CreateItemSprite((ItemTypes)item), (ItemTypes)item
                                ));
                        objects[i] = "-";
                    }
                }
            }
            line = string.Join(',', objects);
        }

        private static void ParseEnemies(string line, IRoom room, IPlayer player, int yOffset)
        {
            int wallOffsetX = GameConstants.RoomFactoryWallOffsetX * Constants.UniversalScale;
            int wallOffsetY = GameConstants.RoomFactoryWallOffsetY * Constants.UniversalScale+ Constants.HudAndMenuHeight;
            int columnWidth = GameConstants.RoomFactoryColumnWidth * Constants.UniversalScale;

            string[] objects = line.Split(',');
            
            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i].Equals("-")) {
                    continue;
                }
                Vector2 spawnPosition = new(wallOffsetX + i * columnWidth, wallOffsetY + yOffset * columnWidth);

                try
                {
                    IEnemy enemy = EnemyUtils.CreateEnemy(objects[i], spawnPosition, player);
                    room.RoomEnemies.Add(enemy);
                }
                catch
                {
                    IEnemy createdEnemy = EnemyUtils.CreateItemBindedEnemy(objects[i], spawnPosition, out IItem createdItem, player);
                    room.RoomEnemies.Add(createdEnemy);
                    room.RoomItems.Add(createdItem);
                }
            }
        }
    }
}
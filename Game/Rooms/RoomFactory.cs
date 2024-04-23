using System;
using System.IO;
using Microsoft.Xna.Framework;

using MainGame.Doors;
using MainGame.Rooms;
using MainGame.SpriteHandlers;
using MainGame.Blocks;
using MainGame.WorldItems;
using MainGame.Enemies;
using MainGame.Players;
using MainGame.Collision;
using MainGame.Audio;
using MainGame.Dungeons;
using MainGame.Particles;
using System.Linq;
using System.Diagnostics;

namespace MainGame.Rooms
{
    public static class RoomFactory
    {
        /*
         * Method for generating a room object based on a room name as specified in Content/Rooms
         */
        public static IRoom GenerateRoom(string roomFile, IPlayer player, GameRoomManager roomManager)
        {
            string fullPath = Path.GetFullPath(roomFile);
            string[] lines = ParseCsv(fullPath);
            int roomNumber = Path.GetFileNameWithoutExtension(fullPath)[^1];

            if (lines == null)
            {
                throw new IOException($"Could not read CSV file to room: {roomFile}");
            }

            IRoom room = ParseRoomType(lines[0].Replace(",", "")); // Parse and set room to a new room object
            room.RoomId = roomNumber;
            ParseDoors(lines[1], room);
            room.RoomPlayer = player;


            for (int i = 2; i < lines.Length; i++)
            {
                ParseItemsAndBlocks(ref lines[i], room, player, i - 2, roomManager);
                ParseEnemies(lines[i], room, player, i - 2);
            }

            GenerateHitboxes(room, lines[0].Replace(",", ""));
            AddAdditionalElements(room, lines[0].Replace(",", ""));

            return room;
        }
        private static void AddAdditionalElements(IRoom room, string roomType)
        {
            if (roomType.Equals("undergroundRoom"))
            {
                // This is probably where the trigger to leave this room will be added
            }
            else if (roomType.Equals("dungeonOldMan"))
            {
                room.RoomEnemies.Add(
                            EnemyUtils.CreateEnemy("oldMan",
                            new Vector2(120 * Constants.UniversalScale, 4 * Constants.BlockSize + Constants.HudAndMenuHeight),
                            room.RoomPlayer
                            ));

                room.RoomParticles.Add(
                    ParticleFactory.GetFireParticle(new Vector2(72 * Constants.UniversalScale, 4 * Constants.BlockSize + Constants.HudAndMenuHeight)));
                room.RoomParticles.Add(
                    ParticleFactory.GetFireParticle(new Vector2(168 * Constants.UniversalScale, 4 * Constants.BlockSize + Constants.HudAndMenuHeight)));
                room.RoomText = SpriteFactory.CreateTextSprite("          EASTMOST PENNINSULA\n               IS THE SECRET.");
            }
        }
        private static void GenerateHitboxes(IRoom room, string roomType)
        {
            if (roomType.Equals("dungeonNormal"))
            {
                // Hitbox stuff in doors should maybe be moved to here
            }
            else if (roomType.Equals("dungeonOldMan"))
            {
                room.PlayerBorderHitBox.Add(new TopFullHorizontalWallHitBox(3 * Constants.BlockSize));
            } else if (roomType.Equals("undergroundRoom"))
            {
                // TO DO
            }
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
        private static IRoom ParseRoomType(string roomName)
        {
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
                room.NorthDoor.DoorType = doorType;
                if (doorType == DoorTypes.OpenDoor || doorType == DoorTypes.DestroyedWall)
                {
                    room.PlayerBorderHitBox.Add(new TopHorizontalDoorWallHitBox());
                    room.NorthDoor.IsOpen = true;
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

            if (!doors[0].Equals("-"))
            {
                DoorTypes doorType = SpriteFactory.DoorTypeFromString(doors[1]);
                room.SouthDoor = new Door(
                new Vector2(112 * Constants.UniversalScale, 160 * Constants.UniversalScale + Constants.HudAndMenuHeight),
                SpriteFactory.CreateDoorTopNorthSouth(Direction.South, doorType),
                SpriteFactory.CreateDoorBottomNorthSouth(Direction.South, doorType),
                Direction.South
                );
                if(doorType == DoorTypes.OpenDoor) room.SouthDoor.IsOpen = true;
                room.SouthDoor.DoorType = doorType;
                if (doorType == DoorTypes.OpenDoor || doorType == DoorTypes.DestroyedWall)
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

            if (!doors[0].Equals("-"))
            {
                DoorTypes doorType = SpriteFactory.DoorTypeFromString(doors[2]);
                room.EastDoor = new Door(
                new Vector2(0 * Constants.UniversalScale, 72 * Constants.UniversalScale + Constants.HudAndMenuHeight),
                SpriteFactory.CreateDoorTopWestEast(Direction.West, doorType),
                SpriteFactory.CreateDoorBottomWestEast(Direction.West, doorType),
                Direction.West
                );
                if (doorType == DoorTypes.OpenDoor) room.SouthDoor.IsOpen = true;
                room.EastDoor.DoorType = doorType;
                if (doorType == DoorTypes.OpenDoor || doorType == DoorTypes.DestroyedWall)
                {
                    room.PlayerBorderHitBox.Add(new LeftVerticalDoorWallHitBox());
                    room.EastDoor.IsOpen = true;
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

            if (!doors[0].Equals("-"))
            {
                DoorTypes doorType = SpriteFactory.DoorTypeFromString(doors[3]);
                room.WestDoor = new Door(
                new Vector2(240 * Constants.UniversalScale, 72 * Constants.UniversalScale + Constants.HudAndMenuHeight),
                SpriteFactory.CreateDoorTopWestEast(Direction.East, doorType),
                SpriteFactory.CreateDoorBottomWestEast(Direction.East, doorType),
                Direction.East
                );
                if (doorType == DoorTypes.OpenDoor) room.SouthDoor.IsOpen = true;
                room.WestDoor.DoorType = doorType;
                if (doorType == DoorTypes.OpenDoor || doorType == DoorTypes.DestroyedWall)
                {
                    room.PlayerBorderHitBox.Add(new RightVerticalDoorWallHitBox());
                    room.WestDoor.IsOpen = true;
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
            room.DoorBaseLocations = new Vector2[] { room.NorthDoor.Position, room.SouthDoor.Position, room.EastDoor.Position, room.WestDoor.Position };
        }

        private static void ParseItemsAndBlocks(ref string line, IRoom room, IPlayer player, int yOffset, GameRoomManager roomManager)
        {
            int wallOffsetX = 32 * Constants.UniversalScale;
            int wallOffsetY = 32 * Constants.UniversalScale + Constants.HudAndMenuHeight;
            int columnWidth = 16 * Constants.UniversalScale;

            string[] objects = line.Split(',');
            // Each block/item in objects[] will try to be parsed into either a block or object
            // if parsed, a new block/item object will be added to game1's current set of objects
            for (int i = 0; i < objects.Length; i++)
            {
                Vector2 tilePosition = new(wallOffsetX + i * columnWidth, wallOffsetY + yOffset * columnWidth);

                if (objects[i].Equals("-"))
                {
                    continue;
                }

                IBlock block = BlockFactory.CreateBlock(objects[i], tilePosition);
                if (block is not null)
                {
                    room.RoomBlocks.Add(block);
                    objects[i] = "-";
                    continue;
                }

                IPickupableItem item = ItemFactory.CreateItem(objects[i], tilePosition, player, roomManager);
                if (item is not null)
                {
                    room.RoomItems.Add(item);
                    objects[i] = "-";
                }
            }
            line = string.Join(',', objects);
            room.BlockBaseLocations = new Vector2[room.RoomBlocks.Count];
            for (int i = 0; i < room.RoomBlocks.Count; i++)
            {
                room.BlockBaseLocations[i] = new Vector2(room.RoomBlocks[i].Position.X, room.RoomBlocks[i].Position.Y);
            }
        }

        private static void ParseEnemies(string line, IRoom room, IPlayer player, int yOffset)
        {
            int wallOffsetX = 32 * Constants.UniversalScale;
            int wallOffsetY = 32 * Constants.UniversalScale + Constants.HudAndMenuHeight;
            int columnWidth = 16 * Constants.UniversalScale;

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
                    IEnemy createdEnemy = EnemyUtils.CreateItemBindedEnemy(objects[i], spawnPosition, out IPickupableItem createdItem, player);
                    room.RoomEnemies.Add(createdEnemy);
                    room.RoomItems.Add(createdItem);
                }
            }
        }
    }
}
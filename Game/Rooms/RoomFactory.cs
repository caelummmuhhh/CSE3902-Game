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
using MainGame.Particles;

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

            string itemState = lines[9].Replace(",", "");
            for (int i = 2; i < lines.Length - 1; i++)
            {
                ParseItemsAndBlocks(ref lines[i], room, player, i - 2, roomManager, itemState.Equals("Locked"));
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
            IRoom createdRoom; 
            switch (roomName)
            {
                case "dungeonNormal":
                    createdRoom =  new Room(
                        SpriteFactory.CreateRoomOuterBorderSprite(),
                        SpriteFactory.CreateRoomInnerBorderSprite(),
                        SpriteFactory.CreateDungeonTilesSprite()
                        );
                    createdRoom.PlayerBorderHitBox.Add(new AllDoorWallHitBox());
                    break;
                case "undergroundRoom":
                    createdRoom = new Room(
                        SpriteFactory.CreateEmptyRoomSprite(),
                        SpriteFactory.CreateEmptyRoomSprite(),
                        SpriteFactory.CreateUndergroundRoomSprite()
                        );
                    createdRoom.PlayerBorderHitBox.Add(new AllFullWallHitBox());
                    break;
                case "dungeonOldMan":
                    createdRoom = new Room(
                        SpriteFactory.CreateRoomOuterBorderSprite(),
                        SpriteFactory.CreateRoomInnerBorderSprite(),
                        SpriteFactory.CreateEmptyRoomSprite()
                        );
                    createdRoom.PlayerBorderHitBox.Add(new AllDoorWallHitBox());
                    break;
                default:
                    throw new FormatException($"Unable to read room type from format, unknown room type \"{roomName}\"");
            }
            return createdRoom;
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
                Vector2 doorPos = new(112 * Constants.UniversalScale, Constants.HudAndMenuHeight);
                room.NorthDoor = DoorUtils.CreateDungeonDoor(doorPos, Direction.North, doorType);
            }
            else
            {
                room.NorthDoor = new BlankDoor();
            }

            if (!doors[1].Equals("-"))
            {
                DoorTypes doorType = SpriteFactory.DoorTypeFromString(doors[1]);
                Vector2 doorPos = new(112 * Constants.UniversalScale, 160 * Constants.UniversalScale + Constants.HudAndMenuHeight);
                room.SouthDoor = DoorUtils.CreateDungeonDoor(doorPos, Direction.South, doorType);
            }
            else
            {
                room.SouthDoor = new BlankDoor();
            }

            if (!doors[2].Equals("-"))
            {
                DoorTypes doorType = SpriteFactory.DoorTypeFromString(doors[2]);
                Vector2 doorPos = new(0 * Constants.UniversalScale, 72 * Constants.UniversalScale + Constants.HudAndMenuHeight);
                room.WestDoor = DoorUtils.CreateDungeonDoor(doorPos, Direction.West, doorType);
            }
            else
            {
                room.WestDoor = new BlankDoor();
            }

            if (!doors[3].Equals("-"))
            {
                DoorTypes doorType = SpriteFactory.DoorTypeFromString(doors[3]);
                Vector2 doorPos = new(240 * Constants.UniversalScale, 72 * Constants.UniversalScale + Constants.HudAndMenuHeight);
                room.EastDoor = DoorUtils.CreateDungeonDoor(doorPos, Direction.East, doorType);
            }
            else
            {
                room.EastDoor = new BlankDoor();
            }
        }

        private static void ParseItemsAndBlocks(ref string line, IRoom room, IPlayer player, int yOffset, GameRoomManager roomManager, bool lockedItems)
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
                    if (lockedItems) 
                    { 
                        room.WaitingRoomItems.Add(item); 
                    } 
                    else
                    {
                        room.RoomItems.Add(item);
                    }
                    
                    objects[i] = "-";
                }
            }
            line = string.Join(',', objects);
        }

        private static void ParseEnemies(string line, IRoom room, IPlayer player, int yOffset)
        {
            int wallOffsetX = 32 * Constants.UniversalScale;
            int wallOffsetY = 32 * Constants.UniversalScale + Constants.HudAndMenuHeight;
            int columnWidth = 16 * Constants.UniversalScale;

            string[] objects = line.Split(',');
            
            for (int i = 0; i < objects.Length - 1; i++)
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
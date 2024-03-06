using System;
using System.Diagnostics;
using System.IO;
using System.Reflection.Metadata;
using System.Xml.Linq;
using MainGame.Doors;
using MainGame.Rooms;
using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;

namespace MainGame.RoomsAndDoors
{
    public static class RoomFactory
    {
        /*
         * Method for generating a room object based on a room name as specified in Content/Rooms
         */
        public static void GenerateRoom(string roomName, Game1 game)
        {
            string path = "C:\\Users\\nagle\\Documents\\College\\Classes\\Spring24\\CSE3902\\Sprint3\\CSE3902-Game\\Game\\Content\\Rooms\\" + roomName;
            string[] lines = ParseCsv(path);
            if(lines == null)
            {
                Debug.WriteLine("Error reading filename");
            }
            else
            {
                ParseRoomType(lines[0], game); // Parse and set game.room to room
                ParseDoors(lines[1], game);
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
        private static void ParseRoomType(string line, Game1 game)
        {
            switch (line)
            {
                case "dungeonNormal,,,,,,,,,,,":
                    Debug.WriteLine("Room Created");
                    game.Room =  new Room(
                        SpriteFactory.CreateRoomOuterBorderSprite(),
                        SpriteFactory.CreateRoomInnerBorderSprite(),
                        SpriteFactory.CreateDungeonTilesSprite(),
                        game
                        );
                    break;
                case "undergroundRoom,,,,,,,,,,,":
                    game.Room = new Room(
                        SpriteFactory.CreateEmptyRoomSprite(),
                        SpriteFactory.CreateEmptyRoomSprite(),
                        SpriteFactory.CreateUndergroundRoomSprite(),
                        game
                        );
                    break;
                case "dungeonOldMan,,,,,,,,,,,":
                    game.Room = new Room(
                        SpriteFactory.CreateRoomOuterBorderSprite(),
                        SpriteFactory.CreateRoomInnerBorderSprite(),
                        SpriteFactory.CreateEmptyRoomSprite(),
                        game
                        );
                    break;
            }
        }

        /* 
         * Method for setting the doors of the room based on csv
         */
        private static void ParseDoors(string line, Game1 game)
        {
            // Parse raw csv line into 4 doors names
            string[] doors = line.Split(',');

            // Create each door
            Debug.WriteLine(doors[0]);
            if (!doors[0].Equals("-"))
            {
                game.NorthDoor = new Door(
                    new Vector2(336, 0),
                    SpriteFactory.CreateDoorTopNorthSouth("North", doors[0]),
                    SpriteFactory.CreateDoorBottomNorthSouth("North", doors[0]),
                    "North",
                    game
                );
            }
            else
            {
                game.NorthDoor = new BlankDoor();
            }

            if (!doors[1].Equals("-"))
            {
                game.SouthDoor = new Door(
                new Vector2(336, 480),
                SpriteFactory.CreateDoorTopNorthSouth("South", doors[1]),
                SpriteFactory.CreateDoorBottomNorthSouth("South", doors[1]),
                "South",
                game
                );
            }
            else
            {
                game.SouthDoor = new BlankDoor();
            }

            if (!doors[2].Equals("-"))
            {
                game.EastDoor = new Door(
                new Vector2(0, 216),
                SpriteFactory.CreateDoorTopWestEast("West", doors[2]),
                SpriteFactory.CreateDoorBottomWestEast("West", doors[2]),
                "West",
                game
                );
            }
            else
            {
                game.EastDoor = new BlankDoor();
            }

            if (!doors[3].Equals("-"))
            {
                game.WestDoor = new Door(
                new Vector2(720, 216),
                SpriteFactory.CreateDoorTopWestEast("East", doors[3]),
                SpriteFactory.CreateDoorBottomWestEast("East", doors[3]),
                "East",
                game
                );
            }
            else
            {
                game.WestDoor = new BlankDoor();
            }
        }
    }
}

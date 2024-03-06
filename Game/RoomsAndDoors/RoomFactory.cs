using System;
using System.Diagnostics;
using System.IO;
using System.Reflection.Metadata;
using System.Xml.Linq;
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
        private static void ParseRoomType(string line1, Game1 game)
        {
            switch (line1)
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
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MainGame.Rooms;

namespace MainGame.RNG
{
    public static class RandomRoomGeneration
    {
        private static Random Random = new(2001);
        private static int KeyCount = 0;

        public static void GenerateAdvanceRooms(string[][] DungeonLayout, string DungeonFile, int RoomNumber, int DungeonSize)
        {
            int setsGenerated = 0;
            while (setsGenerated < 5) 
            {
                List<Vector2> advanceLocations = FindRoom("A", DungeonSize, DungeonLayout);
                foreach (Vector2 location in advanceLocations) // Should only be one in here
                {
                    char charDir = DungeonLayout[(int)location.Y][(int)location.X][1];
                    List<Direction> validRooms = CheckAdjacentRooms(location, DungeonLayout);
                    if (validRooms.Count == 0)
                    {
                        DungeonLayout[(int)location.Y][(int)location.X] = "T" + charDir;
                        return;
                    }

                    int generateSideRoom = Random.Next(0, 3);
                    Direction previousRoom = Utils.CharToDirection(charDir);

                    Direction nextAdvance = validRooms[Random.Next(0, validRooms.Count)];
                    validRooms.Remove(nextAdvance);
                    Direction nextSide = previousRoom;
                    if (validRooms.Count != 0)
                    {
                        nextSide = validRooms[Random.Next(0, validRooms.Count)];
                        SetRoom(nextSide, location, "S", DungeonLayout);
                    }

                    SetRoom(nextAdvance, location, "A", DungeonLayout);

                    // Dumb
                    if (setsGenerated == 4) SetRoom(nextAdvance, location, "T", DungeonLayout);

                    WriteAdvanceRoom(previousRoom, nextAdvance, nextSide, RoomNumber);
                    DungeonLayout[(int)location.Y][(int)location.X] = RoomNumber.ToString();
                    RoomNumber++;



                }
                setsGenerated++;
            }
        }
        public static void GenerateSideRooms(string[][] DungeonLayout, string DungeonFile, int RoomNumber, int DungeonSize)
                {
                List<Vector2> sideLocations = FindRoom("S", DungeonSize, DungeonLayout);
                foreach (Vector2 location in sideLocations)
                {
                    char charDir = DungeonLayout[(int)location.Y][(int)location.X][1];
                    /*List<Direction> validRooms = CheckAdjacentRooms(location);
                    if (validRooms.Count == 0)
                    {
                        // TO DO
                        return;
                    } */

                    Direction previousRoom = Utils.CharToDirection(charDir);

                    WriteSideRoom(previousRoom, RoomNumber);
                    DungeonLayout[(int)location.Y][(int)location.X] = RoomNumber.ToString();
                    RoomNumber++;
                }
        }
        private static void GenerateBossRoom()
        {
            // TO DO
        }
        public static void GenerateTriforceRoom(string[][] DungeonLayout, string DungeonFile, int RoomNumber, int DungeonSize)
                {
            List<Vector2> triforceLocations = FindRoom("T", DungeonSize, DungeonLayout);
            foreach (Vector2 location in triforceLocations)
            {
                char charDir = DungeonLayout[(int)location.Y][(int)location.X][1];

                Direction previousRoom = Utils.CharToDirection(charDir);

                WriteTriforceRoom(previousRoom, RoomNumber);
                DungeonLayout[(int)location.Y][(int)location.X] = RoomNumber.ToString();
                RoomNumber++;
            }
        }
        private static void SetRoom(Direction newRoom, Vector2 currentRoom, string roomType, string[][] DungeonLayout)
        {
            if (newRoom == Direction.North) 
            {
                DungeonLayout[(int)currentRoom.Y - 1][(int)currentRoom.X] = roomType + "S";
            } 
            else if (newRoom == Direction.South) 
            {
                DungeonLayout[(int)currentRoom.Y + 1][(int)currentRoom.X] = roomType + "N";
            }
            else if (newRoom == Direction.West)
            {
                DungeonLayout[(int)currentRoom.Y][(int)currentRoom.X - 1] = roomType + "E";
            } else
            {
                DungeonLayout[(int)currentRoom.Y][(int)currentRoom.X + 1] = roomType + "W";
            }
        }
        private static List<Direction> CheckAdjacentRooms(Vector2 location, string[][] DungeonLayout)
        {
            List<Direction> validRooms = new();
            if (location.Y != 0 && DungeonLayout[(int)location.Y - 1][(int)location.X] == "0")
            {
                validRooms.Add(Direction.North);
            }
            if (location.Y != 7 && DungeonLayout[(int)location.Y + 1][(int)location.X] == "0")
            {
                validRooms.Add(Direction.South);
            }
            if (location.X != 0 && DungeonLayout[(int)location.Y][(int)location.X - 1] == "0")
            {
                validRooms.Add(Direction.West);
            }
            if (location.X != 7 && DungeonLayout[(int)location.Y][(int)location.X + 1] == "0")
            {
                validRooms.Add(Direction.East);
            }
            return validRooms;
        }
        private static List<Vector2> FindRoom(string roomTypeChar, int DungeonSize, string[][] DungeonLayout)
        {
            List<Vector2> locations = new();
            for (int i = 0; i < DungeonSize; i++)
            {
                for (int j = 0; j < DungeonSize; ++j)
                {
                    if (DungeonLayout[i][j].StartsWith(roomTypeChar)) locations.Add(new Vector2(j, i));
                }
            }
            return locations;
        }
        public static void GenerateAndWriteSpawnRoom(int pos, string[][] DungeonLayout, string DungeonFile, int RoomNumber, int DungeonSize)
        {
            using (StreamWriter writer = new StreamWriter("Content/Rooms/Room_1.csv"))
            {
                writer.WriteLine("dungeonNormal,,,,,,,,,,,");
                string doors = "keyDoor,openDoor,openDoor,openDoor,,,,,,,,";
                if (pos == 0)
                {
                    doors = "openDoor,openDoor,wallNormal,openDoor,,,,,,,,";
                    int r = Random.Next(0, 1);
                    DungeonLayout[6][pos] = r == 1 ? "AS" : "SS";
                    DungeonLayout[7][pos + 1] = r == 1 ? "SW" : "AW";
                    KeyCount = 1;
                }
                else if (pos == 7)
                {
                    doors = "openDoor,openDoor,openDoor,wallNormal,,,,,,,,";
                    int r = Random.Next(0, 1);
                    DungeonLayout[6][pos] = r == 1 ? "AS" : "SS";
                    DungeonLayout[7][pos - 1] = r == 1 ? "SE" : "AE";
                    KeyCount = 1;
                }
                else
                {
                    DungeonLayout[6][pos] = "AS";
                    DungeonLayout[7][pos + 1] = "SW";
                    DungeonLayout[7][pos - 1] = "SE";
                    KeyCount = 2;
                }
                writer.WriteLine(doors);
                writer.WriteLine("-,-,-,-,-,-,-,-,-,-,-,-");
                writer.WriteLine("-,statueOneEntrance ,-,-,statueOneEntrance ,-,-,statueTwoEntrance ,-,-,statueTwoEntrance ,-");
                writer.WriteLine("-,-,-,-,-,-,-,-,-,-,-,-");
                writer.WriteLine("-,statueOneEntrance ,-,-,statueOneEntrance ,-,-,statueTwoEntrance ,-,-,statueTwoEntrance ,-");
                writer.WriteLine("-,-,-,-,-,blueSand,blueSand,-,-,-,-,-");
                writer.WriteLine("-,statueOneEntrance ,-,blueSand,statueOneEntrance ,blueSand,blueSand,statueTwoEntrance ,blueSand,-,statueTwoEntrance ,-");
                writer.WriteLine("-,-,-,blueSand,blueSand,blueSand,blueSand,blueSand,blueSand,-,-,-");
            }
        }
        private static void WriteAdvanceRoom(Direction previousRoom, Direction nextAdvance, Direction nextSide, int RoomNumber)
        {
            using (StreamWriter writer = new StreamWriter($"Content/Rooms/Room_{RoomNumber}.csv"))
            {
                writer.WriteLine("dungeonNormal,,,,,,,,,,,");
                if (previousRoom == Direction.North || nextSide == Direction.North)
                {
                    writer.Write("openDoor,");
                } else if (nextAdvance == Direction.North) 
                {
                    writer.Write("keyDoor,");
                }
                else 
                {
                    writer.Write("wallNormal,");
                }
                if (previousRoom == Direction.South || nextSide == Direction.South)
                {
                    writer.Write("openDoor,");
                }
                else if (nextAdvance == Direction.South)
                {
                    writer.Write("keyDoor,");
                }
                else
                {
                    writer.Write("wallNormal,");
                }
                if (previousRoom == Direction.West || nextSide == Direction.West)
                {
                    writer.Write("openDoor,");
                }
                else if (nextAdvance == Direction.West)
                {
                    writer.Write("keyDoor,");
                }
                else
                {
                    writer.Write("wallNormal,");
                }
                if (previousRoom == Direction.East || nextSide == Direction.East)
                {
                    writer.Write("openDoor,,,,,,,,");
                }
                else if (nextAdvance == Direction.East)
                {
                    writer.Write("keyDoor,,,,,,,,");
                }
                else
                {
                    writer.Write("wallNormal,,,,,,,,");
                }
                writer.WriteLine("-,-,-,-,-,-,-,-,-,-,-,-");
                writer.WriteLine("-,keese,-,-,-,-,-,-,-,-,-,-"); 
                writer.WriteLine("-,-,-,keese,-,-,-,-,-,-,-,-");
                writer.WriteLine("-,-,-,-,-,-,-,-,-,-,-,-"); 
                writer.WriteLine("-,-,-,-,-,-,-,-,-,-,-,-");
                writer.WriteLine("-,keese,-,-,-,-,-,-,-,-,-,-");
                writer.WriteLine("-,-,-,-,-,-,-,-,key,-,-,-");
            }
        }
        private static void WriteSideRoom(Direction previousRoom, int RoomNumber)
        {
            using (StreamWriter writer = new StreamWriter($"Content/Rooms/Room_{RoomNumber}.csv"))
            {
                writer.WriteLine("dungeonNormal,,,,,,,,,,,");
                if (previousRoom == Direction.North)
                {
                    writer.Write("openDoor,");
                }
                else
                {
                    writer.Write("wallNormal,");
                }
                if (previousRoom == Direction.South)
                {
                    writer.Write("openDoor,");
                }
                else
                {
                    writer.Write("wallNormal,");
                }
                if (previousRoom == Direction.West)
                {
                    writer.Write("openDoor,");
                }
                else
                {
                    writer.Write("wallNormal,");
                }
                if (previousRoom == Direction.East)
                {
                    writer.Write("openDoor,,,,,,,,");
                }
                else
                {
                    writer.Write("wallNormal,,,,,,,,");
                }
                writer.WriteLine("-,-,-,-,-,-,-,-,-,-,-,-");
                writer.WriteLine("-,keese,-,-,-,-,-,-,-,-,-,-");
                writer.WriteLine("-,-,-,keese,-,-,-,-,-,-,-,-");
                writer.WriteLine("-,-,-,-,-,-,-,-,-,-,-,-");
                writer.WriteLine("-,-,-,-,-,-,-,-,-,-,-,-");
                writer.WriteLine("-,keese,-,-,-,-,-,-,-,-,-,-");
                writer.WriteLine("-,-,-,-,-,-,-,-,key,-,-,-");
            }
        }
        private static void WriteBossRoom()
        {
            // TO DO
        }
        private static void WriteTriforceRoom(Direction previousRoom, int RoomNumber)
        {
            using (StreamWriter writer = new StreamWriter($"Content/Rooms/Room_{RoomNumber}.csv"))
            {
                writer.WriteLine("dungeonNormal,,,,,,,,,,,");
                if (previousRoom == Direction.North)
                {
                    writer.Write("openDoor,");
                }
                else
                {
                    writer.Write("wallNormal,");
                }
                if (previousRoom == Direction.South)
                {
                    writer.Write("openDoor,");
                }
                else
                {
                    writer.Write("wallNormal,");
                }
                if (previousRoom == Direction.West)
                {
                    writer.Write("openDoor,");
                }
                else
                {
                    writer.Write("wallNormal,");
                }
                if (previousRoom == Direction.East)
                {
                    writer.Write("openDoor,,,,,,,,");
                }
                else
                {
                    writer.Write("wallNormal,,,,,,,,");
                }
                writer.WriteLine("\n-,-,-,-,-,-,-,-,-,-,-,-");
                writer.WriteLine("-,squareBlock,squareBlock,squareBlock,squareBlock,squareBlock,squareBlock,squareBlock,squareBlock,squareBlock,squareBlock,-");
                writer.WriteLine("-,squareBlock,-,-,statueOneEnd,-,-,statueTwoEnd,-,-,squareBlock,-");
                writer.WriteLine("-,squareBlock,-,statueOneEnd,-,-,-,-,statueTwoEnd,-,squareBlock,-");
                writer.WriteLine("-,squareBlock,-,-,-,-,-,-,-,-,squareBlock,-");
                writer.WriteLine("-,squareBlock,squareBlock,squareBlock,squareBlock,-,-,squareBlock,squareBlock,squareBlock,squareBlock,-");
                writer.WriteLine("-,-,-,-,-,-,-,-,-,-,-,-");
            }
        }
    }
}

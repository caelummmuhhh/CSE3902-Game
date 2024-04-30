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
using MainGame.Enemies;
using System.ComponentModel.Design;

namespace MainGame.RNG
{
    public static class RandomGeneration
    {
        private static Game1 Game; // Might not need
        private static readonly int DungeonSize = 8;
        private static Random Random = new();
        private static string[][] DungeonLayout;
        private static string DungeonFile;
        private static int RoomNumber = 1;
        public static void GenerateDungeon(Game1 game, string baseFile, string generatedFile)
        {
            Game = game;
            DungeonFile = generatedFile;
            string dungeonBase = File.ReadAllText(baseFile);
            File.WriteAllText(generatedFile, dungeonBase);

            DungeonLayout = new string[DungeonSize][];
            for (int i = 0; i < DungeonSize; i++)
            {
                DungeonLayout[i] = new string[DungeonSize];
                for (int j = 0; j < DungeonSize; ++j)
                {
                    // Initialize Dungeon
                    DungeonLayout[i][j] = "0";
                }
            }
            int r = Random.Next(0, 7);
            DungeonLayout[7][r] = "1"; // Set Spawn Room
            RoomNumber++;
            GenerateAndWriteSpawnRoom(r);
            GenerateAdvanceRooms();
            GenerateSideRooms();
            GenerateTriforceRoom();
            PrintDungeonToFile();
            
        }
        private static void GenerateAdvanceRooms()
        {
            int setsGenerated = 0;
            while (setsGenerated < 5) 
            {
                List<Vector2> advanceLocations = FindRoom("A");
                foreach (Vector2 location in advanceLocations) // Should only be one in here
                {
                    char charDir = DungeonLayout[(int)location.Y][(int)location.X][1];
                    List<Direction> validRooms = CheckAdjacentRooms(location);
                    if (validRooms.Count == 0)
                    {
                        DungeonLayout[(int)location.Y][(int)location.X] = "T" + charDir;
                        return;
                    }

                    Direction previousRoom = Utils.CharToDirection(charDir);

                    Direction nextAdvance = validRooms[Random.Next(0, validRooms.Count)];
                    validRooms.Remove(nextAdvance);
                    Direction nextSide = previousRoom;
                    if (validRooms.Count != 0)
                    {
                        nextSide = validRooms[Random.Next(0, validRooms.Count)];
                        SetRoom(nextSide, location, "S");
                    }

                    SetRoom(nextAdvance, location, "A");

                    // This feels dumb like it should be outside the while loop but the variables go away so idk
                    if (setsGenerated == 4) SetRoom(nextAdvance, location, "T");

                    WriteAdvanceRoom(previousRoom, nextAdvance, nextSide);
                    DungeonLayout[(int)location.Y][(int)location.X] = RoomNumber.ToString();
                    RoomNumber++;



                }
                setsGenerated++;
            }
        }
        private static void GenerateSideRooms()
        {
                List<Vector2> sideLocations = FindRoom("S");
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

                    WriteSideRoom(previousRoom);
                    DungeonLayout[(int)location.Y][(int)location.X] = RoomNumber.ToString();
                    RoomNumber++;
                }
        }
        private static void GenerateBossRoom()
        {
            // TO DO
        }
        private static void GenerateTriforceRoom()
        {
            List<Vector2> triforceLocations = FindRoom("T");
            foreach (Vector2 location in triforceLocations)
            {
                char charDir = DungeonLayout[(int)location.Y][(int)location.X][1];

                Direction previousRoom = Utils.CharToDirection(charDir);

                WriteTriforceRoom(previousRoom);
                DungeonLayout[(int)location.Y][(int)location.X] = RoomNumber.ToString();
                RoomNumber++;
            }
        }
        private static void SetRoom(Direction newRoom, Vector2 currentRoom, string roomType)
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
        private static List<Direction> CheckAdjacentRooms(Vector2 location)
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
        private static List<Vector2> FindRoom(string roomTypeChar)
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
        private static void PrintDungeonToFile()
        {
            using (StreamWriter writer = new StreamWriter(DungeonFile, true))
            {
                writer.Write('\n');
                for (int i = 0; i < DungeonSize; i++)
                {
                    for (int j = 0; j < DungeonSize; ++j)
                    {
                        writer.Write(DungeonLayout[i][j]);
                        if (j < DungeonSize - 1) writer.Write(",");
                    }
                    writer.Write('\n');
                }
                writer.Write('\n');
            }
        }
        private static void GenerateAndWriteSpawnRoom(int pos)
        {
            using (StreamWriter writer = new StreamWriter("Content/RandomRooms/Room_1.csv"))
            {
                writer.WriteLine("dungeonNormal,,,,,,,,,,,");
                string doors = "keyDoor,openDoor,openDoor,openDoor,,,,,,,,";
                if (pos == 0)
                {
                    doors = "openDoor,openDoor,wallNormal,openDoor,,,,,,,,";
                    int r = Random.Next(0, 1);
                    DungeonLayout[6][pos] = r == 1 ? "AS" : "SS";
                    DungeonLayout[7][pos + 1] = r == 1 ? "SW" : "AW";
                }
                else if (pos == 7)
                {
                    doors = "openDoor,openDoor,openDoor,wallNormal,,,,,,,,";
                    int r = Random.Next(0, 1);
                    DungeonLayout[6][pos] = r == 1 ? "AS" : "SS";
                    DungeonLayout[7][pos - 1] = r == 1 ? "SE" : "AE";
                }
                else
                {
                    DungeonLayout[6][pos] = "AS";
                    DungeonLayout[7][pos + 1] = "SW";
                    DungeonLayout[7][pos - 1] = "SE";
                }
                writer.WriteLine(doors);
                writer.WriteLine("-,-,-,-,-,-,-,-,-,-,-,-");
                writer.WriteLine("-,statueOneEntrance ,-,-,statueOneEntrance ,-,-,statueTwoEntrance ,-,-,statueTwoEntrance ,-");
                writer.WriteLine("-,-,-,-,-,-,-,-,-,-,-,-");
                writer.WriteLine("-,statueOneEntrance ,-,-,statueOneEntrance ,-,-,statueTwoEntrance ,-,-,statueTwoEntrance ,-");
                writer.WriteLine("-,-,-,-,-,blueSand,blueSand,-,-,-,-,-");
                writer.WriteLine("-,statueOneEntrance ,-,blueSand,statueOneEntrance ,blueSand,blueSand,statueTwoEntrance ,blueSand,-,statueTwoEntrance ,-");
                writer.WriteLine("-,-,-,blueSand,blueSand,blueSand,blueSand,blueSand,blueSand,-,-,-");
                writer.Write("Unlocked,,,,,,,,,,,");
            }
        }
        private static void WriteAdvanceRoom(Direction previousRoom, Direction nextAdvance, Direction nextSide)
        {
            using (StreamWriter writer = new StreamWriter($"Content/RandomRooms/Room_{RoomNumber}.csv"))
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
          
                string enemyType1 = Enum.GetName(typeof(EnemyTypes) ,EnemyUtils.GetRandomEnemy());
                string enemyType2 = Enum.GetName(typeof(EnemyTypes), EnemyUtils.GetRandomEnemy());
                writer.WriteLine($"\n-,-,-,-,-,-,-,-,-,-,-,-");
                for (int i = 0; i < 5; i++)
                {
                    writer.Write("-,");
                    for (int j = 0; j < 10; j++)
                    {
                        if (Random.Next(0, 20) == 0)
                        {
                            writer.Write(enemyType1 + ",");
                        } 
                        else if (Random.Next(0, 20) == 0)
                        {
                            writer.Write(enemyType2 + ",");
                        }
                        else if (Random.Next(0, 5) == 0)
                        {
                            writer.Write("squareBlock,");
                        }
                        else
                        {
                            writer.Write("-,");
                        } 
                    }
                    writer.Write("-\n");
                }
                writer.WriteLine($"-,-,-,-,-,-,-,-,-,-,-,-");
                writer.Write("Unlocked,,,,,,,,,,,");
            }
        }
        private static void WriteSideRoom(Direction previousRoom)
        {
            using (StreamWriter writer = new StreamWriter($"Content/RandomRooms/Room_{RoomNumber}.csv"))
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

                string enemyType1 = Enum.GetName(typeof(EnemyTypes), EnemyUtils.GetRandomEnemy());
                string enemyType2 = Enum.GetName(typeof(EnemyTypes), EnemyUtils.GetRandomEnemy());
                string itemType = Enum.GetName(typeof(ItemTypes), Utils.GetRandomCollectableItem());
                writer.WriteLine($"\n-,-,{itemType},-,-,-,-,-,-,-,-,-");
                for (int i = 0; i < 5; i++)
                {
                    writer.Write("-,");
                    for (int j = 0; j < 10; j++)
                    {
                        if (Random.Next(0, 25) == 0)
                        {
                            writer.Write(enemyType1 + ",");
                        }
                        else if (Random.Next(0, 25) == 0)
                        {
                            writer.Write(enemyType2 + ",");
                        }
                        else if (Random.Next(0, 4) == 0)
                        {
                            writer.Write("squareBlock,");
                        }
                        else if (Random.Next(0, 25) == 0)
                        {
                            writer.Write("heart,");
                        }
                        else
                        {
                            writer.Write("-,");
                        }
                    }
                    writer.Write("-\n");
                }
                writer.WriteLine($"-,-,-,-,-,-,-,-,-,key,-,-");
                if (enemyType1 == "OldMan" || enemyType1 == "SpikeCross" || enemyType2 == "OldMan" || enemyType2 == "SpikeCross")
                {
                    writer.Write("Unlocked,,,,,,,,,,,");
                }
                else
                {
                    writer.Write("Locked,,,,,,,,,,,");
                }
            }
        }
        private static void WriteBossRoom()
        {
            // TO DO
        }
        private static void WriteTriforceRoom(Direction previousRoom)
        {
            using (StreamWriter writer = new StreamWriter($"Content/RandomRooms/Room_{RoomNumber}.csv"))
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
                writer.WriteLine("-,squareBlock,fairy,fairy,statueOneEnd,fairy,fairy,statueTwoEnd,fairy,fairy,squareBlock,-");
                writer.WriteLine("-,squareBlock,fairy,statueOneEnd,fairy,fairy,fairy,fairy,statueTwoEnd,-,squareBlock,-");
                writer.WriteLine("-,squareBlock,-,-,-,-,-,-,-,-,squareBlock,-");
                writer.WriteLine("-,squareBlock,squareBlock,squareBlock,squareBlock,-,-,squareBlock,squareBlock,squareBlock,squareBlock,-");
                writer.WriteLine("-,-,-,-,-,-,-,-,-,-,-,-");
                writer.Write("Unlocked,,,,,,,,,,,");
            }
        }
    }
}

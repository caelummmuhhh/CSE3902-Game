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

namespace MainGame.RNG
{
    public static class RandomDungeonGeneration
    {
        private static Game1 Game; // Might not need
        private static readonly int DungeonSize = 8;
        private static Random Random = new(2001);
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
            RandomRoomGeneration.GenerateAndWriteSpawnRoom(r, DungeonLayout, DungeonFile, RoomNumber, DungeonSize);
            RandomRoomGeneration.GenerateAdvanceRooms(DungeonLayout, DungeonFile, RoomNumber, DungeonSize);
            RandomRoomGeneration.GenerateSideRooms(DungeonLayout, DungeonFile, RoomNumber, DungeonSize);
            RandomRoomGeneration.GenerateTriforceRoom(DungeonLayout, DungeonFile, RoomNumber, DungeonSize);
            PrintDungeonToFile();
            
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
    }
}

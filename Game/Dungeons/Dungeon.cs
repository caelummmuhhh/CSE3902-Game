using System.IO;
using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;

namespace MainGame.Dungeons
{
    public class Dungeon : IDungeon
    {
        public string DungeonId { get; set; }
        public string UseItemKey { get; set; }
        public string AttackKey { get; set; }
        public int PlayerStartingHealth { get; set; }
        public int PlayerStartingRupees { get; set; }
        public int PlayerStartingKeys { get; set; }
        public int PlayerStartingBombs { get; set; }
        public string[] PlayerStartingItems { get; set; }

        public int[][] DungeonLayout { get; set; }
        public int UnderGroundRoom { get; set; }
        public int DungeonRoomCount { get; set; }
        public Vector2 TriforceRoomLocation { get; set; }
        public Vector2 SpawnRoomLocation { get; set; }

        public readonly int DungeonSize = 8;

        private Game1 game;
        private string[] Lines;

        public Dungeon(Game1 game, string dungeonFIle)
        {
            this.game = game;
            DungeonLayout = new int[DungeonSize][];
            for (int i = 0; i < DungeonSize; i++)
            {
                DungeonLayout[i] = new int[DungeonSize];
            }

            LoadDungeon(dungeonFIle);
            ParseDungeon();
            DungeonRoomCount = SizeDungeon();
            SetLocations();

        }
        private void SetLocations()
        {
            for (int i = 0; i < DungeonSize; i++)
            {
                for (int j = 0; j < DungeonSize; j++)
                {
                    if (DungeonLayout[i][j] == DungeonRoomCount)
                    {
                        TriforceRoomLocation = new Vector2(j, i);
                    } else if (DungeonLayout[i][j] == 1)
                    {
                        SpawnRoomLocation = new Vector2(j, i);
                    }
                }
            }
        }
        private void LoadDungeon(string dungeonFile)
        {
            string[] dungeonFiles = Directory.GetFiles(Path.Combine("Content", "Dungeons"), dungeonFile);

            string fullPath = Path.GetFullPath(dungeonFiles[0]);
            if (File.Exists(fullPath))
            {
                this.Lines = File.ReadAllLines(fullPath);
            }
            else
            {
                throw new IOException($"Could not read CSV file for dungeon: {dungeonFiles[0]}");
            }
        }
        private int SizeDungeon()
        {
            int size = 0;
            for (int i = 0; i < DungeonSize; ++i)
            {
                for (int j = 0; j < DungeonSize; ++j)
                {
                    if (DungeonLayout[i][j] > size) { size = DungeonLayout[i][j]; }
                }
            }
            return size;
        }
        private void ParseDungeon()
        {
            string[] version = Lines[0].Split(',');
            DungeonId = version[0];
            UseItemKey = version[1];
            AttackKey = version[2];

            string[] playerValues = Lines[1].Split(',');
            PlayerStartingHealth = int.Parse(playerValues[0]);
            PlayerStartingRupees = int.Parse(playerValues[1]);
            PlayerStartingKeys = int.Parse(playerValues[2]);
            PlayerStartingBombs = int.Parse(playerValues[3]);

            PlayerStartingItems = Lines[2].Split(',');

            string[][] dungeonLayout = new string[DungeonSize][];

            for (int i = 0; i < DungeonSize; ++i)
            {
                dungeonLayout[i] = Lines[3 + i].Split(",");
                for (int j = 0; j < DungeonSize; ++j)
                {
                    DungeonLayout[i][j] = int.Parse(dungeonLayout[i][j]);
                } 

            }

            UnderGroundRoom = int.Parse(Lines[11].Split(",")[0]);

        }
        public void Update()
        {

        }

        public void Draw()
        {
            
        }
    }
}
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using MainGame.Audio;
using MainGame.Players;

namespace MainGame.Rooms
{
	public class GameRoomManager
	{
		public IRoom CurrentRoom { get; set; }
		public List<IRoom> AllRooms { get => allRooms; }

		// Can only change to true
        public bool PlayerHasCompass { get => hasCompass; set => hasCompass = hasCompass || value; }
        public bool PlayerHasMap { get => hasMap; set => hasMap = hasMap || value; }

        private readonly List<IRoom> allRooms = new();

		public Vector2 currentRoomIndex;
		private readonly Game1 game;
		private int roomChangeDebounce = 20;

		private bool hasMap = false;
		private bool hasCompass = false;

		public GameRoomManager(Game1 game)
		{
			this.game = game;
        }

		public void LoadAllRooms(IPlayer player)
		{
			for (int i = 0; i < game.Dungeon.DungeonRoomCount + 1; i++)
			{
				string filePath = Path.Combine("Content", "Rooms", $"Room_{i}.csv");
                allRooms.Add(RoomFactory.GenerateRoom(filePath, player, this));
            }

			currentRoomIndex = game.Dungeon.SpawnRoomLocation;
            CurrentRoom = allRooms[game.Dungeon.DungeonLayout[(int)currentRoomIndex.Y][(int)currentRoomIndex.X]];
        }

		public void Update()
		{
			CurrentRoom.Update();
			roomChangeDebounce--;

		}

		public void Draw()
		{
			CurrentRoom.Draw();
		}

		public void NextRoom(Direction direction)
		{
			if (roomChangeDebounce > 0)
			{
				return;
			}
			roomChangeDebounce = 20;

			if (direction == Direction.North)
			{
				currentRoomIndex.Y = currentRoomIndex.Y - 1 < 0 ? 0 : currentRoomIndex.Y - 1;
            } 
			else if (direction == Direction.South)
			{
                currentRoomIndex.Y = currentRoomIndex.Y + 1 >= game.Dungeon.DungeonSize - 1 ? game.Dungeon.DungeonSize - 1 : currentRoomIndex.Y + 1;
            }
            else if (direction == Direction.West)
            {
                currentRoomIndex.X = currentRoomIndex.X - 1 < 0 ? 0 : currentRoomIndex.X - 1;
            }
            else if (direction == Direction.East)
            {
                currentRoomIndex.X = currentRoomIndex.X + 1 >= game.Dungeon.DungeonSize - 1 ? game.Dungeon.DungeonSize - 1 : currentRoomIndex.X + 1;
            }
            CurrentRoom = allRooms[game.Dungeon.DungeonLayout[(int)currentRoomIndex.Y][(int)currentRoomIndex.X]];

        }
    }
}


using System.Collections.Generic;
using System.IO;
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

		private int currentRoomIndex = 0; // TODO: delete, this is for testing only
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
			string[] roomFiles = Directory.GetFiles(Path.Combine("Content", "Rooms"), "*.csv");

            foreach (string roomFile in roomFiles)
            {
				allRooms.Add(RoomFactory.GenerateRoom(roomFile, player, this));
			}
			CurrentRoom = allRooms[currentRoomIndex]; // TODO: Delete
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

		public void NextRoom()
		{
			if (roomChangeDebounce > 0)
			{
				return;
			}
			roomChangeDebounce = 20;
			currentRoomIndex = (currentRoomIndex + 1) % allRooms.Count;
			CurrentRoom = allRooms[currentRoomIndex];
        }
    }
}


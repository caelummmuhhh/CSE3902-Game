using System.Collections.Generic;
using System.IO;
using MainGame.Players;

namespace MainGame.Rooms
{
	public class GameRoomManager
	{
		public IRoom CurrentRoom { get; set; }
		public List<IRoom> AllRooms { get => allRooms; }

		private readonly List<IRoom> allRooms = new();

		private int currentRoomIndex = 0; // TODO: delete, this is for testing only
		private readonly Game1 game; // TODO: we might not even need this tbh
		private int roomChangeDebounce = 20;

		public GameRoomManager(Game1 game)
		{
			this.game = game;
        }

		public void LoadAllRooms(IPlayer player)
		{
			string[] roomFiles = Directory.GetFiles(Path.Combine("Content", "Rooms"), "*.csv");

			foreach (string roomFile in roomFiles)
			{
				allRooms.Add(RoomFactory.GenerateRoom(roomFile, player));
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


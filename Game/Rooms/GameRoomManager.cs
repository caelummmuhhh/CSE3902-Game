using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using MainGame.Players;

namespace MainGame.Rooms
{
	public class GameRoomManager
	{
		public IRoom CurrentRoom { get; set; }
		public List<IRoom> AllRooms { get => AllRooms; }

		private readonly List<IRoom> allRooms = new();

		private int roomChangeDebounce = 20;
		private int startingRoom = 0;

		public GameRoomManager(Game1 game)
		{
			LoadAllRooms(game.Player);
			CurrentRoom = allRooms[startingRoom];
        }

		private void LoadAllRooms(IPlayer player)
		{
			string[] roomFiles = Directory.GetFiles(Path.Combine("Content", "Rooms"), "*.csv");

			foreach (string roomFile in roomFiles)
			{
				Debug.WriteLine(roomFile);
				allRooms.Add(RoomFactory.GenerateRoom(roomFile, player));
			}
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

		public void GetNorthRoom()
		{
            NextRoom(CurrentRoom.ConnectingRooms[0]);
        }

        public void GetSouthRoom()
        {
            NextRoom(CurrentRoom.ConnectingRooms[1]);
        }

        public void GetEastRoom()
        {
            NextRoom(CurrentRoom.ConnectingRooms[2]);
        }

        public void GetWestRoom()
        {
			NextRoom(CurrentRoom.ConnectingRooms[3]);
        }

        public void NextRoom(int RoomNumber)
		{
			// RoomNumber == -1 means room does not exist
			if (roomChangeDebounce > 0 || RoomNumber == -1)
			{
				return;
			}
			roomChangeDebounce = 20;
			CurrentRoom = allRooms[RoomNumber];
        }
    }
}


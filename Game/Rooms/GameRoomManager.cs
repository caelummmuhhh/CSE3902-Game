using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using MainGame.Players;
using Microsoft.Xna.Framework;

namespace MainGame.Rooms
{
	public class GameRoomManager
	{
		public IRoom CurrentRoom { get; set; }
		public IRoom SwitchingRoom { get; set; }

		public List<IRoom> AllRooms { get => AllRooms; }

		private readonly List<IRoom> allRooms = new();

		private bool roomChangeDebounce = true;

		public GameRoomManager(Game1 game)
		{
			LoadAllRooms(game.Player);
			CurrentRoom = allRooms[0];
        }

		private void LoadAllRooms(IPlayer player)
		{
			string[] roomFiles = Directory.GetFiles(Path.Combine("Content", "Rooms"), "*.csv");

			foreach (string roomFile in roomFiles)
			{
				allRooms.Add(RoomFactory.GenerateRoom(roomFile, player));
			}
        }

		public void Update()
		{
			CurrentRoom.Update();
			CurrentRoom.Position += new Vector2(1, 0);
			// Code for scrolling rooms
			if(SwitchingRoom != null)
			{
				roomChangeDebounce = false;

                SwitchingRoom.Position += new Vector2(1f, 0);
				CurrentRoom.Position += new Vector2(-1f, 0);
                if (SwitchingRoom.Position.X == 0 && SwitchingRoom.Position.Y == 0)
                {
                    CurrentRoom = SwitchingRoom;
                    SwitchingRoom = null;
                    roomChangeDebounce = true;
                }
            }
		}

		public void Draw()
		{
			CurrentRoom.Draw();
            if (SwitchingRoom != null)
            {
                SwitchingRoom.Draw();

            }
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
			if (!roomChangeDebounce || RoomNumber == -1)
			{
				return;
			}

			//SwitchingRoom = allRooms[RoomNumber];
			//SwitchingRoom.Position = new Vector2(-500, 0);
        }
    }
}


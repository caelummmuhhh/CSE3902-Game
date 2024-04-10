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

		private float SpeedX { get; set; }
        private float SpeedY { get; set; }
        private float ScrollSpeed;

		public Rectangle gameArea;
		


        public GameRoomManager(Game1 game)
		{
			LoadAllRooms(game.Player);
			CurrentRoom = allRooms[1];
            CurrentRoom.isCurrentRoom = true;
            gameArea = new Rectangle(0, 0, game.GraphicsManager.PreferredBackBufferWidth, game.GraphicsManager.PreferredBackBufferHeight);
            ScrollSpeed = 3;
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
			// Code for scrolling rooms
			if(SwitchingRoom != null)
			{
				SwitchingRoom.Update();
				roomChangeDebounce = false;

                SwitchingRoom.Position += new Vector2(SpeedX, SpeedY);
				CurrentRoom.Position += new Vector2(SpeedX, SpeedY);
                if (SwitchingRoom.Position.X == 0 && SwitchingRoom.Position.Y == 0)
                {
                    CurrentRoom = SwitchingRoom;
                    CurrentRoom.isCurrentRoom = true;
                    SwitchingRoom = null;
                    roomChangeDebounce = true;
                    SpeedX = 0;
                    SpeedY = 0;
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
            // RoomNumber == -1 means room does not exist
            if (!roomChangeDebounce || CurrentRoom.ConnectingRooms[0] == -1)
            {
                return;
            }
            CurrentRoom.isCurrentRoom = false;
            SwitchingRoom = allRooms[CurrentRoom.ConnectingRooms[0]];
            SwitchingRoom.Position = new Vector2(0, gameArea.Top - gameArea.Height);
            SpeedY = ScrollSpeed;
        }

        public void GetSouthRoom()
        {
            // RoomNumber == -1 means room does not exist
            if (!roomChangeDebounce || CurrentRoom.ConnectingRooms[1] == -1)
            {
                return;
            }
            CurrentRoom.isCurrentRoom = false;
            SwitchingRoom = allRooms[CurrentRoom.ConnectingRooms[1]];
            SwitchingRoom.Position = new Vector2(0, gameArea.Bottom);
            SpeedY = -ScrollSpeed;
        }

        public void GetEastRoom()
        {
            // RoomNumber == -1 means room does not exist
            if (!roomChangeDebounce || CurrentRoom.ConnectingRooms[2] == -1)
            {
                return;
            }
            CurrentRoom.isCurrentRoom = false;
            SwitchingRoom = allRooms[CurrentRoom.ConnectingRooms[2]];
            SwitchingRoom.Position = new Vector2(gameArea.Right, 0);
            SpeedX = -ScrollSpeed;
        }

        public void GetWestRoom()
        {
            // RoomNumber == -1 means room does not exist
            if (!roomChangeDebounce || CurrentRoom.ConnectingRooms[3] == -1)
            {
                return;
            }
            CurrentRoom.isCurrentRoom = false;
            SwitchingRoom = allRooms[CurrentRoom.ConnectingRooms[3]];
            SwitchingRoom.Position = new Vector2(gameArea.Left - gameArea.Width, 0);
            SpeedX = ScrollSpeed;        
        }
    }
}


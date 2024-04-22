using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using MainGame.Audio;
using MainGame.Players;
using System;
using System.Diagnostics;

namespace MainGame.Rooms
{
	public class GameRoomManager
	{
		public IRoom CurrentRoom { get; set; }
		public IRoom SecondaryRoom { get; set; } // Used for room switching

		public Vector2 RoomChangingVel { get; set; }

		public List<IRoom> AllRooms { get => allRooms; }

		// Can only change to true
        public bool PlayerHasCompass { get => hasCompass; set => hasCompass = hasCompass || value; }
        public bool PlayerHasMap { get => hasMap; set => hasMap = hasMap || value; }

        private readonly List<IRoom> allRooms = new();

		public Vector2 currentRoomIndex;
		private readonly Game1 game;
		public bool roomChangeDebounce = true;

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
			if (SecondaryRoom != null)
			{
				SecondaryRoom.Update();
				SecondaryRoom.Position += RoomChangingVel; // Apply room changing velocity to secondary room
				CurrentRoom.Position += RoomChangingVel;

                // Check if room switch has been compleate
                float distanceFromStart = Vector2.Distance(SecondaryRoom.Position, new Vector2(0, Constants.HudAndMenuHeight));

                if (distanceFromStart < Constants.RoomScrollingSpeed)
				{
					SwitchingRoomsEnd();
				}
			}
		}

		public void Draw()
		{
			CurrentRoom.Draw();
			if(SecondaryRoom != null) SecondaryRoom.Draw(); 
		}

		public void SwitchRoomsStart(Direction direction)
		{
			roomChangeDebounce = false;
			game.SetPlayer(); // Turn player off for room switching
			CurrentRoom.isMainRoom = false;
			// Initiate the switching room process by setting creating a new room 
            SecondaryRoom = allRooms[game.Dungeon.DungeonLayout[(int)currentRoomIndex.Y][(int)currentRoomIndex.X]];

            // Set original location for seconday room based on direction
            if (direction == Direction.North)
            {
                game.Player.Position = new Vector2(CurrentRoom.SouthDoor.Position.X, CurrentRoom.SouthDoor.Position.Y);
                SecondaryRoom.Position = new Vector2(0, -game.GraphicsManager.PreferredBackBufferHeight+2*Constants.HudAndMenuHeight);
                RoomChangingVel = new Vector2(0, Constants.RoomScrollingSpeed);
            }
            else if (direction == Direction.South)
            {
                game.Player.Position = new Vector2(CurrentRoom.NorthDoor.Position.X, CurrentRoom.NorthDoor.Position.Y);
                SecondaryRoom.Position = new Vector2(0, game.GraphicsManager.PreferredBackBufferHeight);
				RoomChangingVel = new Vector2(0, -Constants.RoomScrollingSpeed);

            }
            else if (direction == Direction.West)
            {
                game.Player.Position = new Vector2(CurrentRoom.WestDoor.Position.X, CurrentRoom.WestDoor.Position.Y);
                SecondaryRoom.Position = new Vector2(-game.GraphicsManager.PreferredBackBufferWidth, Constants.HudAndMenuHeight);
                RoomChangingVel = new Vector2(Constants.RoomScrollingSpeed, 0);
            }
            else if (direction == Direction.East)
            {
                game.Player.Position = new Vector2(CurrentRoom.EastDoor.Position.X, CurrentRoom.EastDoor.Position.Y);
                SecondaryRoom.Position = new Vector2(game.GraphicsManager.PreferredBackBufferWidth, Constants.HudAndMenuHeight);
                RoomChangingVel = new Vector2(-Constants.RoomScrollingSpeed, 0);
            }
            game.Player.Position = new Vector2(game.GraphicsManager.PreferredBackBufferWidth / 2, game.GraphicsManager.PreferredBackBufferHeight / 2);
        }

		public void SwitchingRoomsEnd()
		{
            // Set the new room to current room
            RoomChangingVel = new Vector2(0, 0);
			SecondaryRoom.Position = new Vector2(0, Constants.HudAndMenuHeight);
            CurrentRoom = SecondaryRoom;
			CurrentRoom.isMainRoom = true;
            SecondaryRoom = null;
            SecondaryRoom = null;
            game.SetPlayer(); // Turn player back on
			roomChangeDebounce = true;
        }

		public void NextRoom(Direction direction)
		{
			if (!roomChangeDebounce)
			{
				return;
			}

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

            SwitchRoomsStart(direction);
        }
    }
}


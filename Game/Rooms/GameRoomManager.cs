using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using MainGame.Audio;
using MainGame.Players;
using System;
using System.Diagnostics;
using MainGame.Doors;
using MainGame.Players.PlayerStates;

namespace MainGame.Rooms
{
	public class GameRoomManager
	{
		public IRoom CurrentRoom { get; set; }
		
		// Used for room switching
		public IRoom CurrentGhostRoom { get; set; }
		public IRoom SecondaryGhostRoom { get; set; }

		public Vector2 roomChangeVelo { get; set; }


        public List<IRoom> AllRooms { get => allRooms; }

		// Can only change to true
        public bool PlayerHasCompass { get => hasCompass; set => hasCompass = hasCompass || value; }
        public bool PlayerHasMap { get => hasMap; set => hasMap = hasMap || value; }

        private readonly List<IRoom> allRooms = new();

		public Vector2 currentRoomIndex;
		private readonly Game1 game;
		public bool roomChange = false;
		public int roomChangeDebounce = 0;

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
			if(!roomChange) CurrentRoom.Update();
			else
			{
                CurrentGhostRoom.Update();
				SecondaryGhostRoom.Update();

                CurrentGhostRoom.Position += roomChangeVelo;
				SecondaryGhostRoom.Position += roomChangeVelo;

                float dis = Vector2.Distance(new Vector2(0, Constants.HudAndMenuHeight), SecondaryGhostRoom.Position);

                if (dis < Constants.RoomScrollingSpeed)
				{
                    SwitchingRoomsEnd();
                }   
            }
			roomChangeDebounce--;

        }

		public void Draw()
		{
            if (!roomChange) CurrentRoom.Draw();
            else
            {
                CurrentGhostRoom.Draw();
                SecondaryGhostRoom.Draw();
            }
		}

		public void SwitchRoomsStart(Direction direction)
		{
			/*
			 * The idea behind scrolling rooms is to create two "Ghost" rooms for purly display since nothing really happens during room change
			 * then once the room scroll is compleate then the current room can actually be set to the new room
			 */ 

			roomChange = true; // Start change
			game.SetPlayer(); // Hide player
			// set changing variables based on direction
			Vector2 secondaryGhostRoomStartPos;

			if(direction == Direction.West)
			{
				roomChangeVelo = new Vector2(Constants.RoomScrollingSpeed, 0);
				secondaryGhostRoomStartPos = new Vector2(-game.GraphicsManager.PreferredBackBufferWidth, Constants.HudAndMenuHeight);
            }
            else if (direction == Direction.East)
			{
                roomChangeVelo = new Vector2(-Constants.RoomScrollingSpeed, 0);
                secondaryGhostRoomStartPos = new Vector2(game.GraphicsManager.PreferredBackBufferWidth, Constants.HudAndMenuHeight);
            }
			else if(direction == Direction.North)
			{
                roomChangeVelo = new Vector2(0, Constants.RoomScrollingSpeed);
                secondaryGhostRoomStartPos = new Vector2(0, -game.GraphicsManager.PreferredBackBufferHeight+2*Constants.HudAndMenuHeight);
            }
			else
			{
                roomChangeVelo = new Vector2(0, -Constants.RoomScrollingSpeed);
                secondaryGhostRoomStartPos = new Vector2(0, game.GraphicsManager.PreferredBackBufferHeight);
            }

			// Create ghost rooms for display
			CurrentGhostRoom = createGhostRoom(CurrentRoom);
			SecondaryGhostRoom = createGhostRoom(allRooms[game.Dungeon.DungeonLayout[(int)currentRoomIndex.Y][(int)currentRoomIndex.X]]);
            SecondaryGhostRoom.Position = secondaryGhostRoomStartPos;
        }

		public void SwitchingRoomsEnd()
		{
            roomChange = false; // End change
            game.SetPlayer(); // unhide player
            CurrentRoom = allRooms[game.Dungeon.DungeonLayout[(int)currentRoomIndex.Y][(int)currentRoomIndex.X]];
			roomChangeDebounce = 20;
        }

		public IRoom createGhostRoom(IRoom room)
		{
			IRoom ghost = new Room(room.OuterBorderSprite, room.InnerBorderSprite, room.TilesSprite);
			ghost.NorthDoor = new Door((Door)room.NorthDoor);
            ghost.SouthDoor = new Door((Door)room.SouthDoor);
            ghost.EastDoor = new Door((Door)room.EastDoor);
            ghost.WestDoor = new Door((Door)room.WestDoor);

			ghost.RoomBlocks = room.RoomBlocks;
			ghost.DoorBaseLocations = room.DoorBaseLocations;
			ghost.BlockBaseLocations = room.BlockBaseLocations;

			return ghost;
        }

		public void NextRoom(Direction direction)
		{
			if (roomChange || roomChangeDebounce > 0)
			{
				return;
			}
			roomChangeDebounce = 20;

            if (direction == Direction.North)
			{
				currentRoomIndex.Y = currentRoomIndex.Y - 1 < 0 ? 0 : currentRoomIndex.Y - 1;
                game.Player.Position = new Vector2(120 * Constants.UniversalScale, (128 * Constants.UniversalScale) + Constants.HudAndMenuHeight);
            } 
			else if (direction == Direction.South)
			{
                currentRoomIndex.Y = currentRoomIndex.Y + 1 >= game.Dungeon.DungeonSize - 1 ? game.Dungeon.DungeonSize - 1 : currentRoomIndex.Y + 1;
                game.Player.Position = new Vector2(120 * Constants.UniversalScale, Constants.HudAndMenuHeight + 16 * Constants.UniversalScale);
            }
            else if (direction == Direction.West)
            {
                currentRoomIndex.X = currentRoomIndex.X - 1 < 0 ? 0 : currentRoomIndex.X - 1;
                game.Player.Position = new Vector2(game.GraphicsManager.PreferredBackBufferWidth - 50 * Constants.UniversalScale, (game.GraphicsManager.PreferredBackBufferHeight + Constants.HudAndMenuHeight - 16 * Constants.UniversalScale) / 2);
            }
            else if (direction == Direction.East)
            {
                currentRoomIndex.X = currentRoomIndex.X + 1 >= game.Dungeon.DungeonSize - 1 ? game.Dungeon.DungeonSize - 1 : currentRoomIndex.X + 1;
                game.Player.Position = new Vector2(33 * Constants.UniversalScale, (game.GraphicsManager.PreferredBackBufferHeight + Constants.HudAndMenuHeight - 16 * Constants.UniversalScale) / 2);
            }
			game.Player.Update(); // needed to insure the player position is properly updated
            SwitchRoomsStart(direction);
        }
    }
}


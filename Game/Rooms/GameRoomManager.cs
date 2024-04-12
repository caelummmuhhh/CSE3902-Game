using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using MainGame.Players;
using Microsoft.Xna.Framework;

namespace MainGame.Rooms
{
    public class GameRoomManager
    {
        public Game1 game;
        public IRoom CurrentRoom { get; set; }
        public IRoom SwitchingRoom { get; set; }

        private readonly List<IRoom> allRooms = new();

        private bool roomChangeDebounce = true;

        private float SpeedX { get; set; }
        private float SpeedY { get; set; }
        private float ScrollSpeed;

        public Rectangle gameArea;

        public GameRoomManager(Game1 game)
        {
            this.game = game;
            LoadAllRooms(game.Player);
            CurrentRoom = allRooms[1];
            CurrentRoom.isCurrentRoom = true;
            gameArea = new Rectangle(0, Constants.HudAndMenuHeight, game.GraphicsManager.PreferredBackBufferWidth, game.GraphicsManager.PreferredBackBufferHeight - Constants.HudAndMenuHeight);
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
            if (SwitchingRoom != null)
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
                    game.Player.isHidden = false;
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

        public void GetNorthRoom() => SwitchRoom(
            CurrentRoom.ConnectingRooms[0],
            new Vector2(0, gameArea.Top - gameArea.Height - Constants.HudAndMenuHeight),
            new Vector2(0, ScrollSpeed),
            new Vector2(0, 15)
            );


        public void GetSouthRoom() => SwitchRoom(
            CurrentRoom.ConnectingRooms[1],
            new Vector2(0, gameArea.Bottom-Constants.HudAndMenuHeight),
            new Vector2(0, -ScrollSpeed),
            CurrentRoom.DoorLocations[0] + new Vector2(0, 15)
            );


        public void GetEastRoom() => SwitchRoom(
            CurrentRoom.ConnectingRooms[2],
            new Vector2(gameArea.Right, 0),
            new Vector2(-ScrollSpeed, 0),
            CurrentRoom.DoorLocations[2] + new Vector2(20, 0)
            );


        public void GetWestRoom() => SwitchRoom(
            CurrentRoom.ConnectingRooms[3],
            new Vector2(gameArea.Left - gameArea.Width, 0),
            new Vector2(ScrollSpeed, 0),
            CurrentRoom.DoorLocations[3] + new Vector2(-20, 0)
            );


        private void SwitchRoom(int nextRoomNum, Vector2 newRoomPosition, Vector2 newRoomScrollSpeed, Vector2 playerPosition)
        {
            // RoomNumber == -1 means room does not exist
            if (!roomChangeDebounce || nextRoomNum == -1)
            {
                return;
            }
            CurrentRoom.isCurrentRoom = false;
            SwitchingRoom = allRooms[nextRoomNum];
            SwitchingRoom.Position = newRoomPosition;
            SpeedX = newRoomScrollSpeed.X;
            SpeedY = newRoomScrollSpeed.Y;
        }
    }
}

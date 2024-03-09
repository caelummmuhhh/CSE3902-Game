using Microsoft.Xna.Framework;
using System.Collections.Generic;

using MainGame.Doors;
using MainGame.RoomsAndDoors;
using MainGame.SpriteHandlers;
using MainGame.BlocksAndItems;
using MainGame.Enemies;

namespace MainGame.Rooms
{
    public class Room
    {
        public ISprite OuterBorder;
        public ISprite InnerBorder;
        public ISprite Tiles;

        public IDoor NorthDoor;
        public IDoor WestDoor;
        public IDoor EastDoor;
        public IDoor SouthDoor;

        public HashSet<Block> Blocks { get; set; } = new();
        public HashSet<Item> Items { get; set; } = new();
        public HashSet<IEnemy> Enemies { get; set; } = new();

        public Vector2 Position;
        private readonly Game1 game;

        // TODO: Delete this for sprint 4
        public int CurrentRoom = 1;
        private readonly int maxRoomChangeDebounce = 2;
        private int roomChangeDebounce;
        private readonly int maxNumRooms = 18;

        public Room(ISprite outerBorder, ISprite innerBorder, ISprite tiles, Game1 game)
        {
            Position = new Vector2(0, 0);
            OuterBorder = outerBorder;
            InnerBorder = innerBorder;
            Tiles = tiles;
            this.game = game;

            OuterBorder.LayerDepth = 0f;
            InnerBorder.LayerDepth = 1.0f;
            Tiles.LayerDepth = 1.0f;

            NorthDoor = new BlankDoor();
            WestDoor = new BlankDoor();
            SouthDoor = new BlankDoor();
            EastDoor = new BlankDoor();
            roomChangeDebounce = maxRoomChangeDebounce;
        }

        public void Update()
        {
            OuterBorder.Update();
            InnerBorder.Update();
            Tiles.Update();
            foreach (Block block in Blocks)
            {
                block.Update();
            }
            foreach (Item item in Items)
            {
                item.Update();
            }
            foreach (IEnemy enemy in Enemies)
            {
                enemy.Update();
            }
            roomChangeDebounce--;
        }

        public void Draw()
        {
            OuterBorder.Draw(Position.X, Position.Y, Color.White);
            InnerBorder.Draw(Position.X, Position.Y, Color.White);
            Tiles.Draw(Position.X, Position.Y, Color.White);

            NorthDoor.Draw();
            SouthDoor.Draw();
            WestDoor.Draw();
            EastDoor.Draw();

            foreach (Block block in Blocks)
            {
                block.Draw();
            }
            foreach (Item item in Items)
            {
                item.Draw();
            }
            foreach(IEnemy enemy in Enemies)
            {
                enemy.Draw();
            }
        }

        public Room GetNextRoom()
        {
            if (roomChangeDebounce <= 0)
            {
                int newRoomNumber = (CurrentRoom + 1) % maxNumRooms;
                if (newRoomNumber == 0)
                {
                    newRoomNumber = 1;
                }
                Room newRoom = RoomFactory.GenerateRoom(newRoomNumber, game);
                return newRoom;
            }
            return this;
        }
    }
}
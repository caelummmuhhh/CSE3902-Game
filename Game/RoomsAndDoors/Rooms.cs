﻿using MainGame.Doors;
using MainGame.RoomsAndDoors;
using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;
using MainGame.Blocks;
using MainGame.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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

        public HashSet<Block> Blocks;
        public HashSet<Item> Items;

        public Vector2 Position;
        private readonly Game1 game;

        public int nextRoom = 5;
        private int changeTimeDelay;
        
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

            Blocks = new HashSet<Block>();
            Items = new HashSet<Item>();

            changeTimeDelay = 10;
        }

        public void Update()
        {
            OuterBorder.Update();
            InnerBorder.Update();
            Tiles.Update();
            foreach(Block block in Blocks)
            {
                block.Update();
            }
            foreach (Item item in Items )
            {
                item.Update();
            }

            changeTimeDelay--;
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
        }

        public Room getNextRoom()
        {
            if (changeTimeDelay < 0)
            {

                return RoomFactory.GenerateRoom("Room_" + nextRoom, game);
            }
            else
            {
                return this;
            }
        }

    }
}

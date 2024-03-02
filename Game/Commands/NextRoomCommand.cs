using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Collections.Generic;

using MainGame.SpriteHandlers;
using MainGame.Players;
using MainGame.Blocks;
using MainGame.Items;
using MainGame.Rooms;
using MainGame.Doors;
using MainGame.Managers;
using MainGame.RoomsAndDoors;

namespace MainGame.Commands
{
    public class NextRoomCommand: ICommand
    {
        private Game game;
        private Player player;
        private Room room;
        private Door NorthDoor;
        private Door SouthDoor;
        private Door WestDoor;
        private Door EastDoor;


        public NextRoomCommand(Game game, IPlayer player, Room room, Door NorthDoor, Door SouthDoor, Door WestDoor, Door EastDoor)
        {
            this.game = game;
            this.room = room;
            this.NorthDoor = NorthDoor;
            this.SouthDoor = SouthDoor;
            this.WestDoor = WestDoor;
            this.EastDoor = EastDoor;
        }

        public void Execute()
        {
            RoomsAndDoorsManager roomsAndDoorsManager = new RoomsAndDoorsManager();
            Reader reader = new Reader();
            Writer writer = new Writer();
            RoomsAndDoorsManager.counter = (RoomsAndDoorsManager.counter + 1) % RoomsAndDoorsManager.total;
            String file = roomsAndDoorsManager.GetRoom(RoomsAndDoorsManager.counter);
            var room_var = reader.read(file);
            string room_type = room_var.Item1;
            string[] doors = room_var.Item2;
            string[][] roomArray = room_var.Item3;
            writer.Room(room_type,room);


            
        }

        public void UnExecute()
        {
        }

    }
}
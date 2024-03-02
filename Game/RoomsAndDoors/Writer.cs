using System;
using MainGame.Rooms;
using MainGame.SpriteHandlers;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;

namespace MainGame.RoomsAndDoors
{
	public class Writer 
	{
        public void Room(string room_type, Room room, Game game) 
        {
            if (room_type== "dungeonNormal" ){
            room = new Room(
                SpriteFactory.CreateRoomOuterBorderSprite(),
                SpriteFactory.CreateRoomInnerBorderSprite(),
                SpriteFactory.CreateDungeonTilesSprite(),
                game
            );
            if (room_type== "undergroundRoom" ){
            room = new Room(
                SpriteFactory.CreateEmptyRoomSprite(),
                SpriteFactory.CreateEmptyRoomSprite(),
                SpriteFactory.CreateUndergroundRoomSprite(),
                game
            );
            if (room_type== "dungeonOldMan" ){
            room = new Room(
                SpriteFactory.CreateRoomOuterBorderSprite(),
                SpriteFactory.CreateRoomInnerBorderSprite(),
                SpriteFactory.CreateEmptyRoomSprite(),
                game
            );
            }
        }
    }
}
    }
}

using System;
using System.Reflection.Metadata.Ecma335;
using MainGame.Doors;
using MainGame.Rooms;
using MainGame.SpriteHandlers;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;

namespace MainGame.RoomsAndDoors
{
	public class Writer 
	{
        public Room writeRoom(string room_type, Room room, Game game) 
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
    return room;
}
        public Door[] writeDoors(string[] doors, Game game) 
        {
            Door[] new_doors = new Door[4];
            //north door
            if (doors[0] == "wallNormal") {
                new_doors[0] = new Door(
            new Vector2(336, 0),
            SpriteFactory.CreateDoorTopNorthSouth("North", "wallNormal"),
            SpriteFactory.CreateDoorBottomNorthSouth("North", "wallNormal"),
            "North",
            game
        );}
            if (doors[0] == "wallDestructible") {
                new_doors[0] = new Door(
            new Vector2(336, 0),
            SpriteFactory.CreateDoorTopNorthSouth("North", "wallDestructible"),
            SpriteFactory.CreateDoorBottomNorthSouth("North", "wallDestructible"),
            "North",
            game
        );}
            if (doors[0] == "destroyedWall") {
                new_doors[0] = new Door(
            new Vector2(336, 0),
            SpriteFactory.CreateDoorTopNorthSouth("North", "destroyedWall"),
            SpriteFactory.CreateDoorBottomNorthSouth("North", "destroyedWall"),
            "North",
            game
        );}
            if (doors[0] == "openDoor") {
                new_doors[0] = new Door(
            new Vector2(336, 0),
            SpriteFactory.CreateDoorTopNorthSouth("North", "openDoor"),
            SpriteFactory.CreateDoorBottomNorthSouth("North", "openDoor"),
            "North",
            game
        );}
            if (doors[0] == "keyDoor") {
                new_doors[0] = new Door(
            new Vector2(336, 0),
            SpriteFactory.CreateDoorTopNorthSouth("North", "keyDoor"),
            SpriteFactory.CreateDoorBottomNorthSouth("North", "keyDoor"),
            "North",
            game
        );}
            if (doors[0] == "diamondDoor") {
                new_doors[0] = new Door(
            new Vector2(336, 0),
            SpriteFactory.CreateDoorTopNorthSouth("North", "diamondDoor"),
            SpriteFactory.CreateDoorBottomNorthSouth("North", "diamondDoor"),
            "North",
            game
        );}
            //south door
            if (doors[1] == "wallNormal") {
                new_doors[1] = new Door(
            new Vector2(336, 480),
            SpriteFactory.CreateDoorTopNorthSouth("South", "wallNormal"),
            SpriteFactory.CreateDoorBottomNorthSouth("South", "wallNormal"),
            "South",
            game
        );}
            if (doors[1] == "wallDestructible") {
                new_doors[1] = new Door(
            new Vector2(336, 480),
            SpriteFactory.CreateDoorTopNorthSouth("South", "wallDestructible"),
            SpriteFactory.CreateDoorBottomNorthSouth("South", "wallDestructible"),
            "South",
            game
        );}
            if (doors[1] == "destroyedWall") {
                new_doors[1] = new Door(
            new Vector2(336, 480),
            SpriteFactory.CreateDoorTopNorthSouth("South", "destroyedWall"),
            SpriteFactory.CreateDoorBottomNorthSouth("South", "destroyedWall"),
            "South",
            game
        );}
            if (doors[1] == "openDoor") {
                new_doors[1] = new Door(
            new Vector2(336, 480),
            SpriteFactory.CreateDoorTopNorthSouth("South", "openDoor"),
            SpriteFactory.CreateDoorBottomNorthSouth("South", "openDoor"),
            "South",
            game
        );}
            if (doors[1] == "keyDoor") {
                new_doors[1] = new Door(
            new Vector2(336, 480),
            SpriteFactory.CreateDoorTopNorthSouth("South", "keyDoor"),
            SpriteFactory.CreateDoorBottomNorthSouth("South", "keyDoor"),
            "South",
            game
        );}
            if (doors[1] == "diamondDoor") {
                new_doors[1] = new Door(
            new Vector2(336, 480),
            SpriteFactory.CreateDoorTopNorthSouth("South", "diamondDoor"),
            SpriteFactory.CreateDoorBottomNorthSouth("South", "diamondDoor"),
            "South",
            game
        );}
        //west door
            if (doors[2] == "wallNormal") {
                new_doors[2] = new Door(
            new Vector2(0, 216),
            SpriteFactory.CreateDoorTopNorthSouth("West", "wallNormal"),
            SpriteFactory.CreateDoorBottomNorthSouth("West", "wallNormal"),
            "West",
            game
        );}
            if (doors[2] == "wallDestructible") {
                new_doors[2] = new Door(
            new Vector2(0, 216),
            SpriteFactory.CreateDoorTopNorthSouth("West", "wallDestructible"),
            SpriteFactory.CreateDoorBottomNorthSouth("West", "wallDestructible"),
            "West",
            game
        );}
            if (doors[2] == "destroyedWall") {
                new_doors[2] = new Door(
            new Vector2(0, 216),
            SpriteFactory.CreateDoorTopNorthSouth("West", "destroyedWall"),
            SpriteFactory.CreateDoorBottomNorthSouth("West", "destroyedWall"),
            "West",
            game
        );}
            if (doors[2] == "openDoor") {
                new_doors[2] = new Door(
            new Vector2(0, 216),
            SpriteFactory.CreateDoorTopNorthSouth("West", "openDoor"),
            SpriteFactory.CreateDoorBottomNorthSouth("West", "openDoor"),
            "West",
            game
        );}
            if (doors[2] == "keyDoor") {
                new_doors[2] = new Door(
            new Vector2(0, 216),
            SpriteFactory.CreateDoorTopNorthSouth("West", "keyDoor"),
            SpriteFactory.CreateDoorBottomNorthSouth("West", "keyDoor"),
            "West",
            game
        );}
            if (doors[2] == "diamondDoor") {
                new_doors[2] = new Door(
            new Vector2(0, 216),
            SpriteFactory.CreateDoorTopNorthSouth("West", "diamondDoor"),
            SpriteFactory.CreateDoorBottomNorthSouth("West", "diamondDoor"),
            "West",
            game
        );}
        //east door
            if (doors[3] == "wallNormal") {
                new_doors[3] = new Door(
            new Vector2(720, 216),
            SpriteFactory.CreateDoorTopNorthSouth("East", "wallNormal"),
            SpriteFactory.CreateDoorBottomNorthSouth("East", "wallNormal"),
            "East",
            game
        );}
            if (doors[3] == "wallDestructible") {
                new_doors[3] = new Door(
            new Vector2(720, 216),
            SpriteFactory.CreateDoorTopNorthSouth("East", "wallDestructible"),
            SpriteFactory.CreateDoorBottomNorthSouth("East", "wallDestructible"),
            "East",
            game
        );
            if (doors[3] == "destroyedWall") {
                new_doors[3] = new Door(
            new Vector2(720, 216),
            SpriteFactory.CreateDoorTopNorthSouth("East", "destroyedWall"),
            SpriteFactory.CreateDoorBottomNorthSouth("East", "destroyedWall"),
            "East",
            game
        );}
            if (doors[3] == "openDoor") {
                new_doors[3] = new Door(
            new Vector2(720, 216),
            SpriteFactory.CreateDoorTopNorthSouth("East", "openDoor"),
            SpriteFactory.CreateDoorBottomNorthSouth("East", "openDoor"),
            "East",
            game
        );}
            if (doors[3] == "keyDoor") {
                new_doors[3] = new Door(
            new Vector2(720, 216),
            SpriteFactory.CreateDoorTopNorthSouth("East", "keyDoor"),
            SpriteFactory.CreateDoorBottomNorthSouth("East", "keyDoor"),
            "East",
            game
        );}
            if (doors[3] == "diamondDoor") {
                new_doors[3] = new Door(
            new Vector2(720, 216),
            SpriteFactory.CreateDoorTopNorthSouth("East", "diamondDoor"),
            SpriteFactory.CreateDoorBottomNorthSouth("East", "diamondDoor"),
            "East",
            game
        );}
            }
            return new_doors;
            }
        }
}
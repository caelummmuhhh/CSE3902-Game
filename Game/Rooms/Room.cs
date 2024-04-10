using Microsoft.Xna.Framework;
using System.Collections.Generic;

using MainGame.Doors;
using MainGame.SpriteHandlers;
using MainGame.Blocks;
using MainGame.Items;
using MainGame.Enemies;
using MainGame.Players;
using MainGame.Particles;
using MainGame.Collision;
using System.Diagnostics;

namespace MainGame.Rooms
{
    public class Room : IRoom
    {
        public int RoomId { get; set; }
        public IPlayer RoomPlayer { get; set; }

        public List<IEnemy> RoomEnemies { get; set; } = new();
        public List<IBlock> RoomBlocks { get; set; } = new();
        public List<IItem> RoomItems { get; set; } = new();
        public List<IParticle> RoomParticles { get; set; } = new();

        // TODO: Change this. I am not sure the best way to do this right now but this is my current attempt to get something to work
        // Not very happy with this solution but will come back and fix -Landon
        public Vector2[] BaseRoomEnemies { get; set; }
        public Vector2[] BaseRoomBlocks { get; set; }
        public Vector2[] BaseRoomItems { get; set; }
        public Vector2[] BaseRoomParticles { get; set; }


        public IHitBox EnemiesBorderHitBox { get; set; }
        public IHitBox PlayerBorderHitBox { get; set; }

        public IDoor NorthDoor { get; set; }
        public IDoor WestDoor { get; set; }
        public IDoor EastDoor { get; set; }
        public IDoor SouthDoor { get; set; }

        public int[] ConnectingRooms { get; set; }

        public ISprite OuterBorderSprite { get; set; }
        public ISprite InnerBorderSprite { get; set; }
        public ISprite TilesSprite { get; set; }

        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public Vector2[] DoorLocations { get; set; } // TODO: Fix this. I don't really like the way its set up but its the only way I can think to do it

        public bool isCurrentRoom {  get; set; }

        public Room(ISprite outerBorder, ISprite innerBorder, ISprite tiles)
        {
            Position = new Vector2(0, 0);
            Size = new Vector2(0, 0);
            OuterBorderSprite = outerBorder;
            InnerBorderSprite = innerBorder;
            TilesSprite = tiles;

            OuterBorderSprite.LayerDepth = 0f;
            InnerBorderSprite.LayerDepth = 1.0f;
            TilesSprite.LayerDepth = 1.0f;

            EnemiesBorderHitBox = new AllFullWallHitBox();
            PlayerBorderHitBox = new GenericHitBox();

            DoorLocations = new Vector2[4];
            isCurrentRoom = false;
        }

        // Method for updating all objects in a room to the position the whole room is in
        public void AlignPosition()
        {
            OuterBorderSprite.DestinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
            InnerBorderSprite.DestinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
            TilesSprite.DestinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);

            NorthDoor.Position = DoorLocations[0] + Position;
            SouthDoor.Position = DoorLocations[1] + Position;
            EastDoor.Position = DoorLocations[2] + Position;
            WestDoor.Position = DoorLocations[3] + Position;

            for (int i = 0; i < RoomBlocks.Count; i++)
            {
                RoomBlocks[i].Position = BaseRoomBlocks[i] + Position;
            }
            for(int i = 0; i < RoomEnemies.Count; i++) 
            {
                RoomEnemies[i].Position = BaseRoomEnemies[i] + Position;
            }
            for (int i = 0; i < RoomItems.Count; i++)
            {
                RoomItems[i].Position = BaseRoomItems[i] + Position;
            }
            for (int i = 0; i < RoomParticles.Count; i++)
            {
                RoomParticles[i].Position = BaseRoomParticles[i] + Position;
            }

        }

        public void Update()
        {
            AlignPosition();
            //RoomPlayer.Update();
            OuterBorderSprite.Update();
            InnerBorderSprite.Update();
            TilesSprite.Update();

            foreach (IBlock block in RoomBlocks)
            { 
                block.Update();
            }
            if (isCurrentRoom)
            {
                foreach (IItem item in RoomItems)
                {
                    item.Update();
                }
                foreach (IEnemy enemy in RoomEnemies)
                {
                    enemy.Update();
                }
                foreach (IParticle particle in RoomParticles)
                {
                    particle.Update();
                }
            }
        }

        public void Draw()
        {
            //RoomPlayer.Draw();
            OuterBorderSprite.Draw(Position.X, Position.Y, Color.White);
            InnerBorderSprite.Draw(Position.X, Position.Y, Color.White);
            TilesSprite.Draw(Position.X, Position.Y, Color.White);

            NorthDoor.Draw();
            SouthDoor.Draw();
            WestDoor.Draw();
            EastDoor.Draw();

            foreach (IBlock block in RoomBlocks)
            {
                block.Draw();
            }
            if(isCurrentRoom)
            {
                foreach (IItem item in RoomItems)
                {
                    item.Draw();
                }
                foreach (IEnemy enemy in RoomEnemies)
                {
                    enemy.Draw();
                }
                foreach (IParticle particle in RoomParticles)
                {
                    particle.Draw();
                }
            }
        }
    }
}
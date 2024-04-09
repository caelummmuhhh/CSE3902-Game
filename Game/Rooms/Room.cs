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

        public IHitBox EnemiesBorderHitBox { get; set; }
        public IHitBox PlayerBorderHitBox { get; set; }

        public IDoor NorthDoor { get; set; }
        public IDoor WestDoor { get; set; }
        public IDoor EastDoor { get; set; }
        public IDoor SouthDoor { get; set; }

        public ISprite OuterBorderSprite { get; set; }
        public ISprite InnerBorderSprite { get; set; }
        public ISprite TilesSprite { get; set; }

        private Vector2 Position = new(0, 0);

        public Room(ISprite outerBorder, ISprite innerBorder, ISprite tiles)
        {
            Position = new Vector2(0, Constants.HudAndMenuHeight);
            OuterBorderSprite = outerBorder;
            InnerBorderSprite = innerBorder;
            TilesSprite = tiles;

            OuterBorderSprite.LayerDepth = 0f;
            InnerBorderSprite.LayerDepth = 1.0f;
            TilesSprite.LayerDepth = 1.0f;

            EnemiesBorderHitBox = new AllFullWallHitBox();
            PlayerBorderHitBox = new GenericHitBox();
        }

        public void Update()
        {
            //RoomPlayer.Update();
            OuterBorderSprite.Update();
            InnerBorderSprite.Update();
            TilesSprite.Update();

            foreach (IBlock block in RoomBlocks)
            {
                block.Update();
            }
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
            foreach (IItem item in RoomItems)
            {
                item.Draw();
            }
            foreach(IEnemy enemy in RoomEnemies)
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
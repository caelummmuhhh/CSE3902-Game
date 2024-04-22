using Microsoft.Xna.Framework;
using System.Collections.Generic;

using MainGame.Doors;
using MainGame.SpriteHandlers;
using MainGame.Blocks;
using MainGame.WorldItems;
using MainGame.Enemies;
using MainGame.Players;
using MainGame.Particles;
using MainGame.Collision;
using MainGame.Projectiles;

namespace MainGame.Rooms
{
    public class Room : IRoom
    {
        public int RoomId { get; set; }
        public IPlayer RoomPlayer { get; set; }

        public List<IEnemy> RoomEnemies { get; set; } = new();
        public List<IBlock> RoomBlocks { get; set; } = new();
        public List<IPickupableItem> RoomItems { get; set; } = new();
        public List<IParticle> RoomParticles { get; set; } = new();
        public List<IProjectile> PlayerProjectiles { get; private set; } = new();
        public List<IProjectile> EnemyProjectiles { get; private set; } = new();


        public ISprite RoomText { get; set; }

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
            foreach (IPickupableItem item in RoomItems)
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

            for (int i = PlayerProjectiles.Count - 1; i >= 0; i--)
            {
                IProjectile projectile = PlayerProjectiles[i];
                projectile.Update();

                if (!projectile.IsActive)
                {
                    PlayerProjectiles.RemoveAt(i);
                }
            }

            for (int i = EnemyProjectiles.Count - 1; i >= 0; i--)
            {
                IProjectile projectile = EnemyProjectiles[i];
                projectile.Update();

                if (!projectile.IsActive)
                {
                    EnemyProjectiles.RemoveAt(i);
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
            foreach (IPickupableItem item in RoomItems)
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
            
            if (RoomText != null) RoomText.Draw(32 * Constants.UniversalScale, 32 * Constants.UniversalScale + Constants.HudAndMenuHeight, Color.White);

            foreach (IProjectile projectile in PlayerProjectiles)
            {
                projectile.Draw();
            }
            foreach (IProjectile projectile in EnemyProjectiles)
            {
                projectile.Draw();
            }
        }
    }
}
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using MainGame.Doors;
using MainGame.SpriteHandlers;
using MainGame.Blocks;
using MainGame.WorldItems;
using MainGame.Enemies;
using MainGame.Players;
using MainGame.Particles;
using MainGame.Collision;
using MainGame.Projectiles;
using MainGame.Audio;

namespace MainGame.Rooms
{
    public class Room : IRoom
    {
        public int RoomId { get; set; }
        public IPlayer RoomPlayer { get; set; }

        public List<IEnemy> RoomEnemies { get; set; } = new();
        public List<IBlock> RoomBlocks { get; set; } = new();
        public List<IPickupableItem> RoomItems { get; set; } = new();
        public List<IPickupableItem> WaitingRoomItems { get; set; } = new();

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

        public Vector2 Position { get; set;}

        public Room(ISprite outerBorder, ISprite innerBorder, ISprite tiles)
        {
            Position = new Vector2(0, Constants.HudAndMenuHeight);
            OuterBorderSprite = outerBorder;
            InnerBorderSprite = innerBorder;
            TilesSprite = tiles;

            EnemiesBorderHitBox = new AllFullWallHitBox();
            PlayerBorderHitBox = new GenericHitBox();

        }

        public void Update()
        {
            //RoomPlayer.Update();
            OuterBorderSprite.Update();
            InnerBorderSprite.Update();
            TilesSprite.Update();

            NorthDoor.Update();
            SouthDoor.Update();
            WestDoor.Update();
            EastDoor.Update();

            foreach (IBlock block in RoomBlocks) block.Update();

            if (RoomEnemies.Count == 0 && WaitingRoomItems.Count > 0)
            {
                for (int i = 0; i < WaitingRoomItems.Count; i++)
                {
                    RoomItems.Add(WaitingRoomItems[0]);
                    WaitingRoomItems.RemoveAt(0);
                }
                AudioManager.PlaySFX("Item_Appear", 0);
            }

            foreach (IPickupableItem item in RoomItems) item.Update();

            foreach (IParticle particle in RoomParticles) particle.Update();

            for (int i = RoomEnemies.Count - 1; i >= 0; i--)
            {
                RoomEnemies[i].Update();
                if (!RoomEnemies[i].Exists)
                {
                    if (RoomEnemies[i] is KeeseEnemy || RoomEnemies[i] is GelEnemy)
                    {
                        IPickupableItem item = ItemFactory.GenerateSmallEnemyDropItem(RoomEnemies[i].Position, RoomPlayer);
                        if (item != null) RoomItems.Add(item);
                    }
                    else
                    {
                        IPickupableItem item = ItemFactory.GenerateRegularEnemyDropItem(RoomEnemies[i].Position, RoomPlayer);
                        if (item != null) RoomItems.Add(item);
                    }
                    RoomEnemies.RemoveAt(i);
                }
            }
            for (int i = PlayerProjectiles.Count - 1; i >= 0; i--)
            {
                PlayerProjectiles[i].Update();
                if (!PlayerProjectiles[i].IsActive) PlayerProjectiles.RemoveAt(i);
            }
            for (int i = EnemyProjectiles.Count - 1; i >= 0; i--)
            {
                EnemyProjectiles[i].Update();
                if (!EnemyProjectiles[i].IsActive) EnemyProjectiles.RemoveAt(i);
            }

            if (!RoomEnemies.Any(enemy => enemy is not SpikeCrossEnemy))
            {
                PushableBlock pushableBlock = GetPushableBlock();
                pushableBlock?.MakePushable();

                if (pushableBlock is not null && !pushableBlock.HasBeenPushed) return;

                if (NorthDoor.DoorType is DoorTypes.DiamondDoor) NorthDoor.Unlock();
                if (EastDoor.DoorType is DoorTypes.DiamondDoor) EastDoor.Unlock();
                if (SouthDoor.DoorType is DoorTypes.DiamondDoor) SouthDoor.Unlock();
                if (WestDoor.DoorType is DoorTypes.DiamondDoor) WestDoor.Unlock();
            }
        }

        public void Draw()
        {
            OuterBorderSprite.Draw(Position.X, Position.Y, Color.White);
            InnerBorderSprite.Draw(Position.X, Position.Y, Color.White);
            TilesSprite.Draw(Position.X, Position.Y, Color.White);

            NorthDoor.Draw();
            SouthDoor.Draw();
            WestDoor.Draw();
            EastDoor.Draw();

            RoomText?.Draw(32 * Constants.UniversalScale, 32 * Constants.UniversalScale + Constants.HudAndMenuHeight, Color.White);

            foreach (IBlock block in RoomBlocks) block.Draw();
            foreach (IPickupableItem item in RoomItems) item.Draw();
            foreach (IEnemy enemy in RoomEnemies) enemy.Draw();
            foreach (IParticle particle in RoomParticles) particle.Draw();
            foreach (IProjectile projectile in PlayerProjectiles) projectile.Draw();
            foreach (IProjectile projectile in EnemyProjectiles) projectile.Draw();
        }

        private PushableBlock GetPushableBlock()
        {
            foreach (IBlock block in RoomBlocks)
            {
                if (block is PushableBlock pushableBlock)
                {
                    return pushableBlock;
                }
            }
            return null;
        }

    }
}
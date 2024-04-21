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
	public interface IRoom
	{
		public int RoomId { get; set; }
		public IPlayer RoomPlayer { get; set; }
		public List<IEnemy> RoomEnemies { get; set; }
		public List<IBlock> RoomBlocks { get; set; }
		public List<IPickupableItem> RoomItems { get; set; }
		public List<IParticle> RoomParticles { get; set; }
        public List<IProjectile> PlayerProjectiles { get; }
        public List<IProjectile> EnemyProjectiles { get; }

        public IDoor NorthDoor { get; set; }
        public IDoor WestDoor { get; set; }
        public IDoor EastDoor { get; set; }
        public IDoor SouthDoor { get; set; }

        public IHitBox EnemiesBorderHitBox { get; set; }
        public IHitBox PlayerBorderHitBox { get; set; }

        public ISprite OuterBorderSprite { get; set; }
        public ISprite InnerBorderSprite { get; set; }
        public ISprite TilesSprite { get; set; }

        public void Update();
        public void Draw();
    }
}


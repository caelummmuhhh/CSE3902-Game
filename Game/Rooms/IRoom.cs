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
	public interface IRoom
	{
		public int RoomId { get; set; }
		public IPlayer RoomPlayer { get; set; }
		public List<IEnemy> RoomEnemies { get; set; }
		public List<IBlock> RoomBlocks { get; set; }
		public List<IItem> RoomItems { get; set; }
		public List<IParticle> RoomParticles { get; set; }

        public Vector2[] BaseRoomEnemies { get; set; }
        public Vector2[] BaseRoomBlocks { get; set; }
        public Vector2[] BaseRoomItems { get; set; }
        public Vector2[] BaseRoomParticles { get; set; } 

        public IDoor NorthDoor { get; set; }
        public IDoor WestDoor { get; set; }
        public IDoor EastDoor { get; set; }
        public IDoor SouthDoor { get; set; }
        public Vector2[] DoorLocations { get; set; }

        public int[] ConnectingRooms { get; set; }

        public IHitBox EnemiesBorderHitBox { get; set; }
        public IHitBox PlayerBorderHitBox { get; set; }

        public ISprite OuterBorderSprite { get; set; }
        public ISprite InnerBorderSprite { get; set; }
        public ISprite TilesSprite { get; set; }
    
        public Vector2 Position { get; set; }
        public bool isCurrentRoom { get; set; }

        public void Update();
        public void Draw();
    }
}


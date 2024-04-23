using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;

namespace MainGame.Doors
{
	public interface IDoor
	{
        public Rectangle HitBox { get; }
		public DoorTypes DoorType { get; }
		public Direction Direction { get; }
		public bool IsLocked { get; }

        public Vector2 Position{get; set;}

        public void Update();
		public void Draw();
		public void Unlock();
	}
}


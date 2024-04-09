using Microsoft.Xna.Framework;

namespace MainGame.Doors
{
	public interface IDoor
	{
        //public Rectangle HitBox { get; }
        //public bool IsOpen { get; }
        public Vector2 Position { get; set; }
        public void Update();
		public void Draw();
		//public void Unlock();
	}
}


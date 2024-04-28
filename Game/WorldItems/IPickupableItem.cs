using MainGame.Players;
using Microsoft.Xna.Framework;

namespace MainGame.WorldItems
{
	public interface IPickupableItem
	{
        public int Id { get; }
        public string Name { get; }
        public Vector2 Position { get; set; }
        public Rectangle HitBox { get; }

        public int SpawnCounter { get; set; }

        public void Update();
        public void Draw();
        public void PickUp();
    }
}


using MainGame.Players;
using Microsoft.Xna.Framework;

namespace MainGame.Items
{
	public interface IPickupableItem
	{
        public string Name { get; }
        public Vector2 Position { get; set; }
        public Rectangle HitBox { get; }

        public void Update();
        public void Draw();
        public void PickUp();
    }
}


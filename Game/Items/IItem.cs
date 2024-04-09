using Microsoft.Xna.Framework;

namespace MainGame.Items
{
	public interface IItem
	{
        public Vector2 Position { get; set; }
        public bool PickedUp { get; set; }
        public bool Active { get; set; }
        public Rectangle HitBox { get; }

        public void Update();
        public void Draw();
        public void Collide();
        public void ActivateAbility();
    }
}


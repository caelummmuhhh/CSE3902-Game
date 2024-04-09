using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Items
{
    public class GenericItem : IItem
	{
        public Vector2 Position { get; set; }
        public bool PickedUp { get; set; } = false;
		public bool Active { get; set; }
        public Rectangle HitBox
		{
			get
			{
				if (PickedUp || !Active)
				{
					return new();
				}
				return new(Position.ToPoint(), sprite.DestinationRectangle.Size);
            }
		}
        private readonly ISprite sprite;

        public GenericItem(Vector2 position, ISprite sprite, bool active = true)
		{
			Position = position;
			this.sprite = sprite;
            Active = active;
        }

		public void Update()
		{
			sprite.Update();
		}

		public void Draw()
		{
			if (PickedUp || !Active)
			{
				return;
			}
			sprite.Draw(Position.X, Position.Y, Color.White);
		}

        public void Collide()
        {
			PickedUp = true;
        }

        public void ActivateAbility()
        {
            throw new System.NotImplementedException();
        }
    }
}

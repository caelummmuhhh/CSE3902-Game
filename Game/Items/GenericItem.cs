using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Players;
using System;
using Microsoft.Xna.Framework.Input;

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
        private readonly ItemTypes type;

        public GenericItem(Vector2 position, ISprite sprite, ItemTypes itemType, bool active = true)
		{
			Position = position;
			this.sprite = sprite;
            Active = active;
            type = itemType;
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

        public void ActivateAbility(IPlayer player)
        {
        }
    }
}

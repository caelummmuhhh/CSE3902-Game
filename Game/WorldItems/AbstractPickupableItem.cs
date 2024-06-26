using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Players;
using MainGame.Audio;

namespace MainGame.WorldItems
{
    public abstract class AbstractPickupableItem : IPickupableItem
	{
        public virtual Vector2 Position { get; set; }
        public virtual bool IsPickedUp { get; set; } = false;
        public virtual Rectangle HitBox
		{
			get
			{
				if (IsPickedUp)
				{
					return new();
				}
				return new(Position.ToPoint(), Sprite.DestinationRectangle.Size);
            }
		}
        public virtual int Id => (int)ItemType;
        public virtual string Name => ItemType.ToString();

        protected abstract ISprite Sprite { get; set; }
		protected abstract ItemTypes ItemType { get; set; }
		protected virtual IPlayer Player { get; set; }

        public virtual int SpawnCounter { get; set; }

        public AbstractPickupableItem(Vector2 position, IPlayer player)
		{
            SpawnCounter = 32;
            Position = position;
			Player = player;
        }

		public virtual void Update()
		{
			Sprite.Update();
			SpawnCounter = SpawnCounter - 1 < 0 ? 0 : SpawnCounter - 1;
		}

		public virtual void Draw()
		{
			if (IsPickedUp || SpawnCounter % 4 >= 3)
			{
				return;
			}
			Sprite.Draw(Position.X, Position.Y, Color.White);
		}

		public abstract void PickUp();
    }
}

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
		protected AudioManager audioManager;

        public AbstractPickupableItem(Vector2 position, IPlayer player, AudioManager audioManager)
		{
			Position = position;
			Player = player;
			this.audioManager = audioManager;
        }

		public virtual void Update()
		{
			Sprite.Update();
		}

		public virtual void Draw()
		{
			if (IsPickedUp)
			{
				return;
			}
			Sprite.Draw(Position.X, Position.Y, Color.White);
		}

		public abstract void PickUp();
    }
}

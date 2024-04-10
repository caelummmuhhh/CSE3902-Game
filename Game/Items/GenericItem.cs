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
            switch (type)
            {
                case ItemTypes.Map:
                    player.Items[player.NumItems] = type;
                    ++player.NumItems;
                    break;
                case ItemTypes.Compass:
                    player.Items[player.NumItems] = type;
                    ++player.NumItems;
                    break;
                case ItemTypes.Boomerang:
                    player.Items[player.NumItems] = type;
                    ++player.NumItems;
                    break;
                case ItemTypes.Arrow:
                    player.Items[player.NumItems] = type;
                    ++player.NumItems;
                    break;
                case ItemTypes.Bow:
                    player.Items[player.NumItems] = type;
                    ++player.NumItems;
                    break;
                case ItemTypes.Heart:
                    player.CurrentHealth++;
                    break;
                case ItemTypes.HeartContainer:
                    player.CurrentHealth++;
                    player.MaxHealth++;
                    break;
                case ItemTypes.Clock:
                    //TO DO
                    break;
                case ItemTypes.FiveRupees:
                    player.RupeeCount = player.RupeeCount + 5;
                    break;
                case ItemTypes.Rupee:
                    player.RupeeCount++;
                    break;
                case ItemTypes.Bomb:
                    player.BombCount = player.BombCount + 4;
                    break;
                case ItemTypes.Key:
                    player.KeyCount++;
                    break;
                case ItemTypes.TriforcePiece:
                    //TO DO
                    break;
                case ItemTypes.Fairy:
                    player.CurrentHealth = player.CurrentHealth + 6;
                    break;
                default:
                    break;
            }
        }
    }
}

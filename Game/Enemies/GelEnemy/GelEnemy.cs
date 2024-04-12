using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
	public class GelEnemy : GenericEnemy
	{
        public override Rectangle AttackHitBox
        {
            get
            {
                Rectangle hitbox = new(Position.ToPoint(), Sprite.DestinationRectangle.Size);
                hitbox.Size = new Point(hitbox.Width /= 2, hitbox.Height / 2 + Constants.UniversalScale);
                if (Health <= 0)
                {
                    hitbox.Size = new Point();
                }

                return Utils.CentralizeRectangle((int)Position.X, (int)Position.Y, hitbox);
            }
        }

        public override int MovementCoolDownFrame { get; protected set; } = 1;
        public override int Health { get; protected set; } = 1;
        public override int Damage => 1;

        public GelEnemy(Vector2 startingPosition)
		{
			Position = startingPosition;
            PreviousPosition = new(Position.X, Position.Y);
            Sprite = SpriteFactory.CreateGelSprite();
            State = new GelIdleState(this);
        }

        public override void Move() => State.Move();

        public override void Update()
        {
            State.Update();
            base.Update();
        }
    }
}


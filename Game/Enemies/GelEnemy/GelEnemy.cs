using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Audio;

namespace MainGame.Enemies
{
	public class GelEnemy : GenericEnemy
	{
        public override Rectangle AttackHitBox
        {
            get
            {
                Rectangle hitbox = new(Position.ToPoint(), Sprite.DestinationRectangle.Size);
                hitbox.Height = hitbox.Height / 2 + Constants.UniversalScale;
                hitbox.Width /= 2;

                return Utils.CentralizeRectangle((int)Position.X, (int)Position.Y, hitbox);
            }
        }

        public override int MovementCoolDownFrame { get; protected set; } = 1;

        public GelEnemy(Vector2 startingPosition, AudioManager audioManager)
		{
			Position = startingPosition;
            AudioManager = audioManager;
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


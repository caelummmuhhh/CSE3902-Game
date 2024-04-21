using MainGame.Audio;
using Microsoft.Xna.Framework;

namespace MainGame.Enemies
{
	public class KeeseEnemy : GenericEnemy
	{
        public override Rectangle AttackHitBox
        {
            get
            {
                Rectangle hitbox = new(Position.ToPoint(), Sprite.DestinationRectangle.Size);
                hitbox.Height /= 2;
                hitbox.Y = Utils.CentralizeRectangle((int)Position.X, (int)Position.Y, hitbox).Y;

                return Health > 0 ? hitbox : new();
            }
        }

        public override int Health { get; protected set; } = 1;
        public override int Damage => 1;
        public override int MovementCoolDownFrame { get; protected set; } = 1;

        public KeeseEnemy(Vector2 spawnPosition, AudioManager audioManager)
        {
            Position = spawnPosition;
            AudioManager = audioManager;
            PreviousPosition = new(Position.X, Position.Y);
            State = new KeeseTakeOffState(this);
        }

        public override void Update()
        {
            State.Update();
            base.Update();
        }

        public override void Move()
        {
            PreviousPosition = new(Position.X, Position.Y);
            State.Move();
        }

        public void ChangeDirection()
        {
            MovingDirection = Utils.GetRandomCardinalAndOrdinalDirection();
        }
    }
}


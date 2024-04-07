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

                return hitbox;
            }
        }

        public override int MovementCoolDownFrame { get; protected set; } = 1;

        public KeeseEnemy(Vector2 spawnPosition)
        {
            Position = spawnPosition;
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


using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
	public class OldManEnemy : GenericEnemy
	{
        public override int Health { get; protected set; } = int.MaxValue;
        public override int Damage => 0;

        public override int MovementCoolDownFrame { get; protected set; } = 0;

        public OldManEnemy(Vector2 startingPosition)
		{
			Position = startingPosition;
            PreviousPosition = new(Position.X, Position.Y);
            Sprite = SpriteFactory.CreateOldManSprite();
		}

		public override void Move() { /* bro is too old to move... */ }

        public override void Draw() => Sprite.Draw(Position.X, Position.Y, SpriteColor);

        public override void TakeDamage(Direction sideHit, int damage)
        {
            if (!IsInvulnerable)
            {
                DamageState = new EnemyDamagedState(this, sideHit, true);
            }
        }
        public override void Stun(int duration) { }

    }
}


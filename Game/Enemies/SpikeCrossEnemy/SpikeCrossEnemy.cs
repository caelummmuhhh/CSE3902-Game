using Microsoft.Xna.Framework;
using MainGame.Players;
using MainGame.SpriteHandlers;
using MainGame.Audio;

namespace MainGame.Enemies
{
	public class SpikeCrossEnemy : GenericEnemy
	{
        public override int Health { get; protected set; } = int.MaxValue;
        public override int Damage => 2;

        public override int MovementCoolDownFrame { get; protected set; } = 1;
        public readonly IPlayer Player;

        public SpikeCrossEnemy(Vector2 startingPosition, IPlayer player)
		{
			Position = startingPosition;
            PreviousPosition = new(Position.X, Position.Y);
            Player = player;
			Sprite = SpriteFactory.CreateSpikeCrossSprite();
			State = new SpikeCrossIdleState(this);
		}

        public override void Update() => State.Update();

		public override void Move()
		{
            PreviousPosition = new(Position.X, Position.Y);
            State.Move();
		}

        // You can't hurt these
        public override void TakeDamage(Direction sideHit, int damage) { }
        public override void Stun(int duration) { }
    }
}


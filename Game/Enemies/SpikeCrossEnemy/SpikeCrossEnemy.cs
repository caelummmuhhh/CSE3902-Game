using Microsoft.Xna.Framework;
using MainGame.Players;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
	public class SpikeCrossEnemy : GenericEnemy
	{
    public override int MovementCoolDownFrame { get; protected set; } = GameConstants.SpikeCrossMovementCoolDownFrame;
        public override Rectangle AttackHitBox => new(); // No attack hitbox, you can't hit these
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
    }
}

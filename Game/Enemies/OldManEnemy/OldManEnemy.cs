using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
	public class OldManEnemy : GenericEnemy
	{
		public override int MovementCoolDownFrame { get; protected set; } = GameConstants.OldManMovementCoolDownFrame;

        public OldManEnemy(Vector2 startingPosition)
		{
			Position = startingPosition;
            PreviousPosition = new(Position.X, Position.Y);
            Sprite = SpriteFactory.CreateOldManSprite();
		}

		public override void Move() { /* bro is too old to move... */ }
    }
}

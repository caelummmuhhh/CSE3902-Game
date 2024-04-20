using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Audio;

namespace MainGame.Enemies
{
	public class OldManEnemy : GenericEnemy
	{
        public override Rectangle AttackHitBox { get => new(); }
        public override int MovementCoolDownFrame { get; protected set; } = 0;

        public OldManEnemy(Vector2 startingPosition, AudioManager audioManager)
		{
			Position = startingPosition;
            AudioManager = audioManager;
            PreviousPosition = new(Position.X, Position.Y);
            Sprite = SpriteFactory.CreateOldManSprite();
		}

		public override void Move() { /* bro is too old to move... */ }
    }
}


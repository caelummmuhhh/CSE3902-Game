using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
	public class OldManEnemy : GenericEnemy
	{
		public override int MovementCoolDownFrame { get; protected set; } = 0;

        public OldManEnemy(Vector2 startingPosition)
		{
			Position = startingPosition;
			Sprite = SpriteFactory.CreateOldManSprite();
		}

		public override void Move() { /* bro is too old to move... */ }
    }
}


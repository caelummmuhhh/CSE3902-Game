using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
	public class StalfosEnemy : GenericEnemy
	{
		public override int MovementCoolDownFrame { get; protected set; } = 2;

        private CardinalDirections moveDirection;
		private int moveDuration;
		private readonly int maxMoveDuration = 32;

		public StalfosEnemy(Vector2 startingPosition)
		{
			Position = startingPosition;
			Sprite = SpriteFactory.CreateStalfosSprite();
		}

		public override void Update()
		{
			if (moveDuration <= 0)
			{
                moveDirection = EnemyUtils.GetRandomCardinalDirection();
                moveDuration = maxMoveDuration;
                return;
            }
            moveDuration--;
			base.Update();
        }

        public override void Move()
        {
			if (moveDuration % MovementCoolDownFrame == 0)
			{
				Position = EnemyUtils.DirectionalMove(Position, moveDirection, MovementSpeed);
			}
        }
    }
}


using Microsoft.Xna.Framework;

namespace MainGame.Enemies
{
	public class SpikeCrossMovingState : IEnemyState
	{
		private readonly SpikeCrossEnemy entity;
		private readonly Vector2 originalPosition;
		private readonly int maxMoveDistance = GameConstants.SpikeCrossMoveDistanceFactor1 * GameConstants.SpikeCrossMoveDistanceFactor2 + GameConstants.SpikeCrossMoveDistanceFactor3; // TODO: Actually depends, and x and y could be different
		private readonly int forwardSpeed = GameConstants.SpikeCrossForwardSpeed; // TODO: Double check these speeds, this is a guess
		private readonly int returnSpeed = GameConstants.SpikeCrossReturnSpeed;

		private bool returnToOriginalPosition = false;
		private int movedDistance = 0;

		public SpikeCrossMovingState(SpikeCrossEnemy enemy)
		{
			entity = enemy;
			originalPosition = entity.Position;
		}

		public void Update()
		{
			Move();
			if (!returnToOriginalPosition) { return; }
            if ((entity.MovingDirection == Direction.North && entity.Position.Y >= originalPosition.Y) ||
                (entity.MovingDirection == Direction.East && entity.Position.X < originalPosition.X) ||
                (entity.MovingDirection == Direction.South && entity.Position.Y < originalPosition.Y) ||
                (entity.MovingDirection == Direction.West && entity.Position.X >= originalPosition.X))
            {
                entity.State = new SpikeCrossIdleState(entity);
            }
        }

        public void Draw() => entity.Draw();

		public void Move()
		{
			if (movedDistance >= maxMoveDistance)
			{
				returnToOriginalPosition = true;

				entity.Position = Utils.DirectionalMove(
					entity.Position,
                    Utils.OppositeDirection(entity.MovingDirection),
					returnSpeed);
				return;
			}
			entity.Position = Utils.DirectionalMove(entity.Position, entity.MovingDirection, forwardSpeed);
			movedDistance += forwardSpeed;
        }
    }
}

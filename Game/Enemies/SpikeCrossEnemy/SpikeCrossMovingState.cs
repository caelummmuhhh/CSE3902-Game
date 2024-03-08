using Microsoft.Xna.Framework;

namespace MainGame.Enemies
{
	public class SpikeCrossMovingState : IEnemyState
	{
		private readonly SpikeCrossEnemy entity;
		private readonly CardinalDirections direction;
		private readonly Vector2 originalPosition;
		private readonly int maxMoveDistance = 48 * 3 + 24; // TODO: Actually depends, and x and y could be different
		private readonly int forwardSpeed = 4; // TODO: Double check these speeds, this is a guess
		private readonly int returnSpeed = 2;

		private bool returnToOriginalPosition = false;
		private int movedDistance = 0;

		public SpikeCrossMovingState(SpikeCrossEnemy enemy, CardinalDirections direction)
		{
			entity = enemy;
			this.direction = direction;
			originalPosition = entity.Position;
		}

		public void Update()
		{
			Move();
			if (!returnToOriginalPosition) { return; }
            if ((direction == CardinalDirections.North && entity.Position.Y >= originalPosition.Y) ||
                (direction == CardinalDirections.East && entity.Position.X < originalPosition.X) ||
                (direction == CardinalDirections.South && entity.Position.Y < originalPosition.Y) ||
                (direction == CardinalDirections.West && entity.Position.X >= originalPosition.X))
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
				entity.Position = direction switch
				{
					CardinalDirections.North => EnemyUtils.DirectionalMove(entity.Position, CardinalDirections.South, returnSpeed),
					CardinalDirections.East => EnemyUtils.DirectionalMove(entity.Position, CardinalDirections.West, returnSpeed),
					CardinalDirections.South => EnemyUtils.DirectionalMove(entity.Position, CardinalDirections.North, returnSpeed),
                    CardinalDirections.West => EnemyUtils.DirectionalMove(entity.Position, CardinalDirections.East, returnSpeed),
                    _ => entity.Position = entity.Position
				};
				return;
			}
			entity.Position = EnemyUtils.DirectionalMove(entity.Position, direction, forwardSpeed);
			movedDistance += forwardSpeed;
        }
    }
}


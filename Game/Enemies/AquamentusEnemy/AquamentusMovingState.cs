using System;
namespace MainGame.Enemies
{
	public class AquamentusMovingState : IEnemyState
	{
		private readonly AquamentusEnemy entity;
        private CardinalDirections direction;
        private readonly int maxMoveDuration = 67;
		private int moveDuration = 0;

		public AquamentusMovingState(AquamentusEnemy enemy)
		{
			entity = enemy;
			direction = EnemyUtils.Randomize(CardinalDirections.East, CardinalDirections.West);
        }

		public void Update()
		{
			if (moveDuration >= maxMoveDuration)
			{
				AttemptAttack();
                ChangeDirection();
				return;
            }
			moveDuration++;
		}

		public void Draw() => entity.Draw();

		public void Move()
		{
			if (moveDuration % entity.MovementCoolDownFrame == 0)
			{
				entity.Position = EnemyUtils.DirectionalMove(entity.Position, direction, entity.MovementSpeed);
			}

			if (direction == CardinalDirections.East)
			{
                entity.MovedDistance += entity.MovementSpeed;
            }
			else
			{
                entity.MovedDistance -= entity.MovementSpeed;
            }
        }

		private void ChangeDirection()
		{
			moveDuration = 0;
			if (entity.MovedDistance >= entity.MaxMoveDistance || entity.MovedDistance <= -entity.MaxMoveDistance)
			{
				direction = EnemyUtils.OppositeDirection(direction);
			}
			else
            {
                direction = EnemyUtils.Randomize(CardinalDirections.East, CardinalDirections.West);
            }
        }

		private void AttemptAttack()
		{
			Random random = new();
			if (random.Next(1) == 0)
			{
				entity.State = new AquamentusAttackingState(this, entity);
			}
		}
    }
}


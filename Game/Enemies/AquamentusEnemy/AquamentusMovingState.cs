using System;
using Microsoft.Xna.Framework;

namespace MainGame.Enemies
{
	public class AquamentusMovingState : IEnemyState
	{
		private readonly AquamentusEnemy entity;
        private readonly int maxMoveDuration = 67;
		private int moveDuration = 0;

		public AquamentusMovingState(AquamentusEnemy enemy)
		{
			entity = enemy;
			entity.MovingDirection = Utils.Randomize(Direction.East, Direction.West);
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

        public void Draw() => entity.Sprite.Draw(entity.Position.X, entity.Position.Y, entity.SpriteColor);

        public void Move()
		{
            entity.PreviousPosition = new(entity.Position.X, entity.Position.Y);
            if (moveDuration % entity.MovementCoolDownFrame == 0)
			{
				entity.Position = Utils.DirectionalMove(entity.Position, entity.MovingDirection, entity.MovementSpeed);
			}

			if (entity.MovingDirection == Direction.East)
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
                entity.MovingDirection = Utils.OppositeDirection(entity.MovingDirection);
			}
			else
            {
                entity.MovingDirection = Utils.Randomize(Direction.East, Direction.West);
            }
        }

		private void AttemptAttack()
		{
			Random random = new();
			if (random.Next(2) == 0)
			{
				entity.State = new AquamentusAttackingState(this, entity);
			}
		}
    }
}


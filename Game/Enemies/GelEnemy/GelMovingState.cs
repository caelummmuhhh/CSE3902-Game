using System;
using Microsoft.Xna.Framework;

namespace MainGame.Enemies
{
	public class GelMovingState : IEnemyState
	{
        private readonly IEnemy entity;
		private int stateDuration = 16;
		private readonly CardinalDirections moveDirection;

        public GelMovingState(IEnemy enemy)
		{
			Random random = new();
			entity = enemy;

            int randDirectionInt = random.Next(0, Enum.GetNames(moveDirection.GetType()).Length);
            moveDirection = (CardinalDirections)randDirectionInt;
        }

        public void Update()
		{
			if (stateDuration <= 0)
			{
				entity.State = new GelIdleState(entity);
			}
            Move();
			stateDuration--;
		}

		public void Draw() => entity.Draw();

		public void Move()
		{
            float x = entity.Position.X;
            float y = entity.Position.Y;
            entity.Position = moveDirection switch
            {
                CardinalDirections.North => new Vector2(x, y - KeeseEnemy.Speed),
                CardinalDirections.East => new Vector2(x + KeeseEnemy.Speed, y),
                CardinalDirections.South => new Vector2(x, y + KeeseEnemy.Speed),
                CardinalDirections.West => new Vector2(x - KeeseEnemy.Speed, y),
                _ => new Vector2(x, y)
            };
        }
    }
}


using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
	public class KeeseTakeOffState : IEnemyState
	{
		private readonly IEnemy entity;
		private readonly CardinalAndOrdinalDirection direction;
		private readonly int stateDuration;
		private int stateTimeRemaining;

		public KeeseTakeOffState(IEnemy enemy)
		{
			Random random = new();
			int directionInt = random.Next(0, Enum.GetNames(direction.GetType()).Length);
			direction = (CardinalAndOrdinalDirection)directionInt;

			entity = enemy;
			entity.Sprite = SpriteFactory.CreateKeeseTakeOffSprite();

			AnimatedSprite newSprite = (AnimatedSprite)entity.Sprite;
            stateDuration = newSprite.AnimationFrameDuration;
			stateTimeRemaining = stateDuration;
		}

		public void Update()
		{
			if (stateTimeRemaining <= 0)
			{
				entity.State = new KeeseFlyingState(entity);
				return;
			}

			stateTimeRemaining--;
			Move();
		}

		public void Draw() => entity.Draw();

		public void Move()
		{
			// Move in direction every 8 frames for first half, then 4 frames for second
			if ((stateTimeRemaining > stateDuration / 2 && stateTimeRemaining % 8 != 0)
				|| (stateTimeRemaining <= stateDuration / 2 && stateTimeRemaining % 4 != 0))
			{
				return;
			}

			float x = entity.Position.X;
			float y = entity.Position.Y;

			entity.Position = direction switch
			{
				CardinalAndOrdinalDirection.North => new Vector2(x, y - KeeseEnemy.Speed),
				CardinalAndOrdinalDirection.NorthEast => new Vector2(x + KeeseEnemy.Speed, y - KeeseEnemy.Speed),
				CardinalAndOrdinalDirection.East => new Vector2(x + KeeseEnemy.Speed, y),
				CardinalAndOrdinalDirection.SouthEast => new Vector2(x + KeeseEnemy.Speed, y + KeeseEnemy.Speed),
				CardinalAndOrdinalDirection.South => new Vector2(x, y + KeeseEnemy.Speed),
				CardinalAndOrdinalDirection.SouthWest => new Vector2(x - KeeseEnemy.Speed, y + KeeseEnemy.Speed),
				CardinalAndOrdinalDirection.West => new Vector2(x - KeeseEnemy.Speed, y),
				CardinalAndOrdinalDirection.NorthWest => new Vector2(x - KeeseEnemy.Speed, y - KeeseEnemy.Speed),
				_ => new Vector2(x, y)
			};
		}
	}
}

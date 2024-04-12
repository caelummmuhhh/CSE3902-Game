using Microsoft.Xna.Framework;

namespace MainGame.Enemies
{
	public class GelMovingState : IEnemyState
	{
        private readonly GenericEnemy entity;
        private int stateDuration = 15;

        public GelMovingState(GenericEnemy enemy)
		{
            entity = enemy;
            entity.MovingDirection = Utils.GetRandomCardinalDirection();
        }

        public void Update()
		{
			if (stateDuration <= 0)
			{
				entity.State = new GelIdleState(entity);
			}
			stateDuration--;
		}

        public void Draw() => entity.Sprite.Draw(entity.Position.X, entity.Position.Y, entity.SpriteColor);

        public void Move()
		{
			if (stateDuration % entity.MovementCoolDownFrame == 0)
			{
				entity.Position = Utils.DirectionalMove(
					entity.Position, entity.MovingDirection, entity.MovementSpeed
				);
            }
        }
    }
}

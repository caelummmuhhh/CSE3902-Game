namespace MainGame.Enemies
{
	public class GelMovingState : IEnemyState
	{
        private readonly GenericEnemy entity;
        private readonly CardinalDirections moveDirection;
        private int stateDuration = 15;

        public GelMovingState(GenericEnemy enemy)
		{
            entity = enemy;
            moveDirection = EnemyUtils.GetRandomCardinalDirection();
        }

        public void Update()
		{
			if (stateDuration <= 0)
			{
				entity.State = new GelIdleState(entity);
			}
			stateDuration--;
		}

		public void Draw() => entity.Draw();

		public void Move()
		{
			if (stateDuration % entity.MovementCoolDownFrame == 0)
			{
				entity.Position = EnemyUtils.DirectionalMove(
					entity.Position, moveDirection, entity.MovementSpeed
				);
            }
        }
    }
}

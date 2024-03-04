using System;
namespace MainGame.Enemies
{
	public class SpikeCrossIdleState : IEnemyState
    {
        private readonly SpikeCrossEnemy entity;

        public SpikeCrossIdleState(SpikeCrossEnemy enemy)
		{
            entity = enemy;
        }

        public void Update()
        {
            CardinalDirections direction;

            // FIXME: Spike Cross actually start moving when player is in the same grid block it's in
            if (Math.Abs(entity.Player.Position.X - entity.Position.X) <= 48)
            {
                direction = entity.Player.Position.Y < entity.Position.Y ? CardinalDirections.North : CardinalDirections.South;
            }
            else if (Math.Abs(entity.Player.Position.Y - entity.Position.Y) <= 48)
            {
                direction = entity.Player.Position.X < entity.Position.X ? CardinalDirections.West : CardinalDirections.East;
            }
            else
            {
                return;
            }

            entity.State = new SpikeCrossMovingState(entity, direction);
        }

        public void Draw() => entity.Draw();

        public void Move() { }
    }
}


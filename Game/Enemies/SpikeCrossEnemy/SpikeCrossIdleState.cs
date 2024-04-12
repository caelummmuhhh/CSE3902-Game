using System;
using Microsoft.Xna.Framework;

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
            // FIXME: Spike Cross actually start moving when player is in the same grid block it's in
            if (Math.Abs(entity.Player.Position.X - entity.Position.X) <= 48)
            {
                entity.MovingDirection = entity.Player.Position.Y < entity.Position.Y ? Direction.North : Direction.South;
            }
            else if (Math.Abs(entity.Player.Position.Y - entity.Position.Y) <= 48)
            {
                entity.MovingDirection = entity.Player.Position.X < entity.Position.X ? Direction.West : Direction.East;
            }
            else
            {
                return;
            }

            entity.State = new SpikeCrossMovingState(entity);
        }

        public void Draw() => entity.Sprite.Draw(entity.Position.X, entity.Position.Y, entity.SpriteColor);

        public void Move() { }
    }
}


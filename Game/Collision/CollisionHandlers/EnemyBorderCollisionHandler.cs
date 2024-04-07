using System;
using Microsoft.Xna.Framework;
using MainGame.Enemies;

namespace MainGame.Collision.CollisionHandlers
{
    public class EnemyBorderCollisionHandler : ICollisionHandler
	{
        private readonly IEnemy enemy;
        private readonly Rectangle border;

		public EnemyBorderCollisionHandler(IEnemy enemy, Rectangle border)
		{
            this.enemy = enemy;
            this.border = border;
		}

        public void HandleCollision()
        {
            enemy.Position = enemy.PreviousPosition;
            Rectangle newEnemyHitBox = new(enemy.Position.ToPoint(), enemy.MovementHitBox.Size);
            enemy.Position = CollisionManager.DecoupleRectangle(newEnemyHitBox, border, enemy.MovingDirection);

            if (enemy is KeeseEnemy keese)
            {
                keese.ChangeDirection();
            }
        }
    }
}


using System;
using Microsoft.Xna.Framework;
using MainGame.Enemies;

namespace MainGame.Collision.CollisionHandlers
{
    public class EnemyBorderCollisionHandler : ICollisionHandler
	{
        private readonly IEnemy enemy;
        private readonly IHitBox border;
        private readonly Rectangle overlap;

		public EnemyBorderCollisionHandler(IEnemy enemy, IHitBox border, Rectangle overlap)
		{
            this.enemy = enemy;
            this.border = border;
            this.overlap = overlap;
		}

        public void HandleCollision()
        {
            enemy.Position = enemy.PreviousPosition;
            if (enemy is KeeseEnemy keese)
            {
                keese.ChangeDirection();
            }
        }
    }
}


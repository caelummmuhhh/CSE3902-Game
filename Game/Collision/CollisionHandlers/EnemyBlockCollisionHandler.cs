using System;
using Microsoft.Xna.Framework;
using MainGame.Enemies;
using MainGame.BlocksAndItems;

namespace MainGame.Collision.CollisionHandlers
{
    public class EnemyBlockCollisionHandler : ICollisionHandler
	{
        private readonly IEnemy enemy;
        private readonly Block block;
        private readonly Rectangle overlap;
		public EnemyBlockCollisionHandler(IEnemy enemy, Block block, Rectangle overlap)
		{
            this.enemy = enemy;
            this.block = block;
            this.overlap = overlap;
		}

        public void HandleCollision()
        {
            if (enemy is GoriyaEnemy || enemy is StalfosEnemy || enemy is GelEnemy)
            {
                enemy.Position = enemy.PreviousPosition;
            }
        }
    }
}


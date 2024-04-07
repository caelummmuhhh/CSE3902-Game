using System;
using Microsoft.Xna.Framework;
using MainGame.Enemies;
using MainGame.BlocksAndItems;

namespace MainGame.Collision.CollisionHandlers
{
    public class EnemyBlockCollisionHandler : ICollisionHandler
	{
        private readonly IEnemy enemy;
        private readonly IBlock block;
		public EnemyBlockCollisionHandler(IEnemy enemy, IBlock block)
		{
            this.enemy = enemy;
            this.block = block;
		}

        public void HandleCollision()
        {
            if (enemy is GoriyaEnemy || enemy is StalfosEnemy || enemy is GelEnemy)
            {
                enemy.Position = enemy.PreviousPosition;
                Rectangle newEnemyHitBox = new(enemy.Position.ToPoint(), enemy.MovementHitBox.Size);
                enemy.Position = CollisionManager.DecoupleRectangle(newEnemyHitBox, block.HitBox, enemy.MovingDirection);
            }
        }
    }
}


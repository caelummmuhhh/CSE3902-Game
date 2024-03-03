using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
	public class DamagedEnemyState : IEnemyState
	{
        private int debounceTimer = 50;
		private readonly IEnemy entity;
		private readonly bool knockBack;

        public DamagedEnemyState(IEnemy enemy, bool takeKnockBack)
		{
			//throw new NotImplementedException();

			entity = enemy;
			knockBack = takeKnockBack;
		}

        public void Update()
		{
            if (debounceTimer <= 0)
            {
                // TODO: Revert state
            }

            debounceTimer--;
            Move();
        }

        public void Draw()
		{
            Color color = Color.White;
            if (debounceTimer % 4 == 0 || debounceTimer % 3 == 0)
            {
                color = Color.IndianRed;
            }
            entity.Draw();
            entity.Sprite.Draw(entity.Position.X, entity.Position.Y, color);
        }

        public void Move()
		{
            // TODO: Enemy might or might not take knock back
		}
	}
}


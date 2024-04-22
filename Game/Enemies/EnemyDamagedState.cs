using System;
using Microsoft.Xna.Framework;

namespace MainGame.Enemies
{
	public class EnemyDamagedState : IEnemyState
	{
		private readonly IEnemy entity;
		private readonly bool takeKnockBack;

        private int invulnerableTimer = 0;
        private float knockedBackDistance = 0f;
        private readonly Direction knockBackDirection;

        public EnemyDamagedState(IEnemy enemy, Direction sideHit, bool knockBack = true)
		{
            entity = enemy;
            invulnerableTimer = GenericEnemy.ImmunityFrame;
            knockBackDirection = Utils.OppositeDirection(sideHit);
            takeKnockBack = knockBack; //&& (sideHit == enemy.MovingDirection || knockBackDirection == enemy.MovingDirection);
            entity.IsInvulnerable = true;
        }

        public void Update()
		{
            invulnerableTimer--;
            FlashColors();

            if (invulnerableTimer <= 0)
            {
                entity.SpriteColor = Color.White;
                entity.IsInvulnerable = false;
                Console.WriteLine("Exiting damaged state.");
            }
            Move();
        }

        public void Draw() { }

        public void Move()
		{
            if (takeKnockBack && invulnerableTimer > 0 && knockedBackDistance < GenericEnemy.MaxKnockedBackDistance)
            {
                Vector2 newPos = Utils.DirectionalMove(entity.Position, knockBackDirection, GenericEnemy.KnockBackSpeed);
                knockedBackDistance += Vector2.Distance(newPos, entity.Position);
                entity.Position = newPos;
                return;
            }
        }

        private void FlashColors()
        {
            entity.SpriteColor = Color.White;
            if (invulnerableTimer % 4 == 0 || invulnerableTimer % 4 == 1)
            {
                entity.SpriteColor = Color.IndianRed;
            }
        }
    }
}

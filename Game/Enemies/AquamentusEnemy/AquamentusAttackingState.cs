using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Projectiles;

namespace MainGame.Enemies
{
	public class AquamentusAttackingState : IEnemyState
	{
        private readonly IEnemyState undecoratedState;
        private readonly AquamentusEnemy entity;
        private readonly ISprite originalSprite;
        private int attackDuration = 32;

		public AquamentusAttackingState(IEnemyState undecoratedState, AquamentusEnemy enemy)
		{
            originalSprite = enemy.Sprite;
            enemy.Sprite = SpriteFactory.CreateAquamentusAttackingSprite();
            this.undecoratedState = undecoratedState;
            entity = enemy;

            Vector2 mouthPosition = new(entity.Position.X - 16, entity.Position.Y - 12);
            entity.ProjectilesManager.AddProjectile(new AquamentusAttackProjectiles(mouthPosition, entity.Player));
		}

        public void Update()
        {
            if (attackDuration <= 0)
            {
                UnDecorate();
            }
            undecoratedState.Update();
            attackDuration--;
        }

        public void Draw() => undecoratedState.Draw();

        public void Move() => undecoratedState.Move();

        private void UnDecorate()
        {
            entity.Sprite = originalSprite;
            entity.State = undecoratedState;
        }
    }
}


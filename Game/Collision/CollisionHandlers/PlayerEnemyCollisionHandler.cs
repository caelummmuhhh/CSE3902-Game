using MainGame.Enemies;
using MainGame.Players;

namespace MainGame.Collision.CollisionHandlers
{
	public class PlayerEnemyCollisionHandler : ICollisionHandler
	{
		private readonly IPlayer player;
		private readonly IEnemy enemy;

		public PlayerEnemyCollisionHandler(IPlayer player, IEnemy enemy)
		{
			this.player = player;
			this.enemy = enemy;
		}

        public void HandleCollision()
        {
			if (!enemy.IsStunned)
			{
                Direction playerSideDamaged = Utils.GetCardinalDirectionFrom(player.Position, enemy.Position);
                player.TakeDamage(playerSideDamaged, 1);
            }
        }
    }
}


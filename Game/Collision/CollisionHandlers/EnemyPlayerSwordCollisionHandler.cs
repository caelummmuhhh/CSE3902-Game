using MainGame.Players;
using MainGame.Enemies;

namespace MainGame.Collision.CollisionHandlers
{
	public class EnemyPlayerSwordCollisionHandler : ICollisionHandler
    {
		private readonly IEnemy enemy;
		private readonly IPlayer player;

		public EnemyPlayerSwordCollisionHandler(IEnemy enemy, IPlayer player)
		{
			this.enemy = enemy;
			this.player = player;
		}

		public void HandleCollision()
		{
            Direction playerSideDamaged = Utils.GetCardinalDirectionFrom(enemy.Position, player.Position);
            enemy.TakeDamage(playerSideDamaged, 2);
		}
	}
}


using MainGame.Players;
using MainGame.Items;

namespace MainGame.Collision.CollisionHandlers
{
	public class PlayerItemCollisionHandler : ICollisionHandler
	{
		private readonly IPlayer player;
		private readonly IItem item;

		public PlayerItemCollisionHandler(IPlayer player, IItem item)
		{
			this.player = player;
			this.item = item;
		}

		public void HandleCollision()
		{
			item.Collide();
			// TODO
		}
	}
}


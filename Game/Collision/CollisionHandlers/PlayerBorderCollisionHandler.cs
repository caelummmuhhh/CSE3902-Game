using System;
using Microsoft.Xna.Framework;
using MainGame.Players;

namespace MainGame.Collision.CollisionHandlers
{
	public class PlayerBorderCollisionHandler : ICollisionHandler
    {
        private readonly IPlayer player;
        private readonly Rectangle border;
		public PlayerBorderCollisionHandler(IPlayer player, Rectangle border)
		{
            this.player = player;
            this.border = border;
		}

        public void HandleCollision()
        {
            player.Position = CollisionUtils.DecoupleRectangle(player.MainHitbox, border);
        }
    }
}


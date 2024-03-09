using System;
using Microsoft.Xna.Framework;
using MainGame.BlocksAndItems;
using MainGame.Players;

namespace MainGame.Collision.CollisionHandlers
{
    public class PlayerBlockCollisionHandler : ICollisionHandler
	{
        private readonly IPlayer player;
		public PlayerBlockCollisionHandler(IPlayer player, Block block, Rectangle overlap)
		{
            this.player = player;
		}

        public void HandleCollision()
        {
            player.Position = player.PreviousPosition;
        }
    }
}


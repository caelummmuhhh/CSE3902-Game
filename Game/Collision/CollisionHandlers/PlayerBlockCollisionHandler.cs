using System;
using Microsoft.Xna.Framework;
using MainGame.Blocks;
using MainGame.Players;

namespace MainGame.Collision.CollisionHandlers
{
    public class PlayerBlockCollisionHandler : ICollisionHandler
	{
        private readonly IPlayer player;
        private readonly IBlock block;

		public PlayerBlockCollisionHandler(IPlayer player, IBlock block)
		{
            this.player = player;
            this.block = block;
		}

        public void HandleCollision()
        {
            Vector2 bottomHalfResolved = CollisionManager.DecoupleRectangle(player.BottomHalfHitBox, block.HitBox);
            player.Position = new Vector2(bottomHalfResolved.X, bottomHalfResolved.Y - player.BottomHalfHitBox.Height);

            if (block is PushableBlock)
            {
                PushableBlock pushBlock = block as PushableBlock;
                pushBlock.Collide(player.FacingDirection, player.Position);
            }
        }
    }
}


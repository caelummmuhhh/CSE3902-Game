using System;
using Microsoft.Xna.Framework;
using MainGame.WorldItems;

namespace MainGame.Collision.CollisionHandlers
{
	public class MovingItemBorderCollisionHandler : ICollisionHandler
    {
        private readonly IPickupableItem item;
        private readonly Rectangle border;

        public MovingItemBorderCollisionHandler(IPickupableItem item, Rectangle border)
        {
            this.item = item;
            this.border = border;
        }

        public void HandleCollision()
        {
            item.Position = CollisionUtils.DecoupleRectangle(item.HitBox, border);

            if (item is FairyItem fairy) {
                fairy.ChangeMoveDirection();
            }
        }
    }
}

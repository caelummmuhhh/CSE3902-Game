using System;
using Microsoft.Xna.Framework;
namespace MainGame.Collision
{
	public class CollisionManager
	{
		public CollisionManager()
		{
		}

        public static Vector2 ResolveOverlap(Rectangle source, Rectangle collidedInto, Rectangle overlap)
        {
            // Determine the direction of the collision based on the overlap rectangle
            Vector2 direction = Vector2.Zero;
            if (overlap.Width < overlap.Height)
            {
                if (overlap.Left < collidedInto.Left)
                {
                    // Collided from the left
                    direction.X = -1;
                }
                else
                {
                    // Collided from the right
                    direction.X = 1;
                }
            }
            else
            {
                if (overlap.Top < collidedInto.Top)
                {
                    // Collided from the top
                    direction.Y = -1;
                }
                else
                {
                    // Collided from the bottom
                    direction.Y = 1;
                }
            }

            // Adjust the position of the source rectangle based on the collision direction
            Vector2 newPosition = source.Location.ToVector2() + direction * overlap.Size.ToVector2();

            return newPosition;
        }
    }
}



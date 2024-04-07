using System;
using Microsoft.Xna.Framework;
namespace MainGame.Collision
{
	public class CollisionManager
	{
		public CollisionManager()
		{
		}

		public static Vector2 DecoupleRectangle(Rectangle source, Rectangle collidedInto, Direction movementDirection)
		{
            Rectangle overlap = Rectangle.Intersect(source, collidedInto);
			switch (movementDirection)
			{
				case Direction.North:
                    source.Y += overlap.Height;
					break;

                case Direction.NorthEast:
                    if (overlap.Width >= overlap.Height)
                    {
                        source.Y += overlap.Height;
                    }
                    else
                    {
                        source.X -= overlap.Width;
                    }
                    break;

                case Direction.East:
                    source.X -= overlap.Width;
                    break;

                case Direction.SouthEast:
                    if (overlap.Width >= overlap.Height)
                    {
                        source.Y -= overlap.Height;
                    }
                    else
                    {
                        source.X -= overlap.Width;
                    }
                    break;

                case Direction.South:
                    source.Y -= overlap.Height;
                    break;

                case Direction.SouthWest:
                    if (overlap.Width >= overlap.Height)
                    {
                        source.Y -= overlap.Height;
                    }
                    else
                    {
                        source.X += overlap.Width;
                    }
                    break;

                case Direction.West:
                    source.X += overlap.Width;
                    break;

                case Direction.NorthWest:
                    if (overlap.Width >= overlap.Height)
                    {
                        source.Y += overlap.Height;
                    }
                    else
                    {
                        source.X += overlap.Width;
                    }
                    break;

                default:
                    break;
            }
            return new Vector2(source.X, source.Y);
        }

        public static Vector2 DecoupleRectangle(Rectangle source, Rectangle collidedInto)
        {
            Rectangle overlap = Rectangle.Intersect(source, collidedInto);

            if (overlap.Width >= overlap.Height)
            {
                // Move along y-axis
                int moveDir = source.Bottom < collidedInto.Bottom ? -1 : 1;
                source.Y += overlap.Height * moveDir;
            }
            else
            {
                // Move along x-axis
                int moveDir = source.Right < collidedInto.Right ? -1 : 1;
                source.X += overlap.Width * moveDir;
            }
            return new Vector2(source.X, source.Y);
        }
    }
}



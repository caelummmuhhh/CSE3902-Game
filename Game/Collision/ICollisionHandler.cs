using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
	public interface ICollisionHandler<Entity1, Entity2>
	{
		public void HandleCollision(Entity1 entity1, Entity2 entity2, Rectangle overlap);
	}
}


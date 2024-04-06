using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
	public interface IHitBox
	{
		public List<Rectangle> HitBoxes { get; }

		public void Add(IHitBox newHitBox);
	}
}

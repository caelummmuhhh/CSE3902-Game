using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
	public class GenericHitBox : IHitBox
	{
        public List<Rectangle> HitBoxes { get; protected set; } = new();

        public GenericHitBox(params IHitBox[] hitBoxes)
		{
			foreach (IHitBox hitBox in hitBoxes)
			{
				Add(hitBox);
			}
		}

		public void Add(IHitBox newHitBox)
		{
			HitBoxes.AddRange(newHitBox.HitBoxes);
		}
	}
}


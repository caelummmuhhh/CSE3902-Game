﻿using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
	public class LeftFullVerticalWallHitBox : GenericHitBox
	{
        public LeftFullVerticalWallHitBox()
		{
			Rectangle wallHitBox = new(
				x: 0,
				y: 0,
				width: 32 * Constants.UniversalScale,
				height: 176 * Constants.UniversalScale
				);
			HitBoxes.Add(wallHitBox);
		}
	}
}

using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
    public class TopFullHorizontalWallHitBox : IHitBox
    {
        public List<Rectangle> HitBoxes { get; protected set; } = new();

        public TopFullHorizontalWallHitBox()
		{
            Rectangle wallHitBox = new(
                x: 0,
                y: 0,
                width: 256 * Constants.UniversalScale,
                height: 32 * Constants.UniversalScale
                );
            HitBoxes.Add(wallHitBox);
        }
    }
}


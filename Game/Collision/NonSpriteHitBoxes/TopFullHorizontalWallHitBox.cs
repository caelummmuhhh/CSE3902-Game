using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
    public class TopFullHorizontalWallHitBox : GenericHitBox
    {
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


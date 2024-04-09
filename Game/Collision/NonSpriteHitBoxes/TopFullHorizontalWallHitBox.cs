using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
    public class TopFullHorizontalWallHitBox : GenericHitBox
    {
        public TopFullHorizontalWallHitBox()
		{
            Rectangle wallHitBox = new(
                x: 0,
                y: Constants.HudAndMenuHeight,
                width: 16 * Constants.BlockSize,
                height: 2 * Constants.BlockSize
                );
            HitBoxes.Add(wallHitBox);
        }
    }
}


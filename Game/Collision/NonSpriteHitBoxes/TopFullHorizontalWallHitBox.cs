using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
    public class TopFullHorizontalWallHitBox : GenericHitBox
    {
        public TopFullHorizontalWallHitBox(int yShift = 0)
		{
            Rectangle wallHitBox = new(
                x: 0,
                y: yShift + Constants.HudAndMenuHeight,
                width: 16 * Constants.BlockSize,
                height: 2 * Constants.BlockSize
                );
            HitBoxes.Add(wallHitBox);
        }
    }
}


using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
    public class RightFullVerticalWallHitBox : GenericHitBox
    {
        public RightFullVerticalWallHitBox()
        {
            Rectangle wallHitBox = new(
                x: 14 * Constants.BlockSize,
                y: Constants.HudAndMenuHeight,
                width: 2 * Constants.BlockSize,
                height: 11 * Constants.BlockSize
                );
            HitBoxes.Add(wallHitBox);
        }
    }
}


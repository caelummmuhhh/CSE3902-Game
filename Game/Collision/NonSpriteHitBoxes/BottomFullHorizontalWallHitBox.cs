using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
    public class BottomFullHorizontalWallHitBox : GenericHitBox
    {
        public BottomFullHorizontalWallHitBox()
        {
            Rectangle wallHitBox = new(
                x: 0,
                y: 9 * Constants.BlockSize + Constants.HudAndMenuHeight,
                width: 16 * Constants.BlockSize,
                height: 2 * Constants.BlockSize
                );
            HitBoxes.Add(wallHitBox);
        }
    }
}


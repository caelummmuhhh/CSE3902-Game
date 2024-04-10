using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
    public class BottomFullHorizontalWallHitBox : GenericHitBox
    {
        public BottomFullHorizontalWallHitBox()
        {
            Rectangle wallHitBox = new(
                x: GameConstants.BottomFullHorizontalWallX,
                y: GameConstants.BottomFullHorizontalWallY * Constants.BlockSize + Constants.HudAndMenuHeight,
                width: GameConstants.BottomFullHorizontalWallWidth * Constants.BlockSize,
                height: GameConstants.BottomHorizontalDoorWallHeightFactor * Constants.BlockSize
                );
            HitBoxes.Add(wallHitBox);
        }
    }
}

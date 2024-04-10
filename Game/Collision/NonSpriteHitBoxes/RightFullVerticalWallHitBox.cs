using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
    public class RightFullVerticalWallHitBox : GenericHitBox
    {
        public RightFullVerticalWallHitBox()
        {
            Rectangle wallHitBox = new(
                x: GameConstants.RightFullVerticalWallX * Constants.BlockSize,
                y: Constants.HudAndMenuHeight,
                width: GameConstants.RightFullVerticalWallWidth * Constants.BlockSize,
                height: GameConstants.RightFullVerticalWallHeight * Constants.BlockSize
                );
            HitBoxes.Add(wallHitBox);
        }
    }
}

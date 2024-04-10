using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
    public class RightFullVerticalWallHitBox : GenericHitBox
    {
        public RightFullVerticalWallHitBox()
        {
            Rectangle wallHitBox = new(
            x: (GameConstants.RightFullVerticalWallXFactor1 + GameConstants.RightFullVerticalWallXFactor2) * Constants.UniversalScale,
            y: GameConstants.RightFullVerticalWallY,
            width: GameConstants.RightFullVerticalWallWidth * Constants.UniversalScale,
            height: GameConstants.RightFullVerticalWallHeight * Constants.UniversalScale
            );
        HitBoxes.Add(wallHitBox);
        }
    }
}

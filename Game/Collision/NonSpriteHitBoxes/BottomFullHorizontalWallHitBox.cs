using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
    public class BottomFullHorizontalWallHitBox : GenericHitBox
    {
        public BottomFullHorizontalWallHitBox()
        {
        Rectangle wallHitBox = new(
            x: GameConstants.BottomFullHorizontalWallX,
            y: (GameConstants.BottomFullHorizontalWallYFactor1 + GameConstants.BottomFullHorizontalWallYFactor2) * Constants.UniversalScale,
            width: GameConstants.BottomFullHorizontalWallWidth * Constants.UniversalScale,
            height: GameConstants.BottomFullHorizontalWallHeight * Constants.UniversalScale
            );
        HitBoxes.Add(wallHitBox);        }
    }
}

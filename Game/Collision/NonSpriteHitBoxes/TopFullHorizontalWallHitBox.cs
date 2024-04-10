using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
    public class TopFullHorizontalWallHitBox : GenericHitBox
    {
        public TopFullHorizontalWallHitBox()
		{
            Rectangle wallHitBox = new(
            x: GameConstants.TopFullHorizontalWallX,
            y: GameConstants.TopFullHorizontalWallY,
            width: GameConstants.TopFullHorizontalWallWidth * Constants.UniversalScale,
            height: GameConstants.TopFullHorizontalWallHeight * Constants.UniversalScale
            );
        HitBoxes.Add(wallHitBox);
        }
    }
}

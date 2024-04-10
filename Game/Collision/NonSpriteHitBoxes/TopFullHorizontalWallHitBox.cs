using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
    public class TopFullHorizontalWallHitBox : GenericHitBox
    {
        public TopFullHorizontalWallHitBox()
		{
            Rectangle wallHitBox = new(
            x: GameConstants.TopFullHorizontalWallX,
            y: Constants.HudAndMenuHeight,
            width: GameConstants.TopFullHorizontalWallWidth * Constants.BlockSize,
            height: GameConstants.TopFullHorizontalWallHeight * Constants.BlockSize
            );
        HitBoxes.Add(wallHitBox);
        }
    }
}

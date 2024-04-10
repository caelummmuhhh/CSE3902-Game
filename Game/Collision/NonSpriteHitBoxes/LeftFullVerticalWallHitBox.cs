using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
	public class LeftFullVerticalWallHitBox : GenericHitBox
	{
        public LeftFullVerticalWallHitBox()
		{
        Rectangle wallHitBox = new(
            x: GameConstants.LeftFullVerticalWallX,
            y: Constants.HudAndMenuHeight,
            width: GameConstants.LeftFullVerticalWallWidth * Constants.UniversalScale,
            height: GameConstants.LeftFullVerticalWallHeight * Constants.UniversalScale
            );
        HitBoxes.Add(wallHitBox);		}
	}
}

using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
    public class LeftVerticalDoorWallHitBox : GenericHitBox
    {
        public LeftVerticalDoorWallHitBox()
		{
            Rectangle topWall = new(
            x: GameConstants.LeftVerticalDoorWallX,
            y: Constants.HudAndMenuHeight,
            width: GameConstants.LeftVerticalDoorWallWidth * Constants.BlockSize,
            height: GameConstants.LeftVerticalDoorWallTopHeight * Constants.BlockSize
            );

        Rectangle bottomWall = new(
            x: GameConstants.LeftVerticalDoorWallX,
            y: topWall.Bottom + Constants.BlockSize,
            width: GameConstants.LeftVerticalDoorWallWidth * Constants.BlockSize,
            height: GameConstants.LeftVerticalDoorWallBottomHeight * Constants.BlockSize
            );

        HitBoxes.Add(topWall);
        HitBoxes.Add(bottomWall);
        }
    }
}

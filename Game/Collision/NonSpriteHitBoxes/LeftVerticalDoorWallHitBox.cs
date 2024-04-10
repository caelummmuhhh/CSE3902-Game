using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
    public class LeftVerticalDoorWallHitBox : GenericHitBox
    {
        public LeftVerticalDoorWallHitBox()
		{
            Rectangle topWall = new(
            x: GameConstants.LeftVerticalDoorWallX,
            y: GameConstants.LeftVerticalDoorWallY,
            width: GameConstants.LeftVerticalDoorWallWidth * Constants.BlockSize,
            height: GameConstants.LeftVerticalDoorWallTopHeight * Constants.BlockSize
            );

        Rectangle bottomWall = new(
            x: GameConstants.LeftVerticalDoorWallX,
            y: topWall.Height + Constants.BlockSize,
            width: GameConstants.LeftVerticalDoorWallWidth * Constants.BlockSize,
            height: GameConstants.LeftVerticalDoorWallBottomHeight * Constants.BlockSize
            );

        HitBoxes.Add(topWall);
        HitBoxes.Add(bottomWall);
        }
    }
}

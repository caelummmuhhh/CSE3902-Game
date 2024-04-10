using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
    public class RightVerticalDoorWallHitBox : GenericHitBox
    {
        public RightVerticalDoorWallHitBox()
        {
            Rectangle topWall = new(
            x: GameConstants.RightVerticalDoorWallXFactor * Constants.BlockSize,
            y: Constants.HudAndMenuHeight,
            width: GameConstants.RightVerticalDoorWallWidth * Constants.BlockSize,
            height: GameConstants.RightVerticalDoorWallTopHeight * Constants.BlockSize
            );

        Rectangle bottomWall = new(
            x: topWall.X,
            y: topWall.Bottom + Constants.BlockSize,
            width: GameConstants.RightVerticalDoorWallWidth * Constants.BlockSize,
            height: GameConstants.RightVerticalDoorWallBottomHeight * Constants.BlockSize
            );

        HitBoxes.Add(topWall);
        HitBoxes.Add(bottomWall);
        }
    }
}

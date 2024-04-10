using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
    public class BottomHorizontalDoorWallHitBox : GenericHitBox
    {
        public BottomHorizontalDoorWallHitBox()
        {
        Rectangle leftWall = new(
            x: GameConstants.BottomHorizontalDoorWallX,
            y: GameConstants.BottomHorizontalDoorWallYFactor * Constants.BlockSize + Constants.HudAndMenuHeight,
            width: (int)(GameConstants.BottomHorizontalDoorWallWidthFactor * Constants.BlockSize),
            height: GameConstants.BottomHorizontalDoorWallHeightFactor * Constants.BlockSize
            );

        Rectangle rightWall = new(
            x: leftWall.Right + Constants.BlockSize,
            y: leftWall.Y,
            width: (int)(GameConstants.BottomHorizontalDoorWallWidthFactor * Constants.BlockSize),
            height: GameConstants.BottomHorizontalDoorWallHeightFactor * Constants.BlockSize
            );

        HitBoxes.Add(leftWall);
        HitBoxes.Add(rightWall);        }
    }
}

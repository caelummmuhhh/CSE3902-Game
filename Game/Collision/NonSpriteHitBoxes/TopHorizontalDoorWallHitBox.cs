using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
    public class TopHorizontalDoorWallHitBox : GenericHitBox
    {
        public TopHorizontalDoorWallHitBox()
		{
            Rectangle leftWall = new(
            x: GameConstants.TopHorizontalDoorWallX,
            y: GameConstants.TopHorizontalDoorWallY,
            width: (int)(GameConstants.TopHorizontalDoorWallWidthFactor * Constants.BlockSize),
            height: GameConstants.TopHorizontalDoorWallHeight * Constants.BlockSize
            );

        Rectangle rightWall = new(
            x: leftWall.Width + Constants.BlockSize,
            y: leftWall.Y,
            width: (int)(GameConstants.TopHorizontalDoorWallWidthFactor * Constants.BlockSize),
            height: GameConstants.TopHorizontalDoorWallHeight * Constants.BlockSize
            );

        HitBoxes.Add(leftWall);
        HitBoxes.Add(rightWall);
        }
    }
}

using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
    public class LeftVerticalDoorWallHitBox : GenericHitBox
    {
        public LeftVerticalDoorWallHitBox()
		{
            Rectangle topWall = new(
                x: 0,
                y: 0,
                width: 2 * Constants.BlockSize,
                height: 5 * Constants.BlockSize
                );

            Rectangle bottomWall = new(
                x: 0,
                y: topWall.Height + Constants.BlockSize,
                width: 2 * Constants.BlockSize,
                height: 5 * Constants.BlockSize
                );

            HitBoxes.Add(topWall);
            HitBoxes.Add(bottomWall);
        }
    }
}


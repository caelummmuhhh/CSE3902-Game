using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
    public class RightVerticalDoorWallHitBox : GenericHitBox
    {
        public RightVerticalDoorWallHitBox()
        {
            Rectangle topWall = new(
                x: 14 * Constants.BlockSize,
                y: Constants.HudAndMenuHeight,
                width: 2 * Constants.BlockSize,
                height: 5 * Constants.BlockSize
                );

            Rectangle bottomWall = new(
                x: topWall.X,
                y: topWall.Bottom + Constants.BlockSize,
                width: 2 * Constants.BlockSize,
            HitBoxes.Add(topWall);
            HitBoxes.Add(bottomWall);
        }
    }
}


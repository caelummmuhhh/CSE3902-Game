using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
    public class RightVerticalDoorWallHitBox : GenericHitBox
    {
        public RightVerticalDoorWallHitBox()
        {
            Rectangle topWall = new(
                x: (32 + 192) * Constants.UniversalScale,
                y: 0,
                width: 32 * Constants.UniversalScale,
                height: 72 * Constants.UniversalScale
                );

            Rectangle bottomWall = new(
                x: topWall.X,
                y: topWall.Height + 32 * Constants.UniversalScale,
                width: 32 * Constants.UniversalScale,
                height: 72 * Constants.UniversalScale
                );

            HitBoxes.Add(topWall);
            HitBoxes.Add(bottomWall);
        }
    }
}


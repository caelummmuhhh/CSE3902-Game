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
                width: 32 * Constants.UniversalScale,
                height: 72 * Constants.UniversalScale
                );

            Rectangle bottomWall = new(
                x: 0,
                y: topWall.Height + 32 * Constants.UniversalScale,
                width: 32 * Constants.UniversalScale,
                height: 72 * Constants.UniversalScale
                );

            HitBoxes.Add(topWall);
            HitBoxes.Add(bottomWall);
        }
    }
}


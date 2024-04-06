using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
    public class BottomHorizontalDoorWallHitBox : GenericHitBox
    {
        public BottomHorizontalDoorWallHitBox()
        {
            Rectangle leftWall = new(
                x: 0,
                y: (112 + 32) * Constants.UniversalScale,
                width: 112 * Constants.UniversalScale,
                height: 32 * Constants.UniversalScale
                );

            Rectangle rightWall = new(
                x: leftWall.Width + 32 * Constants.UniversalScale,
                y: leftWall.Y,
                width: 112 * Constants.UniversalScale,
                height: 32 * Constants.UniversalScale
                );

            HitBoxes.Add(leftWall);
            HitBoxes.Add(rightWall);
        }
    }
}


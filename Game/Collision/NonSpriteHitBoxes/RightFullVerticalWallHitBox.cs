using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
    public class RightFullVerticalWallHitBox : GenericHitBox
    {
        public RightFullVerticalWallHitBox()
        {
            Rectangle wallHitBox = new(
                x: (32 + 192) * Constants.UniversalScale,
                y: 0,
                width: 32 * Constants.UniversalScale,
                height: 176 * Constants.UniversalScale
                );
            HitBoxes.Add(wallHitBox);
        }
    }
}


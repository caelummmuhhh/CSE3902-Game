using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
    public class BottomFullHorizontalWallHitBox : GenericHitBox
    {
        public BottomFullHorizontalWallHitBox()
        {
            Rectangle wallHitBox = new(
                x: 0,
                y: (112 + 32) * Constants.UniversalScale,
                width: 256 * Constants.UniversalScale,
                height: 32 * Constants.UniversalScale
                );
            HitBoxes.Add(wallHitBox);
        }
    }
}


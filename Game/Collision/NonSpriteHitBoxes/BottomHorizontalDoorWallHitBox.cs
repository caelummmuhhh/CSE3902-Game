using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
    public class BottomHorizontalDoorWallHitBox : GenericHitBox
    {
        public BottomHorizontalDoorWallHitBox()
        {
            Rectangle leftWall = new(
                x: 0,
                y: 9 * Constants.BlockSize + Constants.HudAndMenuHeight,
                width: (int)(7.5f * Constants.BlockSize),
                height: 2 * Constants.BlockSize
                );

            Rectangle rightWall = new(
                x: leftWall.Right + Constants.BlockSize,
                y: leftWall.Y,
                width: (int)(7.5f * Constants.BlockSize),
                height: 2 * Constants.BlockSize
                );

            HitBoxes.Add(leftWall);
            HitBoxes.Add(rightWall);
        }
    }
}


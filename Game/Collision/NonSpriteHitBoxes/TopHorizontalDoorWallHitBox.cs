using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MainGame.Collision
{
    public class TopHorizontalDoorWallHitBox : IHitBox
    {
        public List<Rectangle> HitBoxes { get; protected set; } = new();

        public TopHorizontalDoorWallHitBox()
		{
            Rectangle leftWall = new(
                x: 0,
                y: 0,
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


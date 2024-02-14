using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers
{
	public abstract class AnimatedSpriteWithOffset : AnimatedSprite
	{
		public readonly int StartXPosition;
		public readonly int StartYPosition;
		public readonly int FrameWidth;
		public readonly int FrameHeight;

		public AnimatedSpriteWithOffset(
			Texture2D texture,
			int numRows,
			int numColumns,
            int frameWidth,
            int frameHeight,
			int numberOfFrames,
			int textureStartingX = 0,
			int textureStartingY = 0,
			int scale = 1)
			: base(texture, numRows, numColumns, scale)
		{
			FrameWidth = frameWidth;
            FrameHeight = frameHeight;
            totalFrameCount = numberOfFrames;
            StartXPosition = textureStartingX;
			StartYPosition = textureStartingY;
		}

		public override Rectangle GetSourceRectangle()
		{
            return new Rectangle(
                currentFrame * FrameWidth + StartXPosition,
				StartYPosition,
                FrameWidth,
				FrameHeight);
        }

    }
}


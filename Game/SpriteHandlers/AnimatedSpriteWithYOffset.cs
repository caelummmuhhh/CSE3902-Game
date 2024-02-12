using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers
{
	public abstract class AnimatedSpriteWithYOffset : AnimatedSprite
	{
		public readonly int StartXPosition;
		public readonly int StartYPosition;
		public readonly int FrameWidth;
		public readonly int FrameHeight;

		public AnimatedSpriteWithYOffset(
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
                currentFrame * FrameWidth,
				StartYPosition,
                FrameWidth,
				FrameHeight);
        }

    }
}


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

		protected float rotation;
		protected Vector2 origin;

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
            origin = new(FrameWidth / 2f, FrameHeight / 2f);
            rotation = 0f;
        }

        protected override Rectangle GetSourceRectangle()
		{
            return new Rectangle(
                currentFrame * FrameWidth + StartXPosition,
				StartYPosition,
                FrameWidth,
				FrameHeight);
        }

		protected Rectangle GetDestinationRectangle(float x, float y)
		{
            return new(
                (int)(x - origin.X),
                (int)(y - origin.Y),
                FrameWidth * Scale,
                FrameHeight * Scale);
        }
    }
}


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers
{
	public abstract class StaticSpriteWithOffset : StaticSprite
	{
        public readonly int StartXPosition;
        public readonly int StartYPosition;
        public readonly int FrameWidth;
        public readonly int FrameHeight;

        public StaticSpriteWithOffset(
            Texture2D texture,
            int frameHeight,
            int frameWidth,
            int textureStartingX = 0,
            int textureStartingY = 0,
            int scale = 1) : base(texture, scale)
		{
            FrameWidth = frameWidth;
            FrameHeight = frameHeight;
            StartXPosition = textureStartingX;
            StartYPosition = textureStartingY;
		}

        public override Rectangle GetSourceRectangle()
        {
            return new Rectangle(StartXPosition, StartYPosition, FrameWidth, FrameHeight);
        }
    }
}


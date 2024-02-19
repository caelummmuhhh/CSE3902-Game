using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.BlockSprites
{
	public class BlackSquareSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public BlackSquareSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int spriteHeight = 16,
            int spriteWidth = 16,
            int textureStartingX = 0,
            int textureStartingY = 0,
            int scale = 1) : base(texture, spriteHeight, spriteWidth,
                                  textureStartingX, textureStartingY, scale)
        {
            this.spriteBatch = spriteBatch;
        }

        public override void Update() { /* not needed here */ }

        public override void Draw(float x, float y, Color color, float xMax, float yMax)
        {
            Rectangle srcRectangle = GetSourceRectangle();
            Rectangle destRectangle = new Rectangle(
                (int)(x - (FrameHeight * Scale) / 2),
                (int)(y - (FrameWidth * Scale) / 2),
                FrameWidth * Scale,
                FrameHeight * Scale);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
            spriteBatch.Draw(Texture, destRectangle, srcRectangle, color);
            spriteBatch.End();
        }
    }
}


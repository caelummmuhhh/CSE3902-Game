using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ItemSprites
{
    public class EmptyRoomSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public EmptyRoomSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int spriteHeight = 0,
            int spriteWidth = 0,
            int textureStartingX = 0,
            int textureStartingY = 0,
            int scale = 1) : base(texture, spriteHeight, spriteWidth,
                                  textureStartingX, textureStartingY, scale)
        {
            this.spriteBatch = spriteBatch;
        }

        public override void Update() { /* not needed here */ }

        public override void Draw(float x, float y, Color color, float layerDepth = 1.0f)
        {
            Rectangle srcRectangle = GetSourceRectangle();
            Rectangle destRectangle = new Rectangle(
                0,
                0,
                FrameWidth * Scale,
                FrameHeight * Scale);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
            spriteBatch.Draw(Texture, destRectangle, srcRectangle, color, 0.0f, new Vector2(0, 0), SpriteEffects.None, layerDepth);
            spriteBatch.End();
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.BlockSprites
{
    public class BlockSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public BlockSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int spriteHeight = 16,
            int spriteWidth = 16,
            int textureStartingX = 0,
            int textureStartingY = 0,
            int scale = 1,
            float layerDepth = 0.5f)
            : base(texture, spriteHeight, spriteWidth, textureStartingX, textureStartingY, scale, layerDepth)
        {
            this.spriteBatch = spriteBatch;
            origin = new Vector2(0, 0);
        }

        public override void Update() { /* not needed here */ }

        public override void Draw(float x, float y, Color color)
        {
            Rectangle srcRectangle = GetSourceRectangle();
            Rectangle destRectangle = GetDestinationRectangle(x, y);

            spriteBatch.Draw(Texture, destRectangle, srcRectangle, color, rotation, origin, SpriteEffects.None, layer);
        }

        public void Draw(Rectangle destRect, Color color)
        {
            Rectangle srcRectangle = GetSourceRectangle();

            spriteBatch.Draw(Texture, destRect, srcRectangle, color, rotation, origin, SpriteEffects.None, layer);

        }
    }
}


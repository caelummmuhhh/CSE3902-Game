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
            int spriteHeight = GameConstants.BlockSpriteDefaultSpriteHeight,
            int spriteWidth = GameConstants.BlockSpriteDefaultSpriteWidth,
            int textureStartingX = GameConstants.BlockSpriteDefaultTextureStartingX,
            int textureStartingY = GameConstants.BlockSpriteDefaultTextureStartingY,
            int scale = GameConstants.BlockSpriteDefaultScale,
            float layerDepth = GameConstants.BlockSpriteDefaultLayerDepth)
            : base(texture, spriteHeight, spriteWidth, textureStartingX, textureStartingY, scale, layerDepth)
        {
            this.spriteBatch = spriteBatch;
            origin = new Vector2(GameConstants.BlockSpriteDefaultOrigin, GameConstants.BlockSpriteDefaultOrigin);
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

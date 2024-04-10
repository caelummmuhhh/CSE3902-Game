using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.EnemySprites
{
    public class KeeseLandedSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public KeeseLandedSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
    int spriteHeight = GameConstants.KeeseLandedSpriteDefaultSpriteHeight,
    int spriteWidth = GameConstants.KeeseLandedSpriteDefaultSpriteWidth,
    int textureStartingX = GameConstants.KeeseLandedSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.KeeseLandedSpriteDefaultTextureStartingY,
    int scale = GameConstants.KeeseLandedSpriteDefaultScale,
    float layerDepth = GameConstants.KeeseLandedSpriteDefaultLayerDepth)
    : base(texture, spriteHeight, spriteWidth, textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
}
        public override void Update() { /* not needed here */ }

        public override void Draw(float x, float y, Color color)
        {
            Rectangle srcRectangle = GetSourceRectangle();
            Rectangle destRectangle = GetDestinationRectangle(x, y);

            spriteBatch.Draw(Texture, destRectangle, srcRectangle, color, rotation, origin, SpriteEffects.None, layer);
        }
    }
}

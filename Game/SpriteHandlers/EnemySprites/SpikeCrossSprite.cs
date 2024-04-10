using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.EnemySprites
{
	public class SpikeCrossSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public SpikeCrossSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
    int spriteHeight = GameConstants.SpikeCrossSpriteDefaultSpriteHeight,
    int spriteWidth = GameConstants.SpikeCrossSpriteDefaultSpriteWidth,
    int textureStartingX = GameConstants.SpikeCrossSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.SpikeCrossSpriteDefaultTextureStartingY,
    int scale = GameConstants.SpikeCrossSpriteDefaultScale,
    float layerDepth = GameConstants.SpikeCrossSpriteDefaultLayerDepth)
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

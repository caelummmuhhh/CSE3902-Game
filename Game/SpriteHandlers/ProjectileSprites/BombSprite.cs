using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ProjectileSprites
{
	public class BombSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public BombSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
    int spriteHeight = GameConstants.BombSpriteDefaultSpriteHeight,
    int spriteWidth = GameConstants.BombSpriteDefaultSpriteWidth,
    int textureStartingX = GameConstants.BombSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.BombSpriteDefaultTextureStartingY,
    int scale = GameConstants.BombSpriteDefaultScale,
    float layerDepth = GameConstants.BombSpriteDefaultLayerDepth)
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

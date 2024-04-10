using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ProjectileSprites
{
    public class ArrowProjectileHitSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public ArrowProjectileHitSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
    int spriteHeight = GameConstants.ArrowProjectileHitSpriteDefaultSpriteHeight,
    int spriteWidth = GameConstants.ArrowProjectileHitSpriteDefaultSpriteWidth,
    int textureStartingX = GameConstants.ArrowProjectileHitSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.ArrowProjectileHitSpriteDefaultTextureStartingY,
    int scale = GameConstants.ArrowProjectileHitSpriteDefaultScale,
    float layerDepth = GameConstants.ArrowProjectileHitSpriteDefaultLayerDepth)
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

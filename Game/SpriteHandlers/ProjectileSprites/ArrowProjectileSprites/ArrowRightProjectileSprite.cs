using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ProjectileSprites
{
    public class ArrowRightProjectileSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public ArrowRightProjectileSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
     int spriteHeight = GameConstants.ArrowRightProjectileSpriteDefaultSpriteHeight,
    int spriteWidth = GameConstants.ArrowRightProjectileSpriteDefaultSpriteWidth,
    int textureStartingX = GameConstants.ArrowRightProjectileSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.ArrowRightProjectileSpriteDefaultTextureStartingY,
    int scale = GameConstants.ArrowRightProjectileSpriteDefaultScale,
    float layerDepth = GameConstants.ArrowRightProjectileSpriteDefaultLayerDepth)
    : base(texture, spriteHeight, spriteWidth, textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
    rotation = GameConstants.ArrowRightProjectileSpriteDefaultRotation;
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

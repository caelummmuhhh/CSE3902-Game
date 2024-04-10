using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ProjectileSprites
{
    public class ArrowLeftProjectileSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public ArrowLeftProjectileSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
    int spriteHeight = GameConstants.ArrowLeftProjectileSpriteDefaultSpriteHeight,
    int spriteWidth = GameConstants.ArrowLeftProjectileSpriteDefaultSpriteWidth,
    int textureStartingX = GameConstants.ArrowLeftProjectileSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.ArrowLeftProjectileSpriteDefaultTextureStartingY,
    int scale = GameConstants.ArrowLeftProjectileSpriteDefaultScale,
    float layerDepth = GameConstants.ArrowLeftProjectileSpriteDefaultLayerDepth)
    : base(texture, spriteHeight, spriteWidth, textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
    origin = new(spriteWidth / 2f, spriteHeight / 2f);
    rotation = MathHelper.ToRadians(GameConstants.ArrowLeftProjectileSpriteDefaultRotation);
}
        public override void Update() { /* not needed here */ }

        public override void Draw(float x, float y, Color color)
        {
            Rectangle srcRectangle = GetSourceRectangle();
            Rectangle destRectangle = GetDestinationRectangle(
                x + FrameWidth * Constants.UniversalScale / 2f,
                y + FrameHeight * Constants.UniversalScale / 2f);

            spriteBatch.Draw(Texture, destRectangle, srcRectangle, color, rotation, origin, SpriteEffects.None, layer);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ProjectileSprites
{
	public class ArrowDownProjectileSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public ArrowDownProjectileSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
    int spriteHeight = GameConstants.ArrowDownProjectileSpriteDefaultSpriteHeight,
    int spriteWidth = GameConstants.ArrowDownProjectileSpriteDefaultSpriteWidth,
    int textureStartingX = GameConstants.ArrowDownProjectileSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.ArrowDownProjectileSpriteDefaultTextureStartingY,
    int scale = GameConstants.ArrowDownProjectileSpriteDefaultScale,
    float layerDepth = GameConstants.ArrowDownProjectileSpriteDefaultLayerDepth)
    : base(texture, spriteHeight, spriteWidth, textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
    origin = new(spriteWidth / 2f, spriteHeight / 2f);
    rotation = MathHelper.ToRadians(GameConstants.ArrowDownProjectileSpriteDefaultRotation);
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

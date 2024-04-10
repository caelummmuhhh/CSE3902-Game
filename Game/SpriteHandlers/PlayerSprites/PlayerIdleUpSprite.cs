using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.PlayerSprites
{
    public class PlayerIdleUpSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public PlayerIdleUpSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
    int spriteHeight = GameConstants.PlayerIdleUpSpriteDefaultSpriteHeight,
    int spriteWidth = GameConstants.PlayerIdleUpSpriteDefaultSpriteWidth,
    int textureStartingX = GameConstants.PlayerIdleUpSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.PlayerIdleUpSpriteDefaultTextureStartingY,
    int scale = GameConstants.PlayerIdleUpSpriteDefaultScale,
    float layerDepth = GameConstants.PlayerIdleUpSpriteDefaultLayerDepth)
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

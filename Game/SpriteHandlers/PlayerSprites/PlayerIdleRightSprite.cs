using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.PlayerSprites
{
    public class PlayerIdleRightSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public PlayerIdleRightSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
    int spriteHeight = GameConstants.PlayerIdleRightSpriteDefaultSpriteHeight,
    int spriteWidth = GameConstants.PlayerIdleRightSpriteDefaultSpriteWidth,
    int textureStartingX = GameConstants.PlayerIdleRightSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.PlayerIdleRightSpriteDefaultTextureStartingY,
    int scale = GameConstants.PlayerIdleRightSpriteDefaultScale,
    float layerDepth = GameConstants.PlayerIdleRightSpriteDefaultLayerDepth)
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

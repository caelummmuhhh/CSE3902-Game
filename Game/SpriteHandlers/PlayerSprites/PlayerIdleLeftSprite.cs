using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.PlayerSprites
{
    public class PlayerIdleLeftSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public PlayerIdleLeftSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
    int spriteHeight = GameConstants.PlayerIdleLeftSpriteDefaultSpriteHeight,
    int spriteWidth = GameConstants.PlayerIdleLeftSpriteDefaultSpriteWidth,
    int textureStartingX = GameConstants.PlayerIdleLeftSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.PlayerIdleLeftSpriteDefaultTextureStartingY,
    int scale = GameConstants.PlayerIdleLeftSpriteDefaultScale,
    float layerDepth = GameConstants.PlayerIdleLeftSpriteDefaultLayerDepth)
    : base(texture, spriteHeight, spriteWidth, textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
}
        public override void Update() { /* not needed here */ }

        public override void Draw(float x, float y, Color color)
        {
            Rectangle srcRectangle = GetSourceRectangle();
            Rectangle destRectangle = GetDestinationRectangle(x, y);

            spriteBatch.Draw(Texture, destRectangle, srcRectangle, color, rotation, origin, SpriteEffects.FlipHorizontally, layer);
        }
    }
}

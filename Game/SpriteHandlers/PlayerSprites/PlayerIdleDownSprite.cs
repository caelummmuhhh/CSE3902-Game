using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.PlayerSprites
{
    public class PlayerIdleDownSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public PlayerIdleDownSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
    int spriteHeight = GameConstants.PlayerIdleDownSpriteDefaultSpriteHeight,
    int spriteWidth = GameConstants.PlayerIdleDownSpriteDefaultSpriteWidth,
    int textureStartingX = GameConstants.PlayerIdleDownSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.PlayerIdleDownSpriteDefaultTextureStartingY,
    int scale = GameConstants.PlayerIdleDownSpriteDefaultScale,
    float layerDepth = GameConstants.PlayerIdleDownSpriteDefaultLayerDepth)
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

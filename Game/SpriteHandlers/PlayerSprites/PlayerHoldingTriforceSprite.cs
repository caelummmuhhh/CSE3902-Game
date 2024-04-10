using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.PlayerSprites
{
    public class PlayerHoldingTriforceSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public PlayerHoldingTriforceSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
    int spriteHeight = GameConstants.PlayerHoldingTriforceSpriteDefaultSpriteHeight,
    int spriteWidth = GameConstants.PlayerHoldingTriforceSpriteDefaultSpriteWidth,
    int textureStartingX = GameConstants.PlayerHoldingTriforceSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.PlayerHoldingTriforceSpriteDefaultTextureStartingY,
    int scale = GameConstants.PlayerHoldingTriforceSpriteDefaultScale,
    float layerDepth = GameConstants.PlayerHoldingTriforceSpriteDefaultLayerDepth)
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

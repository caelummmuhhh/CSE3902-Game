using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.PlayerSprites
{
    public class PlayerInteractingRightSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public PlayerInteractingRightSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
    int spriteHeight = GameConstants.PlayerInteractingRightSpriteDefaultSpriteHeight,
    int spriteWidth = GameConstants.PlayerInteractingRightSpriteDefaultSpriteWidth,
    int textureStartingX = GameConstants.PlayerInteractingRightSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.PlayerInteractingRightSpriteDefaultTextureStartingY,
    int scale = GameConstants.PlayerInteractingRightSpriteDefaultScale,
    float layerDepth = GameConstants.PlayerInteractingRightSpriteDefaultLayerDepth)
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

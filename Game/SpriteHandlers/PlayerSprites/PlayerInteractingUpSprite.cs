using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.PlayerSprites
{
    public class PlayerInteractingUpSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public PlayerInteractingUpSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
    int spriteHeight = GameConstants.PlayerInteractingUpSpriteDefaultSpriteHeight,
    int spriteWidth = GameConstants.PlayerInteractingUpSpriteDefaultSpriteWidth,
    int textureStartingX = GameConstants.PlayerInteractingUpSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.PlayerInteractingUpSpriteDefaultTextureStartingY,
    int scale = GameConstants.PlayerInteractingUpSpriteDefaultScale,
    float layerDepth = GameConstants.PlayerInteractingUpSpriteDefaultLayerDepth)
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

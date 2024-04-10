using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.PlayerSprites
{
    public class PlayerInteractingLeftSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public PlayerInteractingLeftSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
    int spriteHeight = GameConstants.PlayerInteractingLeftSpriteDefaultSpriteHeight,
    int spriteWidth = GameConstants.PlayerInteractingLeftSpriteDefaultSpriteWidth,
    int textureStartingX = GameConstants.PlayerInteractingLeftSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.PlayerInteractingLeftSpriteDefaultTextureStartingY,
    int scale = GameConstants.PlayerInteractingLeftSpriteDefaultScale,
    float layerDepth = GameConstants.PlayerInteractingLeftSpriteDefaultLayerDepth)
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

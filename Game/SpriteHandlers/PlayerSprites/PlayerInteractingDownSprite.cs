using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.PlayerSprites
{
    public class PlayerInteractingDownSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public PlayerInteractingDownSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
    int spriteHeight = GameConstants.PlayerInteractingDownSpriteDefaultSpriteHeight,
    int spriteWidth = GameConstants.PlayerInteractingDownSpriteDefaultSpriteWidth,
    int textureStartingX = GameConstants.PlayerInteractingDownSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.PlayerInteractingDownSpriteDefaultTextureStartingY,
    int scale = GameConstants.PlayerInteractingDownSpriteDefaultScale,
    float layerDepth = GameConstants.PlayerInteractingDownSpriteDefaultLayerDepth)
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

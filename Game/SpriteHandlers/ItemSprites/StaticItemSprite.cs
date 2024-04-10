using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ItemSprites
{
    public class StaticItemSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public StaticItemSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
     int spriteHeight = GameConstants.StaticItemSpriteDefaultSpriteHeight,
    int spriteWidth = GameConstants.StaticItemSpriteDefaultSpriteWidth,
    int textureStartingX = GameConstants.StaticItemSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.StaticItemSpriteDefaultTextureStartingY,
    int scale = GameConstants.StaticItemSpriteDefaultScale,
    float layerDepth = GameConstants.StaticItemSpriteDefaultLayerDepth)
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
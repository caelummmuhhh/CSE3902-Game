using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.EnemySprites
{
	public class OldManSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public OldManSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
    int spriteHeight = GameConstants.OldManSpriteDefaultSpriteHeight,
    int spriteWidth = GameConstants.OldManSpriteDefaultSpriteWidth,
    int textureStartingX = GameConstants.OldManSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.OldManSpriteDefaultTextureStartingY,
    int scale = GameConstants.OldManSpriteDefaultScale,
    float layerDepth = GameConstants.OldManSpriteDefaultLayerDepth)
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

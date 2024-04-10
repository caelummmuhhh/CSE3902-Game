using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.PlayerSprites
{
	public class PlayerHoldingItemSprite : StaticSpriteWithOffset
	{
		private readonly SpriteBatch spriteBatch;

		public PlayerHoldingItemSprite(
			Texture2D texture,
			SpriteBatch spriteBatch,
    int spriteHeight = GameConstants.PlayerHoldingItemSpriteDefaultSpriteHeight,
    int spriteWidth = GameConstants.PlayerHoldingItemSpriteDefaultSpriteWidth,
    int textureStartingX = GameConstants.PlayerHoldingItemSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.PlayerHoldingItemSpriteDefaultTextureStartingY,
    int scale = GameConstants.PlayerHoldingItemSpriteDefaultScale,
    float layerDepth = GameConstants.PlayerHoldingItemSpriteDefaultLayerDepth)
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

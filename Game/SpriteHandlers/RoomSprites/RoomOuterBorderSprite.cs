using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ItemSprites
{
    public class RoomOuterBorderSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public RoomOuterBorderSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
     int spriteHeight = GameConstants.RoomOuterBorderSpriteDefaultSpriteHeight,
    int spriteWidth = GameConstants.RoomOuterBorderSpriteDefaultSpriteWidth,
    int textureStartingX = GameConstants.RoomOuterBorderSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.RoomOuterBorderSpriteDefaultTextureStartingY,
    int scale = GameConstants.RoomOuterBorderSpriteDefaultScale,
    float layerDepth = GameConstants.RoomOuterBorderSpriteDefaultLayerDepth)
    : base(texture, spriteHeight, spriteWidth, textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
    origin = new Vector2(GameConstants.RoomOuterBorderSpriteDefaultOriginX, GameConstants.RoomOuterBorderSpriteDefaultOriginY);
    rotation = GameConstants.RoomOuterBorderSpriteDefaultRotation;
}
        public override void Update() { /* not needed here */ }

        public override void Draw(float x, float y, Color color)
        {
            Rectangle srcRectangle = GetSourceRectangle();
            Rectangle destRectangle = new(
                (int)x,
                (int)y,
                FrameWidth * scale,
                FrameHeight * scale);

            spriteBatch.Draw(Texture, destRectangle, srcRectangle, color, rotation, origin, SpriteEffects.None, layer);
        }
    }
}
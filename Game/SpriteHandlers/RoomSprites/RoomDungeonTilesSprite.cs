using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ItemSprites
{
    public class RoomInnerBorderSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public RoomInnerBorderSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
    int spriteHeight = GameConstants.RoomInnerBorderSpriteDefaultSpriteHeight,
    int spriteWidth = GameConstants.RoomInnerBorderSpriteDefaultSpriteWidth,
    int textureStartingX = GameConstants.RoomInnerBorderSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.RoomInnerBorderSpriteDefaultTextureStartingY,
    int scale = GameConstants.RoomInnerBorderSpriteDefaultScale,
    float layerDepth = GameConstants.RoomInnerBorderSpriteDefaultLayerDepth)
    : base(texture, spriteHeight, spriteWidth, textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
    origin = new Vector2(GameConstants.RoomInnerBorderSpriteDefaultOriginX, GameConstants.RoomInnerBorderSpriteDefaultOriginY);
    rotation = GameConstants.RoomInnerBorderSpriteDefaultRotation;
}
        public override void Update() { /* not needed here */ }

        public override void Draw(float x, float y, Color color)
        {
            Rectangle srcRectangle = GetSourceRectangle();
            Rectangle destRectangle = new(
                0,
                0,
                FrameWidth * scale,
                FrameHeight * scale);

            spriteBatch.Draw(Texture, destRectangle, srcRectangle, color, rotation, origin, SpriteEffects.None, layer);
        }
    }
}
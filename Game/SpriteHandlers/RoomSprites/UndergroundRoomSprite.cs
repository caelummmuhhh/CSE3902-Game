using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ItemSprites
{
    public class UndergroundRoomSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public UndergroundRoomSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
    int spriteHeight = GameConstants.UndergroundRoomSpriteDefaultSpriteHeight,
    int spriteWidth = GameConstants.UndergroundRoomSpriteDefaultSpriteWidth,
    int textureStartingX = GameConstants.UndergroundRoomSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.UndergroundRoomSpriteDefaultTextureStartingY,
    int scale = GameConstants.UndergroundRoomSpriteDefaultScale,
    float layerDepth = GameConstants.UndergroundRoomSpriteDefaultLayerDepth)
    : base(texture, spriteHeight, spriteWidth, textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
    origin = new Vector2(GameConstants.UndergroundRoomSpriteDefaultOriginX, GameConstants.UndergroundRoomSpriteDefaultOriginY);
    rotation = GameConstants.UndergroundRoomSpriteDefaultRotation;
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
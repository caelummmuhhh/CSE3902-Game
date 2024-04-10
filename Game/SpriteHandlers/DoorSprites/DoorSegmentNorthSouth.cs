using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ItemSprites
{
    public class DoorSegmentNorthSouth : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public DoorSegmentNorthSouth(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int spriteHeight = GameConstants.DoorSegmentNorthSouthDefaultSpriteHeight,
        int spriteWidth = GameConstants.DoorSegmentNorthSouthDefaultSpriteWidth,
        int textureStartingX = GameConstants.DoorSegmentNorthSouthDefaultTextureStartingX,
        int textureStartingY = GameConstants.DoorSegmentNorthSouthDefaultTextureStartingY,
        int scale = GameConstants.DoorSegmentNorthSouthDefaultScale,
        float layerDepth = GameConstants.DoorSegmentNorthSouthDefaultLayerDepth)
        : base(texture, spriteHeight, spriteWidth, textureStartingX, textureStartingY, scale, layerDepth)
    {
        this.spriteBatch = spriteBatch;
        origin = new Vector2(GameConstants.DoorSegmentNorthSouthDefaultOrigin, GameConstants.DoorSegmentNorthSouthDefaultOrigin);
        rotation = GameConstants.DoorSegmentNorthSouthDefaultRotation;
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
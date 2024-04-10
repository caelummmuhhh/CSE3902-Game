using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ItemSprites
{
    public class DoorSegmentWestEast : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public DoorSegmentWestEast(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int spriteHeight = GameConstants.DoorSegmentWestEastDefaultSpriteHeight,
        int spriteWidth = GameConstants.DoorSegmentWestEastDefaultSpriteWidth,
        int textureStartingX = GameConstants.DoorSegmentWestEastDefaultTextureStartingX,
        int textureStartingY = GameConstants.DoorSegmentWestEastDefaultTextureStartingY,
        int scale = GameConstants.DoorSegmentWestEastDefaultScale,
        float layerDepth = GameConstants.DoorSegmentWestEastDefaultLayerDepth)
        : base(texture, spriteHeight, spriteWidth, textureStartingX, textureStartingY, scale, layerDepth)
    {
        this.spriteBatch = spriteBatch;
        origin = new Vector2(GameConstants.DoorSegmentWestEastDefaultOrigin, GameConstants.DoorSegmentWestEastDefaultOrigin);
        rotation = GameConstants.DoorSegmentWestEastDefaultRotation;
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
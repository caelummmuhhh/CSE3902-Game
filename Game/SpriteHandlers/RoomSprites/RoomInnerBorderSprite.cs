using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ItemSprites
{
    public class RoomDungeonTilesSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public RoomDungeonTilesSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
    int spriteHeight = GameConstants.RoomDungeonTilesSpriteDefaultSpriteHeight,
    int spriteWidth = GameConstants.RoomDungeonTilesSpriteDefaultSpriteWidth,
    int textureStartingX = GameConstants.RoomDungeonTilesSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.RoomDungeonTilesSpriteDefaultTextureStartingY,
    int scale = GameConstants.RoomDungeonTilesSpriteDefaultScale,
    float layerDepth = GameConstants.RoomDungeonTilesSpriteDefaultLayerDepth)
    : base(texture, spriteHeight, spriteWidth, textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
    origin = new Vector2(GameConstants.RoomDungeonTilesSpriteDefaultOriginX, GameConstants.RoomDungeonTilesSpriteDefaultOriginY);
    rotation = GameConstants.RoomDungeonTilesSpriteDefaultRotation;
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
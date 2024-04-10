using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ItemSprites
{
    public class EmptyRoomSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public EmptyRoomSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
    int spriteHeight = GameConstants.EmptyRoomSpriteDefaultSpriteHeight,
    int spriteWidth = GameConstants.EmptyRoomSpriteDefaultSpriteWidth,
    int textureStartingX = GameConstants.EmptyRoomSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.EmptyRoomSpriteDefaultTextureStartingY,
    int scale = GameConstants.EmptyRoomSpriteDefaultScale,
    float layerDepth = GameConstants.EmptyRoomSpriteDefaultLayerDepth)
    : base(texture, spriteHeight, spriteWidth, textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
    origin = new Vector2(GameConstants.EmptyRoomSpriteDefaultOriginX, GameConstants.EmptyRoomSpriteDefaultOriginY);
    rotation = GameConstants.EmptyRoomSpriteDefaultRotation;
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
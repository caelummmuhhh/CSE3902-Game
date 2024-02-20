using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.PlayerSprites
{
    public class PlayerInteractingLeftSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public PlayerInteractingLeftSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int spriteHeight = 16,
            int spriteWidth = 16,
            int textureStartingX = 0,
            int textureStartingY = 0,
            int scale = 1) : base(texture, spriteHeight, spriteWidth,
                                  textureStartingX, textureStartingY, scale)
        {
            this.spriteBatch = spriteBatch;
        }

        public override void Update() { /* not needed here */ }

        public override void Draw(float x, float y, Color color)
        {
            Vector2 origin = new(FrameWidth / 2f, FrameHeight / 2f);
            float rotation = 0f;

            Rectangle srcRectangle = GetSourceRectangle();
            Rectangle destRectangle = new(
                (int)(x - origin.X),
                (int)(y - origin.Y),
                FrameWidth * Scale,
                FrameHeight * Scale);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
            spriteBatch.Draw(Texture, destRectangle, srcRectangle, color, rotation, origin, SpriteEffects.FlipHorizontally, 0f);
            spriteBatch.End();
        }
    }
}


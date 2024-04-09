using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ProjectileSprites
{
    public class ArrowLeftProjectileSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public ArrowLeftProjectileSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int spriteHeight = 16,
            int spriteWidth = 16,
            int textureStartingX = 0,
            int textureStartingY = 0,
            int scale = 1,
            float layerDepth = 0.5f)
            : base(texture, spriteHeight, spriteWidth, textureStartingX, textureStartingY, scale, layerDepth)
        {
            this.spriteBatch = spriteBatch;
            origin = new(spriteWidth / 2f, spriteHeight / 2f);
            rotation = MathHelper.ToRadians(180f);
        }

        public override void Update() { /* not needed here */ }

        public override void Draw(float x, float y, Color color)
        {
            Rectangle srcRectangle = GetSourceRectangle();
            Rectangle destRectangle = GetDestinationRectangle(
                x + FrameWidth * Constants.UniversalScale / 2f,
                y + FrameHeight * Constants.UniversalScale / 2f);

            spriteBatch.Draw(Texture, destRectangle, srcRectangle, color, rotation, origin, SpriteEffects.None, layer);
        }
    }
}

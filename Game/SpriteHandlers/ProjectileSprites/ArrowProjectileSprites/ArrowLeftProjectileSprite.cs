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
            int scale = 1) : base(texture, spriteHeight, spriteWidth,
                                  textureStartingX, textureStartingY, scale)
        {
            this.spriteBatch = spriteBatch;
            rotation = MathHelper.ToRadians(180f);
        }

        public override void Update() { /* not needed here */ }

        public override void Draw(float x, float y, Color color, float xMax, float yMax)
        {
            Rectangle srcRectangle = GetSourceRectangle();
            Rectangle destRectangle = GetDestinationRectangle(x, y);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
            spriteBatch.Draw(Texture, destRectangle, srcRectangle, color, rotation, origin, SpriteEffects.None, 0f);
            spriteBatch.End();
        }
    }
}

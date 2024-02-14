using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGame.SpriteHandlers.Factory
{
    public class LinkUpSpriteWithSword : FactoryAbstract
    {
        public Dictionary<string, Texture2D> TextureMap;
        public SpriteBatch SpriteBatch;
        public LinkUpSpriteWithSword(Dictionary<string, Texture2D> TextureMap, SpriteBatch SpriteBatch)
        {
            this.TextureMap = TextureMap;
            this.SpriteBatch = SpriteBatch;
        }

        public override ISprite createSprite(GraphicsDevice graphicsDevice)
        {
            int x = 0, y = 84;
            int height = 28;
            int width = 62;
            // Get the smaller section of the link texture specifically for up animation
            Texture2D texture = CreateSmallerTexture(TextureMap["linkSpriteSheet"], graphicsDevice, x, y, width, height);

            return new LinkSprite(texture, SpriteBatch, 1, 4);
        }
    }
}

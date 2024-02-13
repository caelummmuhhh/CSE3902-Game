using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers.Factory;

namespace MainGame.SpriteHandlers
{
    public static class SpriteFactory
    {
        public static SpriteBatch SpriteBatch { get; set; }
        public static Dictionary<string, Texture2D> TextureMap = new();
        public static SpriteFont Font;

        public static void LoadAllTextures(ContentManager contents)
        {
            TextureMap.Add("linkSpriteSheet", contents.Load<Texture2D>("PlayerSprites/linkSpriteSheet"));
        }
        
        public static ISprite getSprite(string SpriteName, GraphicsDevice graphicsDevice)
        {
            IFactory factorySprite = new LinkUpSprite(TextureMap, SpriteBatch); 
            switch (SpriteName) {
                case "LinkUpSprite":
                    factorySprite = new LinkUpSprite(TextureMap, SpriteBatch);
                    break;

                case "LinkDownSprite":
                    factorySprite = new LinkDownSprite(TextureMap, SpriteBatch);
                    break;

                case "LinkRightSprite":
                    factorySprite = new LinkRightSprite(TextureMap, SpriteBatch);
                    break;

                case "LinkLeftSprite":
                    factorySprite = new LinkLeftSprite(TextureMap, SpriteBatch);
                    break;
            }

            return factorySprite.createSprite(graphicsDevice);
        }
    }
}


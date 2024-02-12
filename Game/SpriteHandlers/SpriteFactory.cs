using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

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


        // TODO: Make this less hard-coded and maybe make a factory interface?
        public static ISprite CreateTextSprite(string text)
        {
            return new TextSprite(SpriteBatch, Font, text);
        }

        public static ISprite CreateLinkUpSprite(GraphicsDevice graphicsDevice)
        {
            int x = 0, y = 16;
            int height = 15; 
            int width = 30;
            // Get the smaller section of the link texture specifically for up animation
            Texture2D texture = CreateSmallerTexture(TextureMap["linkSpriteSheet"], graphicsDevice, x, y, width, height);

            return new LinkSprite(texture, SpriteBatch, 1, 2);
        }

        public static ISprite CreateLinkDownSprite(GraphicsDevice graphicsDevice)
        {
            int x = 0, y = 0;
            int height = 15;
            int width = 30;
            // Get the smaller section of the link texture specifically for up animation
            Texture2D texture = CreateSmallerTexture(TextureMap["linkSpriteSheet"], graphicsDevice, x, y, width, height);

            return new LinkSprite(texture, SpriteBatch, 1, 2);
        }

        public static ISprite CreateLinkLeftSprite(GraphicsDevice graphicsDevice)
        {
            int x = 0, y = 32;
            int height = 15;
            int width = 30;
            // Get the smaller section of the link texture specifically for up animation
            Texture2D texture = CreateSmallerTexture(TextureMap["linkSpriteSheet"], graphicsDevice, x, y, width, height);

            return new LinkSprite(FlipTextureHorizontally(texture), SpriteBatch, 1, 2);
        }

        public static ISprite CreateLinkRightSprite(GraphicsDevice graphicsDevice)
        {
            int x = 0, y = 32;
            int height = 15;
            int width = 30;
            // Get the smaller section of the link texture specifically for up animation
            Texture2D texture = CreateSmallerTexture(TextureMap["linkSpriteSheet"], graphicsDevice, x, y, width, height);

            return new LinkSprite(texture, SpriteBatch, 1, 2);
        }



        // Function to create a smaller texture from a specific region of the original texture
        private static Texture2D CreateSmallerTexture(Texture2D originalTexture, GraphicsDevice graphicsDevice, int x, int y, int width, int height)
        {
            Color[] data = new Color[originalTexture.Width * originalTexture.Height];
            originalTexture.GetData(data);

            Color[] newData = new Color[width * height];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int index = (y + i) * originalTexture.Width + (x + j);
                    newData[i * width + j] = data[index];
                }
            }

            Texture2D smallerTexture = new Texture2D(graphicsDevice, width, height);
            smallerTexture.SetData(newData);

            return smallerTexture;
        }

        // Function to flip a Texture2D horizontally
        private static Texture2D FlipTextureHorizontally(Texture2D originalTexture)
        {
            Color[] data = new Color[originalTexture.Width * originalTexture.Height];
            originalTexture.GetData(data);

            Color[] newData = new Color[data.Length];

            for (int y = 0; y < originalTexture.Height; y++)
            {
                for (int x = 0; x < originalTexture.Width; x++)
                {
                    newData[y * originalTexture.Width + (originalTexture.Width - 1 - x)] = data[y * originalTexture.Width + x];
                }
            }

            Texture2D flippedTexture = new Texture2D(originalTexture.GraphicsDevice, originalTexture.Width, originalTexture.Height);
            flippedTexture.SetData(newData);

            return flippedTexture;
        }

    }
}


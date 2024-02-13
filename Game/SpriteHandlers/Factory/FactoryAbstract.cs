using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGame.SpriteHandlers.Factory
{
    public abstract class FactoryAbstract : IFactory
    {
        public abstract ISprite createSprite(GraphicsDevice graphicsDevice);

        // Function to create a smaller texture from a specific region of the original texture
        public static Texture2D CreateSmallerTexture(Texture2D originalTexture, GraphicsDevice graphicsDevice, int x, int y, int width, int height)
        {
            Color[] data = new Color[originalTexture.Width * originalTexture.Height];
            originalTexture.GetData(data);

            Color[] newData = new Color[width * height];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int index = (y + i) * originalTexture.Width + x + j;
                    newData[i * width + j] = data[index];
                }
            }

            Texture2D smallerTexture = new Texture2D(graphicsDevice, width, height);
            smallerTexture.SetData(newData);

            return smallerTexture;
        }

        // Function to flip a Texture2D horizontally
        public static Texture2D FlipTextureHorizontally(Texture2D originalTexture)
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

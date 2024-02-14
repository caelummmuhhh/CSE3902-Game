using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MainGame.SpriteHandlers
{
	public static partial class SpriteFactory
	{
		public static SpriteBatch SpriteBatch { get; set; }
		public static Dictionary<string, Texture2D> TextureMap = new();
        public static SpriteFont Font;
        public static int UniversalScaleMultiplier;

		public static void LoadAllTextures(ContentManager contents)
		{
            TextureMap.Add("LinkSprites", contents.Load<Texture2D>("LinkSprites"));
            TextureMap.Add("EnemiesSprites", contents.Load<Texture2D>("EnemiesSprites"));
            TextureMap.Add("BlocksSprites", contents.Load<Texture2D>("BlocksSprites"));

            Font = contents.Load<SpriteFont>("Fonts/Font");
            UniversalScaleMultiplier = 3;
        }

        public static ISprite CreateTextSprite(string text)
        {
            return new TextSprite(SpriteBatch, Font, text);
        }

        public static ISprite CreatePlayerStaticIdleSprite()
		{
			return CreatePlayerIdleLeftSprite();
		}

        public static ISprite CreatePlayerAnimatedIdleSprite()
        {
            return CreatePlayerIdleUpSprite();
        }


        public static ISprite CreatePlayerStaticFallingSprite()
        {
            return CreatePlayerIdleDownSprite();
        }


        public static ISprite CreatePlayerAnimatedWalkingSprite()
        {
            return CreatePlayerIdleRightSprite();
        }
    }
}


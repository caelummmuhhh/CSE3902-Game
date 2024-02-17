using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MainGame.SpriteHandlers
{
	public static partial class SpriteFactory
	{
		public static SpriteBatch SpriteBatch { get; set; }
		public static readonly Dictionary<string, Texture2D> TextureMap = new();
        public static SpriteFont Font;
        public static readonly int UniversalScaleMultiplier = 3;

		public static void LoadAllTextures(ContentManager contents)
		{
            TextureMap.Add("LinkSprites", contents.Load<Texture2D>("LinkSprites"));
            TextureMap.Add("EnemiesSprites", contents.Load<Texture2D>("EnemiesSprites"));
            TextureMap.Add("BlocksSprites", contents.Load<Texture2D>("BlocksSprites"));
            TextureMap.Add("ProjectilesSprites", contents.Load<Texture2D>("ProjectilesSprites"));
            TextureMap.Add("ItemsSprites", contents.Load<Texture2D>("ItemsSprites"));

            Font = contents.Load<SpriteFont>("Fonts/Font");
        }

        public static ISprite CreateTextSprite(string text)
        {
            return new TextSprite(SpriteBatch, Font, text);
        }

        public static ISprite CreatePlayerStaticIdleSprite()
		{
			return CreateHeartItemSprite();
		}

        public static ISprite CreatePlayerAnimatedIdleSprite()
        {
            return CreateTriforcePieceItemSprite();
        }


        public static ISprite CreatePlayerStaticFallingSprite()
        {
            return CreateRupeeItemSprite();
        }


        public static ISprite CreatePlayerAnimatedWalkingSprite()
        {
            return CreateFireSprite();
        }
    }
}


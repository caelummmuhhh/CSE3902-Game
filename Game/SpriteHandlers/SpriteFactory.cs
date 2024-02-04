using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MainGame.SpriteHandlers
{
	public static class SpriteFactory
	{
		public static SpriteBatch SpriteBatch { get; set; }
		public static Dictionary<string, Texture2D> TextureMap = new();
        public static SpriteFont Font;

		public static void LoadAllTextures(ContentManager contents)
		{
			TextureMap.Add("GengarIdle", contents.Load<Texture2D>("PlayerSprites/GengarIdle"));
            TextureMap.Add("GengarFloating", contents.Load<Texture2D>("PlayerSprites/GengarFloating"));
            TextureMap.Add("GengarMoving", contents.Load<Texture2D>("PlayerSprites/GengarMoving"));
            TextureMap.Add("GengarAsleep", contents.Load<Texture2D>("PlayerSprites/GengarAsleep"));
            Font = contents.Load<SpriteFont>("Fonts/Font");
        }


        // TODO: Make this less hard-coded and maybe make a factory interface?
        public static ISprite CreateTextSprite(string text)
        {
            return new TextSprite(SpriteBatch, Font, text);
        }


        public static ISprite CreatePlayerAnimatedIdleSprite()
		{
			return new PlayerAnimatedIdleSprite(TextureMap["GengarIdle"], SpriteBatch, 1, 3);
		}

        public static ISprite CreatePlayerAnimatedWalkingSprite()
        {
            return new PlayerAnimatedWalkingSprite(TextureMap["GengarMoving"], SpriteBatch, 1, 3);
        }


        public static ISprite CreatePlayerStaticFallingSprite()
        {
            return new PlayerStaticFallingSprite(TextureMap["GengarFloating"], SpriteBatch);
        }


        public static ISprite CreatePlayerStaticIdleSprite()
        {
            return new PlayerStaticIdleSprite(TextureMap["GengarAsleep"], SpriteBatch);
        }
    }
}


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

		public static void LoadAllTextures(ContentManager contents)
		{
            TextureMap.Add("LinkSprites", contents.Load<Texture2D>("LinkSprites"));
            TextureMap.Add("EnemiesSprites", contents.Load<Texture2D>("EnemiesSprites"));
            TextureMap.Add("BlocksSprites", contents.Load<Texture2D>("BlocksSprites"));
            TextureMap.Add("ProjectilesSprites", contents.Load<Texture2D>("ProjectilesSprites"));
            TextureMap.Add("ItemsSprites", contents.Load<Texture2D>("ItemsSprites"));
            TextureMap.Add("RoomSprites", contents.Load<Texture2D>("RoomSprites"));
            TextureMap.Add("ParticleSprites", contents.Load<Texture2D>("ParticleSprites"));
            TextureMap.Add("HudAndMenuSprites", contents.Load<Texture2D>("HudAndMenu"));

            Font = contents.Load<SpriteFont>("Fonts/Font");
        }

        public static ISprite CreateTextSprite(string text)
        {
            return new TextSprite(SpriteBatch, Font, text);
        }
    }
}


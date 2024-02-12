using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MainGame.SpriteHandlers.PlayerSprites;

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

            TextureMap.Add("LinkSprites", contents.Load<Texture2D>("LinkSprites"));

            Font = contents.Load<SpriteFont>("Fonts/Font");
        }

        public static ISprite CreatePlayerAttackingDownSprite()
        {
            return new PlayerAttackingDownSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                frameHeight: 27,
                frameWidth: 16,
                numberOfFrames: 4,
                textureStartingX: 0,
                textureStartingY: 48,
                scale: 2);
        }

        public static ISprite CreatePlayerAttackingUpSprite()
        {
            return new PlayerAttackingUpSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                frameHeight: 27,
                frameWidth: 16,
                numberOfFrames: 4,
                textureStartingX: 0,
                textureStartingY: 84,
                scale: 2);
        }

        public static ISprite CreatePlayerAttackingRightSprite()
        {
            return new PlayerAttackingRightSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                frameHeight: 16,
                frameWidth: 27,
                numberOfFrames: 4,
                textureStartingX: 0,
                textureStartingY: 112,
                scale: 2);
        }

        public static ISprite CreatePlayerAttackingLeftSprite()
        {
            return new PlayerAttackingLeftSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                frameHeight: 16,
                frameWidth: 27,
                numberOfFrames: 4,
                textureStartingX: 0,
                textureStartingY: 112,
                scale: 2);
        }



        public static ISprite CreatePlayerWalkingDownSprite()
        {
            return new PlayerWalkingDownSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                frameHeight: 16,
                frameWidth: 16,
                numberOfFrames: 2,
                textureStartingX: 0,
                textureStartingY: 0,
                scale: 2);
        }

        public static ISprite CreatePlayerWalkingUpSprite()
        {
            return new PlayerWalkingUpSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                frameHeight: 16,
                frameWidth: 16,
                numberOfFrames: 2,
                textureStartingX: 0,
                textureStartingY: 16,
                scale: 2);
        }


        public static ISprite CreatePlayerWalkingLeftSprite()
        {
            return new PlayerWalkingLeftSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                frameHeight: 16,
                frameWidth: 16,
                numberOfFrames: 2,
                textureStartingX: 0,
                textureStartingY: 32,
                scale: 2);
        }


        public static ISprite CreatePlayerWalkingRightSprite()
        {
            return new PlayerWalkingRightSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                frameHeight: 16,
                frameWidth: 16,
                numberOfFrames: 2,
                textureStartingX: 0,
                textureStartingY: 32,
                scale: 2);
        }



        public static ISprite CreatePlayerHoldingItemSprite()
        {
            return new PlayerHoldingItemSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                16,
                16,
                0,
                128,
                2);
        }

        public static ISprite CreatePlayerHoldingTriforceSprite()
        {
            return new PlayerHoldingItemSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                16,
                16,
                0,
                144,
                2);
        }



        public static ISprite CreatePlayerInteractingDownSprite()
        {
            return new PlayerInteractingDownSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                spriteHeight: 16,
                spriteWidth: 16,
                textureStartingX: 0,
                textureStartingY: 48,
                scale: 2);
        }

        public static ISprite CreatePlayerInteractingUpSprite()
        {
            return new PlayerInteractingUpSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                spriteHeight: 16,
                spriteWidth: 16,
                textureStartingX: 0,
                textureStartingY: 96,
                scale: 2);
        }


        public static ISprite CreatePlayerInteractingLeftSprite()
        {
            return new PlayerInteractingLeftSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                spriteHeight: 16,
                spriteWidth: 16,
                textureStartingX: 0,
                textureStartingY: 112,
                scale: 2);
        }


        public static ISprite CreatePlayerInteractingRightSprite()
        {
            return new PlayerInteractingRightSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                spriteHeight: 16,
                spriteWidth: 16,
                textureStartingX: 0,
                textureStartingY: 112,
                scale: 2);
        }



        // TODO: Make this less hard-coded and maybe make a factory interface?
        public static ISprite CreateTextSprite(string text)
        {
            return new TextSprite(SpriteBatch, Font, text);
        }


        public static ISprite CreatePlayerAnimatedIdleSprite()
		{
			return CreatePlayerInteractingDownSprite();
		}

        public static ISprite CreatePlayerAnimatedWalkingSprite()
        {
            return CreatePlayerInteractingUpSprite();
        }


        public static ISprite CreatePlayerStaticFallingSprite()
        {
            return CreatePlayerInteractingLeftSprite();
        }


        public static ISprite CreatePlayerStaticIdleSprite()
        {
            return CreatePlayerInteractingRightSprite();
        }
    }
}


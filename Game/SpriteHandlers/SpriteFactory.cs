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
        public static int UniversalScaleMultiplier;

		public static void LoadAllTextures(ContentManager contents)
		{
            TextureMap.Add("LinkSprites", contents.Load<Texture2D>("LinkSprites"));
            TextureMap.Add("EnemiesSprites", contents.Load<Texture2D>("EnemiesSprites"));
            TextureMap.Add("BlocksSprites", contents.Load<Texture2D>("BlocksSprites"));

            Font = contents.Load<SpriteFont>("Fonts/Font");
            UniversalScaleMultiplier = 3;
        }

        public static ISprite CreatePlayerAttackingDownSprite()
        {
            return new PlayerSprites.PlayerAttackingDownSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                frameHeight: 27,
                frameWidth: 16,
                numberOfFrames: 4,
                textureStartingY: 48,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreatePlayerAttackingUpSprite()
        {
            return new PlayerSprites.PlayerAttackingUpSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                frameHeight: 27,
                frameWidth: 16,
                numberOfFrames: 4,
                textureStartingY: 84,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreatePlayerAttackingRightSprite()
        {
            return new PlayerSprites.PlayerAttackingRightSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                frameHeight: 16,
                frameWidth: 27,
                numberOfFrames: 4,
                textureStartingY: 112,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreatePlayerAttackingLeftSprite()
        {
            return new PlayerSprites.PlayerAttackingLeftSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                frameHeight: 16,
                frameWidth: 27,
                numberOfFrames: 4,
                textureStartingY: 112,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreatePlayerWalkingDownSprite()
        {
            return new PlayerSprites.PlayerWalkingDownSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                numberOfFrames: 2,
                textureStartingY: 0,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreatePlayerWalkingUpSprite()
        {
            return new PlayerSprites.PlayerWalkingUpSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                numberOfFrames: 2,
                textureStartingY: 16,
                scale: UniversalScaleMultiplier);
        }


        public static ISprite CreatePlayerWalkingLeftSprite()
        {
            return new PlayerSprites.PlayerWalkingLeftSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                numberOfFrames: 2,
                textureStartingY: 32,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreatePlayerWalkingRightSprite()
        {
            return new PlayerSprites.PlayerWalkingRightSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                numberOfFrames: 2,
                textureStartingY: 32,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreatePlayerHoldingItemSprite()
        {
            return new PlayerSprites.PlayerHoldingItemSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                textureStartingY: 128,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreatePlayerHoldingTriforceSprite()
        {
            return new PlayerSprites.PlayerHoldingItemSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                textureStartingY: 144,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreatePlayerInteractingDownSprite()
        {
            return new PlayerSprites.PlayerInteractingDownSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                textureStartingY: 48,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreatePlayerInteractingUpSprite()
        {
            return new PlayerSprites.PlayerInteractingUpSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                textureStartingY: 96,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreatePlayerInteractingLeftSprite()
        {
            return new PlayerSprites.PlayerInteractingLeftSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                textureStartingY: 112,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreatePlayerInteractingRightSprite()
        {
            return new PlayerSprites.PlayerInteractingRightSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                textureStartingY: 112,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreatePlayerIdleDownSprite()
        {
            return new PlayerSprites.PlayerIdleDownSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                textureStartingY: 0,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreatePlayerIdleUpSprite()
        {
            return new PlayerSprites.PlayerIdleUpSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                textureStartingY: 16,
                scale: UniversalScaleMultiplier);
        }


        public static ISprite CreatePlayerIdleLeftSprite()
        {
            return new PlayerSprites.PlayerIdleLeftSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                textureStartingY: 32,
                scale: UniversalScaleMultiplier);
        }


        public static ISprite CreatePlayerIdleRightSprite()
        {
            return new PlayerSprites.PlayerIdleRightSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                textureStartingY: 32,
                scale: UniversalScaleMultiplier);
        }


        /* Enemy Sprites */
        public static ISprite CreateKeeseFlightSprite()
        {
            return new EnemySprites.KeeseFlightSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateStalfosSprite()
        {
            return new EnemySprites.StalfosSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 1,
                numberOfFrames: 1,
                textureStartingY: 16,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateGelSprite()
        {
            return new EnemySprites.GelSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                textureStartingY: 32,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateWallMasterSprite()
        {
            return new EnemySprites.WallMasterSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                textureStartingY: 96,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateOldManSprite()
        {
            return new EnemySprites.OldManSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                textureStartingX: 0,
                textureStartingY: 112,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateSpikeCrossSprite()
        {
            return new EnemySprites.SpikeCrossSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                textureStartingY: 128,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateAquamentusSprite()
        {
            return new EnemySprites.AquamentusSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                frameHeight: 32,
                frameWidth: 24,
                numberOfFrames: 2,
                textureStartingY: 144,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateAquamentusAttackingSprite()
        {
            return new EnemySprites.AquamentusAttackingSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                frameHeight: 32,
                frameWidth: 24,
                numberOfFrames: 2,
                textureStartingX: 48,
                textureStartingY: 144,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateGoriyaWalkingUpSprite()
        {
            return new EnemySprites.GoriyaWalkingUpSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 1,
                numberOfFrames: 1,
                textureStartingY: 64,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateGoriyaWalkingDownSprite()
        {
            return new EnemySprites.GoriyaWalkingDownSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                textureStartingY: 48,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateGoriyaWalkingLeftSprite()
        {
            return new EnemySprites.GoriyaWalkingLeftSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                textureStartingY: 80,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateGoriyaWalkingRightSprite()
        {
            return new EnemySprites.GoriyaWalkingRightSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                textureStartingY: 80,
                scale: UniversalScaleMultiplier);
        }


        /* Block Sprites */
        public static ISprite CreateBlueFloorSprite()
        {
            return new BlockSprites.BlueFloorSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 0,
                scale: 2
                );
        }

        public static ISprite CreateSquareBlockSprite()
        {
            return new BlockSprites.SquareBlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 16,
                scale: 2
                );
        }

        public static ISprite CreateStatueOneEntranceSprite()
        {
            return new BlockSprites.StatueOneEntranceSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 32,
                scale: 2
                );
        }

        public static ISprite CreateStatueTwoEntranceSprite()
        {
            return new BlockSprites.StatueTwoEntranceSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 48,
                scale: 2
                );
        }

        public static ISprite CreateStatueOneEndSprite()
        {
            return new BlockSprites.StatueOneEndSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 64,
                scale: 2
                );
        }

        public static ISprite CreateStatueTwoEndSprite()
        {
            return new BlockSprites.StatueTwoEndSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 80,
                scale: 2
                );
        }

        public static ISprite CreateBlackSquareSprite()
        {
            return new BlockSprites.BlackSquareSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 96,
                scale: 2
                );
        }

        public static ISprite CreateBlueSandSprite()
        {
            return new BlockSprites.BlueSandSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 112,
                scale: 2
                );
        }

        public static ISprite CreateBlueGapSprite()
        {
            return new BlockSprites.BlueGapSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 128,
                scale: 2
                );
        }

        public static ISprite CreateStairsSprite()
        {
            return new BlockSprites.StairsSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 144,
                scale: 2
                );
        }

        public static ISprite CreateWhiteBrickSprite()
        {
            return new BlockSprites.WhiteBrickSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 160,
                scale: 2
                );
        }

        public static ISprite CreateWhiteLadderSprite()
        {
            return new BlockSprites.WhiteLadderSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 176,
                scale: 2
                );
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


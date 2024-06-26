﻿using System;

namespace MainGame.SpriteHandlers
{
    public static partial class SpriteFactory
    {
        public static ISprite CreateBlockSprite(BlockTypes block)
        {
            return block switch
            {
                BlockTypes.BlueFloor => CreateBlueFloorSprite(),
                BlockTypes.SquareBlock => CreateSquareBlockSprite(),
                BlockTypes.StatueOneEntrance => CreateStatueOneEntranceSprite(),
                BlockTypes.StatueTwoEntrance => CreateStatueTwoEntranceSprite(),
                BlockTypes.StatueOneEnd => CreateStatueOneEndSprite(),
                BlockTypes.StatueTwoEnd => CreateStatueTwoEndSprite(),
                BlockTypes.BlackSquare => CreateBlackSquareSprite(),
                BlockTypes.BlueSand => CreateBlueSandSprite(),
                BlockTypes.BlueGap => CreateBlueGapSprite(),
                BlockTypes.Stairs => CreateStairsSprite(),
                BlockTypes.WhiteBrick => CreateWhiteBrickSprite(),
                BlockTypes.WhiteLadder => CreateWhiteLadderSprite(),
                BlockTypes.PushableBlock => CreateSquareBlockSprite(),
                _ => null,
            };
        }

        /// <summary>
        /// Tries to create a block sprite based on given block name.
        /// </summary>
        /// <param name="blockName">The name of the block.</param>
        /// <returns>The ISprite object created based on the given block name</returns>
        /// <exception cref="ArgumentException">The block name does not match to a block.</exception>
        public static ISprite CreateBlockSprite(string blockName)
        {
            bool conversionSuccess = Enum.TryParse(blockName, out BlockTypes block);

            if (!conversionSuccess)
            {
                throw new ArgumentException("Unable to parse block name string into a block.");
            }

            return CreateBlockSprite(block);
        }


        /* Create methods for each individual sprite. */

        public static ISprite CreateBlueFloorSprite()
        {
            return new BlockSprites.BlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 0,
                layerDepth: DefaultSpriteLayerDepths.BlocksLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateSquareBlockSprite()
        {
            return new BlockSprites.BlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 16,
                layerDepth: DefaultSpriteLayerDepths.BlocksLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateStatueOneEntranceSprite()
        {
            return new BlockSprites.BlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 32,
                layerDepth: DefaultSpriteLayerDepths.BlocksLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateStatueTwoEntranceSprite()
        {
            return new BlockSprites.BlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 48,
                layerDepth: DefaultSpriteLayerDepths.BlocksLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateStatueOneEndSprite()
        {
            return new BlockSprites.BlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 64,
                layerDepth: DefaultSpriteLayerDepths.BlocksLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateStatueTwoEndSprite()
        {
            return new BlockSprites.BlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 80,
                layerDepth: DefaultSpriteLayerDepths.BlocksLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateBlackSquareSprite()
        {
            return new BlockSprites.BlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 96,
                layerDepth: DefaultSpriteLayerDepths.BlocksLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateBlueSandSprite()
        {
            return new BlockSprites.BlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 112,
                layerDepth: DefaultSpriteLayerDepths.BlocksLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateBlueGapSprite()
        {
            return new BlockSprites.BlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 128,
                layerDepth: DefaultSpriteLayerDepths.BlocksLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateStairsSprite()
        {
            return new BlockSprites.BlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 144,
                layerDepth: DefaultSpriteLayerDepths.BlocksLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateWhiteBrickSprite()
        {
            return new BlockSprites.BlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 160,
                layerDepth: DefaultSpriteLayerDepths.BlocksLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateWhiteLadderSprite()
        {
            return new BlockSprites.BlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 176,
                layerDepth: DefaultSpriteLayerDepths.BlocksLayer,
                scale: Constants.UniversalScale);
        }
    }
}
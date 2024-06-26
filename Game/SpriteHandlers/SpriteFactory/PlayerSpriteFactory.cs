﻿using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MainGame.SpriteHandlers
{
    public static partial class SpriteFactory
    {
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
                layerDepth: DefaultSpriteLayerDepths.PlayerLayer,
                scale: Constants.UniversalScale);
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
                layerDepth: DefaultSpriteLayerDepths.PlayerLayer,
                scale: Constants.UniversalScale);
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
                layerDepth: DefaultSpriteLayerDepths.PlayerLayer,
                scale: Constants.UniversalScale);
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
                layerDepth: DefaultSpriteLayerDepths.PlayerLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreatePlayerWalkingDownSprite()
        {
            return new PlayerSprites.PlayerWalkingDownSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                numberOfFrames: 2,
                textureStartingY: 0,
                layerDepth: DefaultSpriteLayerDepths.PlayerLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreatePlayerWalkingUpSprite()
        {
            return new PlayerSprites.PlayerWalkingUpSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                numberOfFrames: 2,
                textureStartingY: 16,
                layerDepth: DefaultSpriteLayerDepths.PlayerLayer,
                scale: Constants.UniversalScale);
        }


        public static ISprite CreatePlayerWalkingLeftSprite()
        {
            return new PlayerSprites.PlayerWalkingLeftSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                numberOfFrames: 2,
                textureStartingY: 32,
                layerDepth: DefaultSpriteLayerDepths.PlayerLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreatePlayerWalkingRightSprite()
        {
            return new PlayerSprites.PlayerWalkingRightSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                numberOfFrames: 2,
                textureStartingY: 32,
                layerDepth: DefaultSpriteLayerDepths.PlayerLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreatePlayerHoldingItemSprite()
        {
            return new PlayerSprites.PlayerHoldingItemSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                textureStartingY: 128,
                layerDepth: DefaultSpriteLayerDepths.PlayerLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreatePlayerHoldingTriforceSprite()
        {
            return new PlayerSprites.PlayerHoldingItemSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                textureStartingY: 144,
                layerDepth: DefaultSpriteLayerDepths.PlayerLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreatePlayerInteractingDownSprite()
        {
            return new PlayerSprites.PlayerInteractingDownSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                textureStartingY: 48,
                layerDepth: DefaultSpriteLayerDepths.PlayerLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreatePlayerInteractingUpSprite()
        {
            return new PlayerSprites.PlayerInteractingUpSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                textureStartingY: 96,
                layerDepth: DefaultSpriteLayerDepths.PlayerLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreatePlayerInteractingLeftSprite()
        {
            return new PlayerSprites.PlayerInteractingLeftSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                textureStartingY: 112,
                layerDepth: DefaultSpriteLayerDepths.PlayerLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreatePlayerInteractingRightSprite()
        {
            return new PlayerSprites.PlayerInteractingRightSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                textureStartingY: 112,
                layerDepth: DefaultSpriteLayerDepths.PlayerLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreatePlayerIdleDownSprite()
        {
            return new PlayerSprites.PlayerIdleDownSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                textureStartingY: 0,
                layerDepth: DefaultSpriteLayerDepths.PlayerLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreatePlayerIdleUpSprite()
        {
            return new PlayerSprites.PlayerIdleUpSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                textureStartingY: 16,
                layerDepth: DefaultSpriteLayerDepths.PlayerLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreatePlayerIdleLeftSprite()
        {
            return new PlayerSprites.PlayerIdleLeftSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                textureStartingY: 32,
                layerDepth: DefaultSpriteLayerDepths.PlayerLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreatePlayerIdleRightSprite()
        {
            return new PlayerSprites.PlayerIdleRightSprite(
                TextureMap["LinkSprites"], SpriteBatch,
                textureStartingY: 32,
                layerDepth: DefaultSpriteLayerDepths.PlayerLayer,
                scale: Constants.UniversalScale);
        }
    }
}

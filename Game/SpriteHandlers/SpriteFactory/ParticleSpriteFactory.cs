using System;
using MainGame.SpriteHandlers.ItemSprites;

namespace MainGame.SpriteHandlers
{
    public enum ParticleSpriteTypes
    {

    }

    public static partial class SpriteFactory
    {


        public static ISprite CreateDeathParticles()
        {


            return new ParticleSprites.DeathParticles(
                TextureMap["ParticleSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                frameHeight: 16,
                frameWidth: 16,
                scale: Constants.UniversalScale) ;
        }



        public static ISprite CreateSwordBeamParticles()
        {
            return new ParticleSprites.SwordBeamParticles(
                TextureMap["ParticleSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                numberOfFrames: 4,
                textureStartingY: 18,               
                frameHeight: 8,
                frameWidth: 8,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateSpawnParticles()
        {

            return new ParticleSprites.SpawnParticles(
                TextureMap["ParticleSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 3,
                numberOfFrames: 3,
                 textureStartingY: 32,
                frameHeight: 16,
                frameWidth: 16,
                scale: Constants.UniversalScale);
        }
    }
}

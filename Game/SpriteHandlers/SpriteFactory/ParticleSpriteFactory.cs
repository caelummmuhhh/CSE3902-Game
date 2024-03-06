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
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,

                // real values needed just setting up a framework
                frameHeight: 69,
                frameWidth: 420,
                scale: UniversalScaleMultiplier) ;
        }



        public static ISprite CreateSwordBeamParticles()
        {
            return new ParticleSprites.DeathParticles(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,

                // real values needed just setting up a framework
                frameHeight: 69,
                frameWidth: 420,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateSpawnParticles()
        {

            return new ParticleSprites.DeathParticles(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,

                // real values needed just setting up a framework
                frameHeight: 69,
                frameWidth: 420,
                scale: UniversalScaleMultiplier);
        }
    }
}

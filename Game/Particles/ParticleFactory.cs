using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Particles
{
	public static class ParticleFactory
	{
		public static IParticle GetDeathParticle(Vector2 position)
			=> new GenericParticle(position, SpriteFactory.CreateDeathParticle());

        public static IParticle GetSpawnParticle(Vector2 position)
            => new GenericParticle(position, SpriteFactory.CreateSpawnParticle());

        public static IParticle GetSwordBeamExplodingParticles(Vector2 position)
            => new SwordBeamExplodingParticles(position);
    }
}


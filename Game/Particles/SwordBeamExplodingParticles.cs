using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Particles
{

	public class SwordBeamExplodingParticles : IParticle
	{
        protected internal class SwordBeamParticle
        {
            public readonly Direction Direction;
            public Vector2 Position;
            public readonly ISprite Sprite;

            protected internal SwordBeamParticle(Direction direction, Vector2 position, ISprite sprite)
            {
                Direction = direction;
                Position = position;
                Sprite = sprite;
            }
        }

        public bool IsActive { get; set; }

        private readonly int particleMoveSpeed = GameConstants.SwordBeamParticleMoveSpeed;
        private int particleLifetime = GameConstants.SwordBeamParticleLifetime;        
        private readonly List<SwordBeamParticle> particles = new();

        public SwordBeamExplodingParticles(Vector2 position)
		{
            position = new(position.X, position.Y);
            IsActive = true;
            Direction[] wantedDirections = { Direction.NorthEast, Direction.NorthWest, Direction.SouthEast, Direction.SouthWest };
            foreach (Direction direction in wantedDirections)
            {
                particles.Add(new SwordBeamParticle(direction, position, SpriteFactory.CreateSwordBeamParticle(direction)));
            }
		}

        public void Update()
        {
            for (int i = 0; i < particles.Count; i++)
            {
                SwordBeamParticle particle = particles[i];
                particle.Sprite.Update();
                particle.Position = Utils.DirectionalMove(particle.Position, particle.Direction, particleMoveSpeed);
            }

            IsActive = particleLifetime > 0;
            particleLifetime--;
        }

        public void Draw()
        {
            foreach (SwordBeamParticle particle in particles)
            {
                particle.Sprite.Draw(particle.Position.X, particle.Position.Y, Color.White);
            }
        }
    }
}

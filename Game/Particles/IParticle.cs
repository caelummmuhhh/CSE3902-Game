using Microsoft.Xna.Framework;

namespace MainGame.Particles
{
    public interface IParticle
    {
        public bool IsActive { get; }

        public void Update();
        public void Draw();
    }
}

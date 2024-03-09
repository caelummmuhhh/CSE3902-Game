using MainGame.Players.PlayerStates;
using MainGame.SpriteHandlers;
using MainGame.SpriteHandlers.ParticleSprites;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MainGame.Particles
{
    public class Particle : IParticle
    {
        public ISprite Part;
        private readonly Game1 game;
        public Particle(Game1 game)
        {
          
           
            Part = SpriteFactory.CreateSpawnParticles();
            this.game = game;
        }
       
        public void Draw()
        {
            Part.Draw(game.GraphicsManager.PreferredBackBufferWidth / 4, game.GraphicsManager.PreferredBackBufferHeight / 4, Color.White);
        }

        public void Update()
        {
            Part.Update();
        }
    }
}

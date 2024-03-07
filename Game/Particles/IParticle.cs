using MainGame.SpriteHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace MainGame.Particles
{
    public interface IParticle
    {
        

        public void Update();
        public void Draw();
    }
}

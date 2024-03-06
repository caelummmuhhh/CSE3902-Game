using MainGame.SpriteHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace MainGame.Particles
{
    internal interface IParticle
    {
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }

        public void Update();
        public void Draw();
    }
}

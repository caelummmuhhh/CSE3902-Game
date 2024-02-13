using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGame.SpriteHandlers.Factory
{
    public interface IFactory
    {
        public ISprite createSprite(GraphicsDevice graphicsDevice);
    }
}

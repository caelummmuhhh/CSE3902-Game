using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace MainGame.StartScreen
{

    public class StartScreen
    {
        private readonly ISprite sprite;
        Game1 game;
        public StartScreen(Game1 game)
        {
            this.game = game;
            sprite = SpriteFactory.CreateStartScreenSprite();
        }

        public void Update()
        {

        }

        public void Draw()
        {
            sprite.Draw(0, 0, Color.White);
        }
    }
}

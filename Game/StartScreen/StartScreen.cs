using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace MainGame.StartScreen
{

    public class StartScreen
    {
        private readonly Dictionary<ISprite, Vector2> Sprites = new();
        private Vector2 ScrollVelocity;

        Game1 game;

        public StartScreen(Game1 game)
        {
            this.game = game;
            Sprites.Add(SpriteFactory.CreateStartScreenSprite(), new Vector2(0,0));
            //Sprites.Add(SpriteFactory.CreateStartScreenTextSprite(5), new Vector2(0,0));
            ScrollVelocity = Vector2.Zero;
        }

        public void StartScreenScroll()
        {
            Sprites.Clear(); // Remove the start page
            ScrollVelocity = new Vector2(0, -Constants.RoomScrollingSpeed);
            // Add all pages and locations to draw map
            // I know this is not the best way to do it as draws all the pages even if they are not in the screen but I don't really have time 
            // to fix rn
            for (int i = 1; i <= 8; i++)
            {
                Sprites.Add(SpriteFactory.CreateStartScreenTextSprite(i), new Vector2(0, i*Constants.ScreenSize.Y));
            }
        }


        public void Update()
        {
            foreach (ISprite sprite in Sprites.Keys)
            {
                Sprites[sprite] += ScrollVelocity;
                Vector2 location = Sprites[sprite];
                if(location.Y < -Constants.ScreenSize.Y) // The Page is off the screen
                {
                    Sprites.Remove(sprite);
                }

                sprite.Update();
            }
            if(Sprites.Count == 0) // Start the game
            {
                game.StartScreenToggle = false;
            }
        }

        public void Draw()
        {
            foreach(ISprite sprite in Sprites.Keys)
            {
                Vector2 location = Sprites[sprite];
                sprite.Draw(location.X, location.Y, Color.White);
            }
        }
    }
}

using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGame.Rooms
{
    public class Room
    {
        public ISprite Sprite;
        public Vector2 Position;
        private readonly Game game;

        public Room(ISprite sprite, Game game)
        {
            Position = new Vector2(0, 0);
            Sprite = sprite;
            this.game = game;

        }

        public void Update()
        {
            Sprite.Update();

        }

        public void Draw()
        {
            Sprite.Draw(Position.X, Position.Y, Color.White);
        }

    }
}

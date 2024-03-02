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
        public ISprite OuterBorder;
        public ISprite InnerBorder;
        public ISprite Tiles;
        public Vector2 Position;
        private readonly Game game;

        public Room(ISprite outerBorder, ISprite innerBorder, ISprite tiles, Game game)
        {
            Position = new Vector2(0, 0);
            OuterBorder = outerBorder;
            InnerBorder = innerBorder;
            Tiles = tiles;
            this.game = game;

        }

        public void Update()
        {
            OuterBorder.Update();
            InnerBorder.Update();
            Tiles.Update();

        }

        public void Draw()
        {
            OuterBorder.Draw(Position.X, Position.Y, Color.White, 0.0f);
            InnerBorder.Draw(Position.X, Position.Y, Color.White, 1.0f);
            Tiles.Draw(Position.X, Position.Y, Color.White, 1.0f);
        }

    }
}

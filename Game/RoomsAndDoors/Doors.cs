using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGame.Doors
{
    public class Door
    {
        public ISprite SpriteTop;
        public ISprite SpriteBottom;
        public Vector2 Position;
        private readonly Game game;
        public enum dir { North, South, West, East };
        public dir Direction;
        public int BottomXOffset = 0;
        public int BottomYOffset = 0;

        public Door(Vector2 position, ISprite spriteTop, ISprite spriteBottom, String direction,Game game)
        {
            Position = position;
            SpriteTop = spriteTop;
            SpriteBottom = spriteBottom;
            Direction = (dir)Enum.Parse(typeof(dir), direction);
            this.game = game;
            if (Direction == dir.North)
            {
                BottomYOffset = 48;
            }
            else if (Direction == dir.South)
            {
                BottomYOffset = -48;
            }
            else if (Direction == dir.West)
            {
                BottomXOffset = 48;
            }
            else if (Direction == dir.East)
            {
                BottomXOffset = -48;
            }
        }

        public void Update()
        {
            SpriteTop.Update();
            SpriteBottom.Update();

        }

        public void Draw()
        {
            SpriteTop.Draw(Position.X, Position.Y, Color.White, 0.0f);
            SpriteBottom.Draw(Position.X + BottomXOffset, Position.Y + BottomYOffset, Color.White, 1.0f);

        }

    }
}

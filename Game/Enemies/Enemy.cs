using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using MainGame.SpriteHandlers.EnemySprites;

namespace MainGame.Enemies
{
    public class Enemy
    {
        public ISprite Sprite;
        public Vector2 Position;
        public float VerticalSpeed = 5f;
        public float HorizontalSpeed = 4f;
        public static bool cd = true;
        public static int dir = 0;
        public float xMax;
        public float yMax;

        private readonly Game game;
        private bool movingLeft;
        private bool movingDown;

        public bool VerticalMotionOn;
        public bool HorizontalMotionOn;
       

        public Enemy(Vector2 position, ISprite sprite, Game game)
        {
            Position = position;
            Sprite = sprite;
            this.game = game;

            movingLeft = false;
            movingDown = false;
            VerticalMotionOn = false;
            HorizontalMotionOn = false;
        }

        public void Update()
        {
            Sprite.Update();
            
                if (VerticalMotionOn) { InfiniteFall(); }
            if (HorizontalMotionOn) { HorizontalBounce(); }
        }

        public void Draw()
        {
            Sprite.Draw(Position.X, Position.Y, Color.White, VerticalSpeed, VerticalSpeed);
        }

        public void MoveUp()
        {
            Position = new Vector2(Position.X, Position.Y - VerticalSpeed);
        }

        public void MoveDown()
        {
            Position = new Vector2(Position.X, Position.Y + VerticalSpeed);
        }

        public void MoveLeft()
        {
            Position = new Vector2(Position.X - HorizontalSpeed, Position.Y);
        }

        public void MoveRight()
        {
            Position = new Vector2(Position.X + HorizontalSpeed, Position.Y);
        }

        public void HorizontalBounce()
        {
            if (Position.X < 27)
            {
                movingLeft = false;
            }
            else if (Position.X > game.GraphicsDevice.Viewport.Width - 27)
            {
                movingLeft = true;
            }

            if (movingLeft) { MoveLeft(); }
            else { MoveRight(); }
        }

        public void InfiniteFall()
        {
            movingDown = true;
            MoveDown();
            if (Position.Y > game.GraphicsDevice.Viewport.Height +14)
            {
                Position = new Vector2(Position.X, 0);
            }
        }
    
}
}

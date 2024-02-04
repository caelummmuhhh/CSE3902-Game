using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MainGame.SpriteHandlers;
using MainGame.Players;

namespace MainGame.Commands
{
	public class MovingStaticSpriteCommand : ICommand
    {
        private Game game;
        private Player player;

        public MovingStaticSpriteCommand(Game game, Player player)
        {
            this.game = game;
            this.player = player;
        }

        public void Execute()
        {
            if (player.Sprite is not PlayerStaticFallingSprite)
            {
                player.Sprite = SpriteFactory.CreatePlayerStaticFallingSprite();
                UnExecute();
            }
            player.HorizontalMotionOn = false;
            player.VerticalMotionOn = true;
        }

        public void UnExecute()
        {
            player.Position = new Vector2(
                game.GraphicsDevice.Viewport.Width / 2,
                game.GraphicsDevice.Viewport.Height / 2
            );
        }
    }
}


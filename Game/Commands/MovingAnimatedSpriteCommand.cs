using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MainGame.SpriteHandlers;
using MainGame.Players;

namespace MainGame.Commands
{
	public class MovingAnimatedSpriteCommand : ICommand
    {
        private Game game;
        private Player player;
        private bool movingLeft;

        public MovingAnimatedSpriteCommand(Game game, Player player)
		{
            this.game = game;
            this.player = player;
            movingLeft = false;
        }

        public void Execute()
        {
            if (player.Sprite is not PlayerAnimatedWalkingSprite)
            {
                player.Sprite = SpriteFactory.CreatePlayerAnimatedWalkingSprite();
                UnExecute();
            }
            player.HorizontalMotionOn = true;
            player.VerticalMotionOn = false;

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


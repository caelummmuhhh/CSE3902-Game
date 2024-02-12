using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MainGame.SpriteHandlers;
using MainGame.Players;

namespace MainGame.Commands
{
    internal class linkMovingUpCommand : ICommand
    {
        private Game game;
        private Player player;

        public linkMovingUpCommand(Game game, Player player)
        {
            this.game = game;
            this.player = player;

        }

        public void Execute()
        {
            player.movingDown = false;
            player.movingLeft = false;
            player.movingRight = false;
            player.movingUp = true;

            player.Sprite = SpriteFactory.CreateLinkUpSprite(game.GraphicsDevice);
        }

        public void UnExecute()
        {
            player.movingUp = false;
        }
    }
}

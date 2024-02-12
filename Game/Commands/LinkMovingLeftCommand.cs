using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MainGame.SpriteHandlers;
using MainGame.Players;

namespace MainGame.Commands
{
    internal class linkMovingLeftCommand : ICommand
    {
        private Game game;
        private Player player;

        public linkMovingLeftCommand(Game game, Player player)
        {
            this.game = game;
            this.player = player;

        }

        public void Execute()
        {
            player.movingDown = false;
            player.movingLeft = true;
            player.movingRight = false;
            player.movingUp = false;

            player.Sprite = SpriteFactory.CreateLinkLeftSprite(game.GraphicsDevice);
        }

        public void UnExecute()
        {
            player.movingLeft = false;
        }
    }
}

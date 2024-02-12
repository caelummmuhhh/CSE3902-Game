using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MainGame.SpriteHandlers;
using MainGame.Players;

namespace MainGame.Commands
{
    internal class linkMovingRightCommand : ICommand
    {
        private Game game;
        private Player player;

        public linkMovingRightCommand(Game game, Player player)
        {
            this.game = game;
            this.player = player;

        }

        public void Execute()
        {
            player.movingDown = false;
            player.movingLeft = false;
            player.movingRight = true;
            player.movingUp = false;

            player.Sprite = SpriteFactory.CreateLinkRightSprite(game.GraphicsDevice);
        }

        public void UnExecute()
        {
            player.movingRight = false;
        }
    }
}

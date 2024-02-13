using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MainGame.SpriteHandlers;
using MainGame.Players;

namespace MainGame.Commands
{
    internal class linkMovingDownCommand : ICommand
    {
        private Game game;
        private Player player;

        public linkMovingDownCommand(Game game, Player player)
        {
            this.game = game;
            this.player = player;

        }

        public void Execute()
        {
            if (!player.movingDown) // If the player was already moving in this direction dont reassign everything
            {
                player.movingDown = true;
                player.movingLeft = false;
                player.movingRight = false;
                player.movingUp = false;

                player.Sprite = SpriteFactory.CreateLinkDownSprite(game.GraphicsDevice);
            }
        }

        public void UnExecute()
        {
            player.movingDown = false;
        }
    }
}

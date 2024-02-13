using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MainGame.Players;
using MainGame.SpriteHandlers;

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
            if (!player.movingUp) // If the player was already moving in this direction dont reassign everything
            {
                player.movingDown = false;
                player.movingLeft = false;
                player.movingRight = false;
                player.movingUp = true;

                player.Sprite = SpriteFactory.getSprite("LinkUpSprite", game.GraphicsDevice);
            }
        }

        public void UnExecute()
        {
            player.movingUp = false;
        }
    }
}

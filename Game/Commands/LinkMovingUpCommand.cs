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
            if (player.direction != MovementDirection.UP) // If the player was already moving in this direction dont reassign everything
            {
                player.direction = MovementDirection.UP;

                player.Sprite = SpriteFactory.getSprite("LinkUpSprite", game.GraphicsDevice);
            }
        }

        public void UnExecute()
        {
            if (player.direction == MovementDirection.UP)
            {
                player.direction = MovementDirection.NONE;
            }
        }
    }
}

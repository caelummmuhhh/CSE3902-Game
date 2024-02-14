using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MainGame.Players;
using MainGame.SpriteHandlers;

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
            if (player.direction != MovementDirection.DOWN) // If the player was already moving in this direction dont reassign everything
            {
                player.direction = MovementDirection.DOWN;

                player.Sprite = SpriteFactory.getSprite("LinkDownSprite", game.GraphicsDevice);
            }
        }

        public void UnExecute()
        {
            if(player.direction == MovementDirection.DOWN)
            {
                player.direction = MovementDirection.NONE;
            }
        }
    }
}

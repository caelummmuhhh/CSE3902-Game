using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MainGame.Players;
using MainGame.SpriteHandlers;

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
            if (player.direction != MovementDirection.RIGHT) // If the player was already moving in this direction dont reassign everything
            {
                player.direction = MovementDirection.RIGHT;

                player.Sprite = SpriteFactory.getSprite("LinkRightSprite", game.GraphicsDevice);
            }
        }

        public void UnExecute()
        {
            if (player.direction == MovementDirection.RIGHT)
            {
                player.direction = MovementDirection.NONE;
            }
        }
    }
}

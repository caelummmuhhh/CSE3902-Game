using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MainGame.Players;
using MainGame.SpriteHandlers;

namespace MainGame.Commands
{
    internal class AttackUsingSwordCommand : ICommand
    {
        private Game game;
        private Player player;
        private int ticksSinceStart;

        public AttackUsingSwordCommand(Game game, Player player)
        {
            this.game = game;
            this.player = player;
            ticksSinceStart = 0;
        }

        public void Execute()
        {
            player.usingSword = true;
            // Select the sprite based on the direction of movment
            switch (player.direction){
                case MovementDirection.UP: player.Sprite = SpriteFactory.getSprite("LinkUpSpriteWithSword", game.GraphicsDevice); break;
                case MovementDirection.DOWN: player.Sprite = SpriteFactory.getSprite("LinkDownSpriteWithSword", game.GraphicsDevice); break;
                case MovementDirection.LEFT: player.Sprite = SpriteFactory.getSprite("LinkLeftSpriteWithSword", game.GraphicsDevice); break;
                case MovementDirection.RIGHT: player.Sprite = SpriteFactory.getSprite("LinkRightSpriteWithSword", game.GraphicsDevice); break;
                default: break;
            }
        }

        public void UnExecute()
        {
            if(ticksSinceStart > 4)
            {
                player.usingSword = false;
                ticksSinceStart = 0;
            }
            else
            {
                ticksSinceStart++;
            }
        }
    }
}

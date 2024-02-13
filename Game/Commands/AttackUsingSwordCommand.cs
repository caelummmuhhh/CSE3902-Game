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

        public AttackUsingSwordCommand(Game game, Player player)
        {
            this.game = game;
            this.player = player;
        }

        public void Execute()
        {
            player.usingSword = true;
            player.Sprite = SpriteFactory.getSprite("LinkDownSprite", game.GraphicsDevice);
            
        }

        public void UnExecute()
        {
            player.usingSword = false;
        }
    }
}

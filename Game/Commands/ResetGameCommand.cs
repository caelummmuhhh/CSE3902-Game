﻿using MainGame.Blocks;
using MainGame.Controllers;
using MainGame.Enemies;
using MainGame.Items;
using MainGame.Managers;
using MainGame.Players;
using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGame.Commands
{
    public class ResetGameCommand : ICommand
    {
        private readonly Game1 game;
        public ResetGameCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.controllers.Clear();

            game.Player = new Player(game);
            game.Enemy = new Enemy(new Vector2(game.GraphicsManager.PreferredBackBufferWidth / 2,
            game.GraphicsManager.PreferredBackBufferHeight / 2), SpriteFactory.CreateGelSprite(), game);

            game.controllers.Add(new KeyboardController(game, game.Player, game.Block, game.blockManager.GetBlocks(), game.Item, game.itemManager.GetItems()));
            game.controllers.Add(new MouseController(game, game.Player));
        }

        public void UnExecute()
        {
            // Not needed
        }
    }
}
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Collections.Generic;

using MainGame.SpriteHandlers;
using MainGame.Players;
using MainGame.Blocks;

namespace MainGame.Commands.RoomSwitchingCommands
{
    public class EastRoomCommand : ICommand
    {
        Game1 game;
        public EastRoomCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.RoomManager.GetEastRoom();
        }

        public void UnExecute()
        { 

        }
    }
}
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
    public class WestRoomCommand : ICommand
    {
        Game1 game;
        public WestRoomCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Room = game.Room.getWestRoom();
        }

        public void UnExecute()
        { 

        }
    }
}
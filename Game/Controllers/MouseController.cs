using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MainGame.Commands;
using MainGame.Players;
using MainGame.SpriteHandlers;
using MainGame.Rooms;
using MainGame.Doors;

namespace MainGame.Controllers
{
	public class MouseController : IController
	{
        private readonly IPlayer player;
        private readonly Game game;
        private readonly int screenWidth;
        private readonly int screenHeight;
        private readonly Dictionary<MouseButton, ICommand> mouseCommands;
        MouseState previousMouseState;
        public enum MouseButton
        {   
            Left,
            Right
        }   
        public MouseController(Game game, IPlayer player, Room room, Door NorthDoor, Door SouthDoor, Door WestDoor, Door EastDoor)
		{
            this.game = game;
            this.player = player;

            screenWidth = game.GraphicsDevice.Viewport.Width;
            screenHeight = game.GraphicsDevice.Viewport.Height;
            mouseCommands = new Dictionary<MouseButton, ICommand>
            {
                { MouseButton.Left, new NextRoomCommand(game, player, room, NorthDoor, SouthDoor, WestDoor, EastDoor) },
                { MouseButton.Right, new PreviousRoomCommand(game, player, room, NorthDoor, SouthDoor, WestDoor, EastDoor) }
            };
        }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();
            ICommand command = null;

            MouseState currentMouseState = Mouse.GetState();

            if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
            {
                mouseCommands[MouseButton.Left].Execute();
            }
            else if (currentMouseState.RightButton == ButtonState.Pressed && previousMouseState.RightButton == ButtonState.Released)
            {
                mouseCommands[MouseButton.Right].Execute();
            }
            previousMouseState = currentMouseState;
        }
    }
}

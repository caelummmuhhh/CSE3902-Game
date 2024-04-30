using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

using MainGame.Commands;
using System;

namespace MainGame.Controllers;
public class MenuKeyboardController : IController
{
    private readonly Dictionary<Keys, ICommand> menuCommands;
    private int debounce = 15;

    public MenuKeyboardController(Game1 game, MenuGameState gameState)
    {
        menuCommands = new()
        {
            { Keys.W, new NextShaderCommand(gameState) },
            { Keys.Escape, new SwitchToPlayStateCommand(game) }
        };
    }

    public void Update()
    {
        if (debounce > 0)
        {
            debounce--;
            return;
        }
        debounce = 10;
        KeyboardState keyState = Keyboard.GetState();
        foreach (Keys key in menuCommands.Keys)
        {
            if (keyState.IsKeyDown(key))
            {
                Console.WriteLine($"In menu state. Switching to game state");
                menuCommands[key].Execute();
            }
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MainGame.SpriteHandlers;
using MainGame.Controllers;
using MainGame.Players;
using System.Collections.Generic;

namespace MainGame;

public class Game1 : Game
{
    public readonly GraphicsDeviceManager GraphicsManager;
    private SpriteBatch spriteBatch;
    private List<IController> controllers;

    private ISprite textSprite;
    public Player Player;

    public Game1()
    {
        GraphicsManager = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        controllers = new List<IController>();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        SpriteFactory.LoadAllTextures(Content);
        SpriteFactory.SpriteBatch = spriteBatch;

        textSprite = SpriteFactory.CreateTextSprite("hello world!");
        Player = new Player(this);

        controllers.Add(new KeyboardController(this, Player));
        controllers.Add(new MouseController(this, Player));
    }

    protected override void Update(GameTime gameTime)
    {

        foreach (IController controller in controllers)
        {
            controller.Update();
        }

        Player.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Indigo);

        Player.Draw();
        textSprite.Draw(10, GraphicsManager.PreferredBackBufferHeight - 100, Color.Black);

        base.Draw(gameTime);
    }
}


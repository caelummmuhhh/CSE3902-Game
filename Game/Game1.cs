using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MainGame.SpriteHandlers;
using MainGame.Controllers;
using MainGame.Players;
using System.Collections.Generic;
using MainGame.Enemies;

namespace MainGame;

public class Game1 : Game
{
    // i will explain...
    public int counter;
    public readonly GraphicsDeviceManager GraphicsManager;
    private SpriteBatch spriteBatch;
    private List<IController> controllers;

    private ISprite textSprite;
    public Player Player;
    public Enemy Enemy;
    // test comment, having issues with git

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
        Player = new Player(
            new Vector2(GraphicsManager.PreferredBackBufferWidth / 2,
                GraphicsManager.PreferredBackBufferHeight / 2),
            SpriteFactory.CreatePlayerStaticIdleSprite(),
            this
        );
        Enemy = new Enemy(new Vector2(GraphicsManager.PreferredBackBufferWidth / 2,
                GraphicsManager.PreferredBackBufferHeight / 2), SpriteFactory.CreateGelSprite(), this);;

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
        Enemy.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Indigo);

        Player.Draw();
        Enemy.Draw();
        textSprite.Draw(10, GraphicsManager.PreferredBackBufferHeight - 100, Color.Black, GraphicsManager.GraphicsDevice.Viewport.Width - 27, GraphicsManager.GraphicsDevice.Viewport.Height + 14);

        base.Draw(gameTime);
    }
}


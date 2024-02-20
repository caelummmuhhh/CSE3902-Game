using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MainGame.SpriteHandlers;
using MainGame.Controllers;
using MainGame.Players;
using MainGame.Blocks;
using MainGame.Items;
using System.Collections.Generic;
using MainGame.Enemies;


using MainGame.Managers;

namespace MainGame;

public class Game1 : Game
{
    // i will explain...
    public int counter;
    public readonly GraphicsDeviceManager GraphicsManager;
    private SpriteBatch spriteBatch;
    private List<IController> controllers;

    private ISprite textSprite;
    public IPlayer Player;

    public Block Block;
    public Item Item;

    private BlockManager blockManager;
    private ItemManager itemManager;

    public Game1()
    {
        GraphicsManager = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        TargetElapsedTime = TimeSpan.FromSeconds(1d / 30d);
    }

    protected override void Initialize()
    {
        controllers = new List<IController>();
        blockManager = new BlockManager();
        itemManager = new ItemManager();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        SpriteFactory.LoadAllTextures(Content);
        SpriteFactory.SpriteBatch = spriteBatch;

        textSprite = SpriteFactory.CreateTextSprite("hello world!");
        Player = new Player(this);

        blockManager.LoadBlocks();
        itemManager.LoadItems();
        Block =  new Block(
            new Vector2(GraphicsManager.PreferredBackBufferWidth / 3,
                GraphicsManager.PreferredBackBufferHeight / 3),
            blockManager.GetBlocks()[0],
            this
        );
        Item = new Item(
            new Vector2(GraphicsManager.PreferredBackBufferWidth / 3*2,
                GraphicsManager.PreferredBackBufferHeight / 3),
            itemManager.GetItems()[0],
            this
        );
        Enemy = new Enemy(new Vector2(GraphicsManager.PreferredBackBufferWidth / 2,
                GraphicsManager.PreferredBackBufferHeight / 2), SpriteFactory.CreateGelSprite(), this);;

        controllers.Add(new KeyboardController(this, Player, Block, blockManager.GetBlocks(), Item, itemManager.GetItems()));
        controllers.Add(new MouseController(this, Player));
    }

    protected override void Update(GameTime gameTime)
    {

        foreach (IController controller in controllers)
        {
            controller.Update();
        }

        Player.Update();
        Block.Update();
        Item.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Indigo);

        Player.Draw();
        Enemy.Draw();
        textSprite.Draw(10, GraphicsManager.PreferredBackBufferHeight - 100, Color.Black);
        Block.Draw();
        Item.Draw();

        base.Draw(gameTime);
    }
}

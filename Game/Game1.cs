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
using System;

namespace MainGame;

public class Game1 : Game
{
    // i will explain...
    public int counter;
    public readonly GraphicsDeviceManager GraphicsManager;
    private SpriteBatch spriteBatch;
    public List<IController> controllers;

    public IPlayer Player;

    public Block Block;
    public Item Item;

    public Enemy Enemy;

    public BlockManager blockManager;
    public ItemManager itemManager;

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
        for (int i = 0; i < controllers.Count; i++)
        {
            controllers[i].Update();
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
        Block.Draw();
        Item.Draw();

        base.Draw(gameTime);
    }
}

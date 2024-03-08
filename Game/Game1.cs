using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MainGame.SpriteHandlers;
using MainGame.Controllers;
using MainGame.Players;
using MainGame.Rooms;
using MainGame.Doors;
using MainGame.Blocks;
using MainGame.Items;
using System.Collections.Generic;
using MainGame.Enemies;

using MainGame.Managers;
using System;
using MainGame.RoomsAndDoors;

namespace MainGame;

public class Game1 : Game
{
    public readonly GraphicsDeviceManager GraphicsManager;
    private SpriteBatch spriteBatch;
    public List<IController> controllers;

    public IPlayer Player;

    public Room Room;



    public HashSet<Block> Blocks;
    public HashSet<Item> Items;
    public BlockManager blockManager;
    public ItemManager itemManager;

    public Game1()
    {
        GraphicsManager = new GraphicsDeviceManager(this);

        GraphicsManager.PreferredBackBufferWidth = 768;
        GraphicsManager.PreferredBackBufferHeight = 528;  //768 in sprint 4+

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        TargetElapsedTime = TimeSpan.FromSeconds(1d / 30d);
    }

    protected override void Initialize()
    {
        controllers = new List<IController>();
        blockManager = new BlockManager();
        itemManager = new ItemManager();
        Blocks = new HashSet<Block>();
        Items = new HashSet<Item>();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        SpriteFactory.LoadAllTextures(Content);
        SpriteFactory.SpriteBatch = spriteBatch;
        blockManager.LoadBlocks();
        itemManager.LoadItems();

        Player = new Player(this);

        Room = RoomFactory.GenerateRoom("Room_1", this);

        controllers.Add(new KeyboardController(this, Player, null, blockManager.GetBlocks(), null, itemManager.GetItems()));
        controllers.Add(new MouseController(this, Player));
    }

    protected override void Update(GameTime gameTime)
    {
        for (int i = 0; i < controllers.Count; i++)
        {
            controllers[i].Update();
        }

        Player.Update();
        foreach(Block block in Blocks)
        {
            block.Update();
        }
        foreach(Item item in Items)
        {
            item.Update();
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);

        Room.Draw();

        Player.Draw();
        foreach (Block block in Blocks)
        {
            block.Draw();
        }
        foreach (Item item in Items)
        {
            item.Draw();
        }


        spriteBatch.End();

        base.Draw(gameTime);
    }
}

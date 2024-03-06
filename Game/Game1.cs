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

    public IDoor NorthDoor;
    public IDoor WestDoor;
    public IDoor EastDoor;
    public IDoor SouthDoor;

    public Block Block;
    public Item Item;
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

        RoomFactory.GenerateRoom("Room_13.csv", this);


        /*
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
        */

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

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);

        Room.Draw();
        NorthDoor.Draw();
        SouthDoor.Draw();
        WestDoor.Draw();
        EastDoor.Draw();

        Player.Draw();


        spriteBatch.End();

        base.Draw(gameTime);
    }
}

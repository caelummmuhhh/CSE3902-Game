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

namespace MainGame;

public class Game1 : Game
{
    public readonly GraphicsDeviceManager GraphicsManager;
    private SpriteBatch spriteBatch;
    public List<IController> controllers;

    public IPlayer Player;

    public Room Room;

    public Door NorthDoor;
    public Door WestDoor;
    public Door EastDoor;
    public Door SouthDoor;

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

        Player = new Player(this);

        Room = new Room(
            SpriteFactory.CreateRoomOuterBorderSprite(),
            SpriteFactory.CreateRoomInnerBorderSprite(),
            SpriteFactory.CreateDungeonTilesSprite(),
            this
        );

        NorthDoor = new Door(
            new Vector2(336, 0),
            SpriteFactory.CreateDoorTopNorthSouth("North", "wallNormal"),
            SpriteFactory.CreateDoorBottomNorthSouth("North", "wallNormal"),
            "North",
            this
        );
        SouthDoor = new Door(
            new Vector2(336, 480),
            SpriteFactory.CreateDoorTopNorthSouth("South", "diamondDoor"),
            SpriteFactory.CreateDoorBottomNorthSouth("South", "diamondDoor"),
            "South",
            this
        );
        WestDoor = new Door(
            new Vector2(0, 216),
            SpriteFactory.CreateDoorTopWestEast("West", "destroyedWall"),
            SpriteFactory.CreateDoorBottomWestEast("West", "destroyedWall"),
            "West",
            this
        );
        EastDoor = new Door(
            new Vector2(720, 216),
            SpriteFactory.CreateDoorTopWestEast("East", "openDoor"),
            SpriteFactory.CreateDoorBottomWestEast("East", "openDoor"),
            "East",
            this
        );


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
        GraphicsDevice.Clear(Color.Black);
        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);

        Room.Draw();
        NorthDoor.Draw();
        SouthDoor.Draw();
        WestDoor.Draw();
        EastDoor.Draw();

        Player.Draw();

        Block.Draw();
        Item.Draw();

        spriteBatch.End();

        base.Draw(gameTime);
    }
}

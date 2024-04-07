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
using MainGame.HudAndMenu;
using System.Collections.Generic;
using MainGame.Enemies;
using MainGame.Particles;

using MainGame.Managers;
using System;

using MainGame.SpriteHandlers.ParticleSprites;
using MainGame.RoomsAndDoors;


namespace MainGame;

public class Game1 : Game
{
    public readonly GraphicsDeviceManager GraphicsManager;
    private SpriteBatch spriteBatch;
    public List<IController> controllers;

    public IPlayer Player;
    public GenericEnemy Enemy;

    public Room Room;

    public BlockManager blockManager;
    public ItemManager itemManager;
    public Particle Particle;

    public Hud Hud;
    public Menu Menu;


    public Game1()
    {
        GraphicsManager = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = 768,
            PreferredBackBufferHeight = 696
        };

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        //TargetElapsedTime = TimeSpan.FromSeconds(1d / 30d);
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

        Particle = new Particle(this);

        blockManager.LoadBlocks();
        itemManager.LoadItems();

        Player = new Player(this);
        //Enemy = new GoriyaEnemy(new Vector2(465, 224));
        Enemy = new KeeseEnemy(new Vector2(465, 224));
        //Enemy = new GelEnemy(new Vector2(465, 224));
        //Enemy = new SpikeCrossEnemy(new Vector2(465, 224), Player);
        //Enemy = new StalfosEnemy(new Vector2(465, 224));
        //Enemy = new WallMasterEnemy(new Vector2(465, 224), Player);
        //Enemy = new OldManEnemy(new Vector2(465, 224));
        //Enemy = new AquamentusEnemy(new Vector2(465+3*48, 224+48), Player);

        Room = RoomFactory.GenerateRoom("Room_1", this);

        Hud = new Hud("1", "B", "A", this);
        Menu = new Menu("B", this);

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
        Particle.Update();

        Enemy.Update();
        Room.Update();

        Hud.Update();
        Menu.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);

        Room.Draw();

        Player.Draw();
        Particle.Draw();

        Enemy.Draw();

        Hud.Draw();
        //Menu.Draw();

        spriteBatch.End();

        base.Draw(gameTime);
    }
}

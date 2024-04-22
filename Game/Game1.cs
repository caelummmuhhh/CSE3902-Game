using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

using MainGame.SpriteHandlers;
using MainGame.Controllers;
using MainGame.Players;
using MainGame.Rooms;
using MainGame.Doors;
using MainGame.Blocks;
using MainGame.WorldItems;
using MainGame.HudAndMenu;
using MainGame.Dungeons;
using MainGame.Collision;
using MainGame.Audio;
using MainGame.SpriteHandlers.BlockSprites;
using MainGame.Projectiles;
using MainGame.Enemies;
using System.IO;
using System;
using System.Threading;

namespace MainGame;

public class Game1 : Game
{
    public readonly GraphicsDeviceManager GraphicsManager;
    private SpriteBatch spriteBatch;
    public List<IController> controllers;
    public int TotalGameTime = 0;

    public IPlayer Player;
    public CollisionDetector Collision;
    public GameRoomManager RoomManager;

    public BlockSprite testBlock; // TODO: DELETE ME

    public Dungeon Dungeon;
    public Hud Hud;
    public Menu Menu;

    public bool TogglePause;
    int PauseDebounce;

    public bool TogglePlayer;


    public Game1()
    {
        GraphicsManager = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = 768,
            PreferredBackBufferHeight = 696
        };

        //this.TargetElapsedTime = TimeSpan.FromSeconds(1d / 30d); //60);
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
        TogglePause = false;
        PauseDebounce = 10;

        AudioManager.SetUp(this);

        spriteBatch = new SpriteBatch(GraphicsDevice);

        SpriteFactory.LoadAllTextures(Content);
        SpriteFactory.SpriteBatch = spriteBatch;

        string dungeonName = "Dungeon_1.csv";
        Dungeon = new Dungeon(this, dungeonName);

        RoomManager = new(this);
        Dungeon.PlayerStartingKeys = 1;
        Player = new Player(new Vector2(120 * Constants.UniversalScale, (128 * Constants.UniversalScale) + Constants.HudAndMenuHeight), RoomManager,
            Array.Empty<int>(), Dungeon.PlayerStartingHealth, Dungeon.PlayerStartingRupees, Dungeon.PlayerStartingKeys, Dungeon.PlayerStartingBombs);

        RoomManager.LoadAllRooms(Player);

        Collision = new(this);

        Hud = new Hud(Dungeon.DungeonId, Dungeon.UseItemKey, Dungeon.AttackKey, this);
        Menu = new Menu(Dungeon.UseItemKey, this);

        testBlock = (BlockSprite)SpriteFactory.CreateBlackSquareSprite(); // TODO: DELETE ME

        controllers.Add(new KeyboardController(this, Player));
        controllers.Add(new MouseController(this, Player));
    }

    protected override void Update(GameTime gameTime)
    {
        TotalGameTime++;

        if (PauseDebounce >= 10)
        {
            for (int i = 0; i < controllers.Count; i++)
            {
                controllers[i].Update();
            }
        }
        if (!TogglePause)
        {
            if(!TogglePlayer) Player.Update();
            ++PauseDebounce;
            RoomManager.Update();
            Collision.Update();
            Hud.TogglePauseDisplay(TogglePause);
        } else
        {
            Hud.TogglePauseDisplay(TogglePause);
            Menu.Update();
            ++PauseDebounce;
        }
        Hud.Update();
        // Audio has to be outside to allow pause sounds, will cause bugs with delayed sounds playing on pause screen
        AudioManager.Update();

        base.Update(gameTime);
    }
    public void SetPause()
    {
        TogglePause = !TogglePause;
        PauseDebounce = 0;
    }
    public void SetPlayer()
    {
        TogglePlayer = !TogglePlayer;
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
        if (!TogglePause)
        {
            RoomManager.Draw();
            if(!TogglePlayer) Player.Draw();
        }
        else
        {
            Menu.Draw();
        }

        // Hud always drawn
        Hud.Draw();

        spriteBatch.End();

        base.Draw(gameTime);
    }
}

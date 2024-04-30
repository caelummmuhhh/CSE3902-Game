﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MainGame.SpriteHandlers;
using MainGame.Controllers;
using MainGame.Players;
using MainGame.Rooms;
using MainGame.HudAndMenu;
using MainGame.Dungeons;
using MainGame.Collision;
using MainGame.Audio;
using MainGame.StartScreen;
    using System;

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

    public Dungeon Dungeon;
    public Hud Hud;
    public Menu Menu;

    public StartScreen.StartScreen StartScreen;

    public bool StartScreenToggle { get; set; } = true; // Whether to show start screen or game

    public bool TogglePause { get; set; } = false;
    public bool ToggleEntities { get; set; } = true; // whether or not to update and draw entities
    public bool ToggleControls { get; set; } = true; // turn off controls
    public bool FreezeAllEntities { get; set; } = false; // no update, but draw
    private int PauseDebounce = 10;

    public Game1()
    {
        GraphicsManager = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = (int)Constants.ScreenSize.X,
            PreferredBackBufferHeight = (int)Constants.ScreenSize.Y
        };

        //this.TargetElapsedTime = TimeSpan.FromSeconds(1d / 30d); //60);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        controllers = new List<IController>();

        AudioManager.MuteSong();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        AudioManager.SetUp(this);

        spriteBatch = new SpriteBatch(GraphicsDevice);

        SpriteFactory.LoadAllTextures(Content);
        SpriteFactory.SpriteBatch = spriteBatch;

        string dungeonName = "Dungeon_1.csv";
        Dungeon = new Dungeon(this, dungeonName);

        RoomManager = new(this);
        Player = new Player(new Vector2(120 * Constants.UniversalScale, (128 * Constants.UniversalScale) + Constants.HudAndMenuHeight), RoomManager,
            Array.Empty<int>(), Dungeon.PlayerStartingHealth, Dungeon.PlayerStartingRupees, Dungeon.PlayerStartingKeys, Dungeon.PlayerStartingBombs);

        RoomManager.LoadAllRooms(Player);

        Collision = new(this);

        Hud = new Hud(Dungeon.DungeonId, Dungeon.UseItemKey, Dungeon.AttackKey, this);
        Menu = new Menu(Dungeon.UseItemKey, this);

        StartScreen = new StartScreen.StartScreen(this);

        controllers.Add(new KeyboardController(this, Player));
        controllers.Add(new MouseController(this, Player));
    }

    protected override void Update(GameTime gameTime)
    {
        TotalGameTime++;

        if (PauseDebounce >= 10 && ToggleControls)
        {
            for (int i = 0; i < controllers.Count; i++)
            {
                controllers[i].Update();
            }
        }

        if (!StartScreenToggle)
        {

            if (!TogglePause)
            {
                RoomManager.Update();
                PauseDebounce++;
                Hud.TogglePauseDisplay(TogglePause);

                if (ToggleEntities && !FreezeAllEntities)
                {
                    Player.Update();
                    Collision.Update(); // should be one of the last thing that updates
                }
            }
            else
            {
                Hud.TogglePauseDisplay(TogglePause);
                Menu.Update();
                PauseDebounce++;
            }
        }
        else
        {
            StartScreen.Update();
            
        }
        
        // Audio has to be outside to allow pause sounds, will cause bugs with delayed sounds playing on pause screen
        AudioManager.Update();
        Hud.Update();

        base.Update(gameTime);
    }
    public void SetPause()
    {
        TogglePause = !TogglePause;
        PauseDebounce = 0;
    }


    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp);

        if (!StartScreenToggle)
        {
            if (!TogglePause)
            {
                RoomManager.Draw();
                if (ToggleEntities)
                {
                    Player.Draw();
                }
            }
            else
            {
                Menu.Draw();
            }

            // Hud always drawn
            Hud.Draw();

        }
        else
        {
            StartScreen.Draw();
        }

        spriteBatch.End();

        base.Draw(gameTime);
    }
}

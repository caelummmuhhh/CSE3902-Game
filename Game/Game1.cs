using System.Collections.Generic;
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
using MainGame.SpriteHandlers.BlockSprites;
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

    public BlockSprite testBlock; // TODO: DELETE ME

    public Dungeon Dungeon;
    public Hud Hud;
    public Menu Menu;

    public bool TogglePause { get; set; } = false;
    public bool ToggleEntities { get; set; } = true; // whether or not to update and draw entities
    public bool ToggleControls { get; set; } = true; // turn off controls
    public bool FreezeAllEntities { get; set; } = false; // no update, but draw
    private int PauseDebounce = 10;

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

        testBlock = (BlockSprite)SpriteFactory.CreateBlackSquareSprite(); // TODO: DELETE ME

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
        /*
            public bool TogglePause { get; set; } = false;
            public bool ToggleEntities { get; set; } = false; // whether or not to update and draw entities
            public bool FreezeControls { get; set; } = false; // turn off controls
            public bool FreezeAllEntities { get; set; } = false; // no update, but draw
        */

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
        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);

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

        /*
        testBlock.Draw(RoomManager.CurrentRoom.NorthDoor.HitBox, Color.White);
        testBlock.Draw(RoomManager.CurrentRoom.EastDoor.HitBox, Color.White);
        testBlock.Draw(RoomManager.CurrentRoom.SouthDoor.HitBox, Color.White);
        testBlock.Draw(RoomManager.CurrentRoom.WestDoor.HitBox, Color.White);*/


        // Hud always drawn
        Hud.Draw();
        spriteBatch.End();

        base.Draw(gameTime);
    }
}

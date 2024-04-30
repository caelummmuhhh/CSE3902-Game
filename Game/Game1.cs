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

    private Effect crtEffect;
    private float timeOscillator = 0f;
    private float oscillatorDirection = 1f;
    public RenderTarget2D RenderTarget1;
    public RenderTarget2D RenderTarget2;
    public RenderTarget2D RenderTarget3;
    public RenderTarget2D RenderTarget4;

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
        RenderTarget1 = new RenderTarget2D(GraphicsDevice, GraphicsManager.PreferredBackBufferWidth, GraphicsManager.PreferredBackBufferHeight);
        RenderTarget2 = new RenderTarget2D(GraphicsDevice, GraphicsManager.PreferredBackBufferWidth, GraphicsManager.PreferredBackBufferHeight);
        RenderTarget3 = new RenderTarget2D(GraphicsDevice, GraphicsManager.PreferredBackBufferWidth, GraphicsManager.PreferredBackBufferHeight);
        //RenderTarget4 = new RenderTarget2D(GraphicsDevice, GraphicsManager.PreferredBackBufferWidth, GraphicsManager.PreferredBackBufferHeight);

        SpriteFactory.LoadAllTextures(Content);
        SpriteFactory.SpriteBatch = spriteBatch;
        crtEffect = Content.Load<Effect>("Shaders/VHS");

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
        timeOscillator += (float)gameTime.ElapsedGameTime.TotalSeconds;// * oscillatorDirection;
        timeOscillator = timeOscillator > 10f ? 0 : timeOscillator;
        //oscillatorDirection = timeOscillator < 0f || timeOscillator > 1f ? -1f * oscillatorDirection : oscillatorDirection;
        crtEffect.Parameters["TimePassage"].SetValue((float)new Random().NextDouble());

        if (PauseDebounce >= 10 && ToggleControls)
        {
            for (int i = 0; i < controllers.Count; i++)
            {
                controllers[i].Update();
            }
        }

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
        GraphicsDevice.SetRenderTarget(RenderTarget1);
        GraphicsDevice.Clear(Color.Black);
        spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp);

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
        spriteBatch.End();

        GraphicsDevice.SetRenderTarget(RenderTarget2);
        GraphicsDevice.Clear(Color.Black);
        crtEffect.CurrentTechnique = crtEffect.Techniques[0];
        spriteBatch.Begin(samplerState: SamplerState.PointClamp, effect: crtEffect);
        spriteBatch.Draw(RenderTarget1, Vector2.Zero, Color.White);
        spriteBatch.End();

        GraphicsDevice.SetRenderTarget(RenderTarget3);
        GraphicsDevice.Clear(Color.Black);
        crtEffect.CurrentTechnique = crtEffect.Techniques[1];
        spriteBatch.Begin(samplerState: SamplerState.PointClamp, effect: crtEffect);
        spriteBatch.Draw(RenderTarget2, Vector2.Zero, Color.White);
        spriteBatch.End();

        GraphicsDevice.SetRenderTarget(null);
        GraphicsDevice.Clear(Color.Black);
        crtEffect.CurrentTechnique = crtEffect.Techniques[2];
        spriteBatch.Begin(samplerState: SamplerState.PointClamp, effect: crtEffect);
        spriteBatch.Draw(RenderTarget3, Vector2.Zero, Color.White);
        spriteBatch.End();

        base.Draw(gameTime);
    }
}

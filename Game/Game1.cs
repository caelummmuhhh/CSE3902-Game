using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MainGame.SpriteHandlers;
using MainGame.Audio;
using System;
using System.Collections.Generic;

namespace MainGame;

public enum GameStateType
{
    Play, TitleScreen, Menu
}

public class Game1 : Game
{
    public readonly GraphicsDeviceManager GraphicsManager;
    private SpriteBatch spriteBatch;
    public int TotalGameTime = 0;
    public RenderTarget2D[] RenderTargets;
    public readonly int RenderTargetCount = 4;
    public IGameState CurrentGameState;
    private readonly Dictionary<GameStateType, IGameState> AllGameStates = new();

    public Effect ShaderEffect;
    private float timeOscillator = 0f;
    //private float oscillatorDirection = 1f;

    public Game1()
    {
        GraphicsManager = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = 768,
            PreferredBackBufferHeight = 696
        };
        RenderTargets = new RenderTarget2D[RenderTargetCount];
        //this.TargetElapsedTime = TimeSpan.FromSeconds(1d / 30d); //60);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        AudioManager.SetUp(this);
        spriteBatch = new SpriteBatch(GraphicsDevice);

        for (int i = 0; i < RenderTargetCount; i++)
        {
            RenderTargets[i] = new RenderTarget2D(GraphicsDevice, GraphicsManager.PreferredBackBufferWidth, GraphicsManager.PreferredBackBufferHeight);
        }

        SpriteFactory.LoadAllTextures(Content);
        SpriteFactory.SpriteBatch = spriteBatch;

        AllGameStates.Add(GameStateType.Play, new PlayGameState(this));
        AllGameStates.Add(GameStateType.Menu, new MenuGameState(this, spriteBatch, Content));

        SetGameState(GameStateType.Play);
    }

    protected override void Update(GameTime gameTime)
    {
        TotalGameTime++;
        timeOscillator += (float)gameTime.ElapsedGameTime.TotalSeconds;// * oscillatorDirection;
        timeOscillator = timeOscillator > 10f ? 0 : timeOscillator;
        //oscillatorDirection = timeOscillator < 0f || timeOscillator > 1f ? -1f * oscillatorDirection : oscillatorDirection;
        ShaderEffect?.Parameters["TimePassage"]?.SetValue((float)new Random().NextDouble());

        CurrentGameState.Update(gameTime);
        AudioManager.Update();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.SetRenderTarget(RenderTargets[0]);
        GraphicsDevice.Clear(Color.Black);
        spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp);
        CurrentGameState.Draw(gameTime);
        spriteBatch.End();

        // draw each technique onto a target so the effects and be additively blended together
        int currentRenderTarget = 0;
        int techniqueCounts = ShaderEffect is null ? 0 : ShaderEffect.Techniques.Count;
        for (int i = 0; i < techniqueCounts; i++)
        {
            if (i >= RenderTargetCount) break;

            currentRenderTarget++;
            GraphicsDevice.SetRenderTarget(RenderTargets[currentRenderTarget]);
            GraphicsDevice.Clear(Color.Black);
            ShaderEffect.CurrentTechnique = ShaderEffect.Techniques[i];
            spriteBatch.Begin(samplerState: SamplerState.PointClamp, effect: ShaderEffect);
            spriteBatch.Draw(RenderTargets[currentRenderTarget - 1], Vector2.Zero, Color.White);
            spriteBatch.End();
        }

        // finally draw onto buffer
        GraphicsDevice.SetRenderTarget(null);
        GraphicsDevice.Clear(Color.Black);
        spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        spriteBatch.Draw(RenderTargets[currentRenderTarget], Vector2.Zero, Color.White);
        spriteBatch.End();

        base.Draw(gameTime);
    }

    public void SetGameState(GameStateType gameStateType)
    {
        Console.WriteLine($"Setting game state to: {gameStateType}");
        CurrentGameState = AllGameStates[gameStateType];
    }
}

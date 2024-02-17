using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MainGame.SpriteHandlers;
using MainGame.Controllers;
using MainGame.Players;
using System.Collections.Generic;

namespace MainGame;

public class Game1 : Game
{
    public readonly GraphicsDeviceManager GraphicsManager;
    private SpriteBatch spriteBatch;
    private List<IController> controllers;
    private List<ISprite> items;
    private List<ISprite> blocks;

    private ISprite textSprite;
    public Player Player;

    public Game1()
    {
        GraphicsManager = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        controllers = new List<IController>();
        items = new List<ISprite>();
        blocks = new List<ISprite>();
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateHeartItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateHeartContainerItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateClockItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateFiveRupeesItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateRupeeItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateMapItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateWoodenBoomerangItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateBombItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateBowItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateArrowItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateKeyItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateCompassItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateTriforcePieceItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateFairyItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateFireSprite());

        blocks.Add(MainGame.SpriteHandlers.SpriteFactory.CreateBlueFloorSprite());
        blocks.Add(MainGame.SpriteHandlers.SpriteFactory.CreateSquareBlockSprite());
        blocks.Add(MainGame.SpriteHandlers.SpriteFactory.CreateStatueOneEntranceSprite());
        blocks.Add(MainGame.SpriteHandlers.SpriteFactory.CreateStatueTwoEntranceSprite());
        blocks.Add(MainGame.SpriteHandlers.SpriteFactory.CreateStatueOneEndSprite());
        blocks.Add(MainGame.SpriteHandlers.SpriteFactory.CreateStatueTwoEndSprite());
        blocks.Add(MainGame.SpriteHandlers.SpriteFactory.CreateBlackSquareSprite());
        blocks.Add(MainGame.SpriteHandlers.SpriteFactory.CreateBlueSandSprite());
        blocks.Add(MainGame.SpriteHandlers.SpriteFactory.CreateBlueGapSprite());
        blocks.Add(MainGame.SpriteHandlers.SpriteFactory.CreateStairsSprite());
        blocks.Add(MainGame.SpriteHandlers.SpriteFactory.CreateWhiteBrickSprite());
        blocks.Add(MainGame.SpriteHandlers.SpriteFactory.CreateWhiteLadderSprite());

        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        SpriteFactory.LoadAllTextures(Content);
        SpriteFactory.SpriteBatch = spriteBatch;

        textSprite = SpriteFactory.CreateTextSprite("hello world!");
        Player = new Player(
            new Vector2(GraphicsManager.PreferredBackBufferWidth / 2,
                GraphicsManager.PreferredBackBufferHeight / 2),
            SpriteFactory.CreatePlayerStaticIdleSprite(),
            this
        );

        controllers.Add(new KeyboardController(this, Player, blocks, items));
        controllers.Add(new MouseController(this, Player));
    }

    protected override void Update(GameTime gameTime)
    {

        foreach (IController controller in controllers)
        {
            controller.Update();
        }

        Player.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Indigo);

        Player.Draw();
        textSprite.Draw(10, GraphicsManager.PreferredBackBufferHeight - 100, Color.Black);

        base.Draw(gameTime);
    }
}

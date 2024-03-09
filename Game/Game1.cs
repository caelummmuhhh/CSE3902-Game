using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MainGame.SpriteHandlers;
using MainGame.Controllers;
using MainGame.Players;
using MainGame.Rooms;
using MainGame.RoomsAndDoors;
using MainGame.BlocksAndItems;

using MainGame.Collision;
using MainGame.SpriteHandlers.BlockSprites;
using MainGame.Enemies;

namespace MainGame;

public class Game1 : Game
{
    public readonly GraphicsDeviceManager GraphicsManager;
    private SpriteBatch spriteBatch;
    public List<IController> controllers;

    public IPlayer Player;
    public Room Room;
    public CollisionDetector Collision;

    public BlockSprite testBlock; // TODO: DELETE ME

    public Game1()
    {
        GraphicsManager = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = 768,
            PreferredBackBufferHeight = 528  //768 in sprint 4+
        };

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
        spriteBatch = new SpriteBatch(GraphicsDevice);

        SpriteFactory.LoadAllTextures(Content);
        SpriteFactory.SpriteBatch = spriteBatch;

        Player = new Player(this);

        Room = RoomFactory.GenerateRoom(1, this);
        Collision = new(this);

        testBlock = (BlockSprite)SpriteFactory.CreateBlackSquareSprite(); // TODO: DELETE ME

        controllers.Add(new KeyboardController(this, Player));
        controllers.Add(new MouseController(this, Player));
    }

    protected override void Update(GameTime gameTime)
    {
        for (int i = 0; i < controllers.Count; i++)
        {
            controllers[i].Update();
        }

        Player.Update();
        Room.Update();
        Collision.Update();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);

        Room.Draw();
        Player.Draw();

        if (Room.Enemies.Count > 0)
        {
            testBlock.Draw(
                new List<IEnemy>(Room.Enemies)[0].HitBox,
                Color.White
                );

        }

        spriteBatch.End();

        base.Draw(gameTime);
    }
}

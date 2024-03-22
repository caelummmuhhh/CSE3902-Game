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
using System;

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
            PreferredBackBufferWidth = 256 * Constants.UniversalScale,
            PreferredBackBufferHeight = 176 * Constants.UniversalScale  //768 in sprint 4+
        };

        this.TargetElapsedTime = TimeSpan.FromSeconds(1d / 30d); //60);
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

        /*if (Room.Enemies.Count > 0)
        {
            testBlock.Draw(
            new List<IEnemy>(Room.Enemies)[0].HitBox,
            Color.White
            );
        }*/

        Rectangle t = new(
            Player.MainHitbox.X + Player.Sprite.DestinationRectangle.Width / 2,
            Player.MainHitbox.Y + Player.Sprite.DestinationRectangle.Height / 2,
            Player.MainHitbox.Width / 10, Player.MainHitbox.Height / 10);
        testBlock.Draw(t, Color.White);

        spriteBatch.End();

        base.Draw(gameTime);
    }
}

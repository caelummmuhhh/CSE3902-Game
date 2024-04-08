using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MainGame.SpriteHandlers;
using MainGame.Controllers;
using MainGame.Players;
using MainGame.Rooms;

using MainGame.Collision;
using MainGame.SpriteHandlers.BlockSprites;
using MainGame.Projectiles;
using MainGame.Enemies;
using MainGame.Items;

namespace MainGame;

public class Game1 : Game
{
    public readonly GraphicsDeviceManager GraphicsManager;
    private SpriteBatch spriteBatch;
    public List<IController> controllers;

    public IPlayer Player;
    public CollisionDetector Collision;
    public GameRoomManager RoomManager;

    public BlockSprite testBlock; // TODO: DELETE ME

    public Game1()
    {
        GraphicsManager = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = 256 * Constants.UniversalScale,
            PreferredBackBufferHeight = 176 * Constants.UniversalScale  //768 in sprint 4+
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
        spriteBatch = new SpriteBatch(GraphicsDevice);

        SpriteFactory.LoadAllTextures(Content);
        SpriteFactory.SpriteBatch = spriteBatch;

        Player = new Player(new Vector2(96, 96));
        RoomManager = new(this);

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
        RoomManager.Update();
        Player.Update();
        Collision.Update();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);

        RoomManager.Draw();
        Player.Draw();

        /*
        if (RoomManager.CurrentRoom.RoomEnemies.Count > 0)
        {
            testBlock.Draw(
            RoomManager.CurrentRoom.RoomEnemies[0].AttackHitBox,
            Color.White
            );
        }
        */

        /*
        foreach(IProjectile p in ((Player)Player).ProjectilesManager.ActiveProjectiles)
        {
            testBlock.Draw(p.HitBox, Color.White);
        }*/

        //testBlock.Draw(Player.MainHitbox, Color.White);
        /*
        foreach (IEnemy enemy in RoomManager.CurrentRoom.RoomEnemies)
        {
            if (enemy is AquamentusEnemy aq)
            {
                foreach (AquamentusAttackProjectiles aqp in aq.ProjectilesManager.ActiveProjectiles)
                {
                    testBlock.Draw(aqp.UpProjectile.HitBox, Color.White);
                    testBlock.Draw(aqp.StraightProjectile.HitBox, Color.White);
                    testBlock.Draw(aqp.DownProjectile.HitBox, Color.White);
                }
            }
        }*/

        /*
        foreach (IItem item in RoomManager.CurrentRoom.RoomItems)
        {
            testBlock.Draw(item.HitBox, Color.White);
        }*/

        /*
        foreach (Rectangle hb in RoomManager.CurrentRoom.PlayerBorderHitBox.HitBoxes)
        {
            testBlock.Draw(hb, Color.White);
        }*/

        spriteBatch.End();

        base.Draw(gameTime);
    }
}

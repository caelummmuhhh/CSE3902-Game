using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MainGame.SpriteHandlers;
using MainGame.Controllers;
using MainGame.Players;
using MainGame.Rooms;
using MainGame.Doors;
using MainGame.Blocks;
using MainGame.Items;
using MainGame.HudAndMenu;
using MainGame.Dungeons;
using MainGame.Collision;
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

    public IPlayer Player;
    public CollisionDetector Collision;
    public GameRoomManager RoomManager;

    public BlockSprite testBlock; // TODO: DELETE ME

    public Dungeon Dungeon;
    public Hud Hud;
    public Menu Menu;

    public bool TogglePause;
    int PauseDebounce;


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

        spriteBatch = new SpriteBatch(GraphicsDevice);

        SpriteFactory.LoadAllTextures(Content);
        SpriteFactory.SpriteBatch = spriteBatch;

        string fullPath = Path.GetFullPath(dungeonFiles[0]);
        string[] lines = null;
        if (File.Exists(fullPath))
        {
            lines = File.ReadAllLines(fullPath);
        } else
        {
            throw new IOException($"Could not read CSV file for dungeon: {dungeonFiles[0]}");
        }
        string[] version = lines[0].Split(',');
        string[] playerValues = lines[1].Split(',');
        string[] playerItems = lines[2].Split(',');
        string[] startingRoom = lines[3].Split(',');
        string[] triforceRoom = lines[4].Split(',');   

        Player = new Player(new Vector2(120 * Constants.UniversalScale, (128 * Constants.UniversalScale) + Constants.HudAndMenuHeight), 
            int.Parse(playerValues[0]), int.Parse(playerValues[1]), int.Parse(playerValues[2]), int.Parse(playerValues[3]), playerItems);
        */

        RoomManager = new(this);

        Collision = new(this);

        Hud = new Hud(Dungeon.DungeonId, Dungeon.UseItemKey, Dungeon.AttackKey, this);
        Menu = new Menu(Dungeon.UseItemKey, this);

        testBlock = (BlockSprite)SpriteFactory.CreateBlackSquareSprite(); // TODO: DELETE ME

        controllers.Add(new KeyboardController(this, Player));
        controllers.Add(new MouseController(this, Player));
    }

    protected override void Update(GameTime gameTime)
    {
        if (PauseDebounce >= 10)
        {
            for (int i = 0; i < controllers.Count; i++)
            {
                controllers[i].Update();
            }
        }
        if (!TogglePause)
        {
            ++PauseDebounce;
            RoomManager.Update();
            Player.Update();
            Hud.Update();
            Collision.Update();
        } else
        {
            Menu.Update();
            ++PauseDebounce;
        }

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

        } else
        {
            Menu.Draw();
            
        }
        // Hud always drawn
        Hud.Draw();

        spriteBatch.End();

        base.Draw(gameTime);
    }
}

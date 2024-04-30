using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MainGame.Controllers;
using MainGame.Players;
using MainGame.Rooms;
using MainGame.HudAndMenu;
using MainGame.Dungeons;
using MainGame.Collision;
using MainGame.RNG;

namespace MainGame;

public class PlayGameState : IGameState
{
    private readonly Game1 game;
    public readonly List<IController> controllers = new();
    public IPlayer Player;
    public CollisionDetector Collision;
    public GameRoomManager RoomManager;

    public Dungeon Dungeon;
    public Hud Hud;
    public Menu Menu;

    public bool TogglePause { get; set; } = false;
    public bool ToggleEntities { get; set; } = true; // whether or not to update and draw entities
    public bool ToggleControls { get; set; } = true; // turn off controls
    public bool FreezeAllEntities { get; set; } = false; // no update, but draw
    private int PauseDebounce = 10;

    public PlayGameState(Game1 game)
    {
        this.game = game;

        RandomGeneration.GenerateDungeon(game, "Content/Dungeons/Dungeon_Base.csv", "Content/Dungeons/Dungeon_Random.csv");

        // Set to random dungeon here
        string dungeonName = "Dungeon_1.csv";
        string roomFolder = "Content/Rooms";

        Dungeon = new Dungeon(game, dungeonName);

        RoomManager = new(game, this);
        Player = new Player(new Vector2(120 * Constants.UniversalScale, (128 * Constants.UniversalScale) + Constants.HudAndMenuHeight), RoomManager,
            Dungeon.PlayerStartingItems, Dungeon.PlayerStartingHealth, Dungeon.PlayerStartingRupees, Dungeon.PlayerStartingKeys, Dungeon.PlayerStartingBombs);

        RoomManager.LoadAllRooms(Player, roomFolder);

        Collision = new(this);

        Hud = new Hud(Dungeon.DungeonId, Dungeon.UseItemKey, Dungeon.AttackKey, this);
        Menu = new Menu(Dungeon.UseItemKey, this);

        controllers.Add(new PlayKeyboardController(game, this, Player));
        controllers.Add(new PlayMouseController(game, this, Player));

    }

    public void Update(GameTime gameTime)
    {
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
        Hud.Update();
    }

    public void SetPause()
    {
        TogglePause = !TogglePause;
        PauseDebounce = 0;
    }

    public void Draw(GameTime gameTime)
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
}

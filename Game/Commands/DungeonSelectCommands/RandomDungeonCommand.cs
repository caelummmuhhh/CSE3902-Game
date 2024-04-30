using MainGame.Dungeons;
using MainGame.HudAndMenu;
using MainGame.Players;
using MainGame.RNG;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGame.Commands.DungeonSelectCommands
{
    public class RandomDungeonCommand : ICommand
    {
        Game1 game;
        public RandomDungeonCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute() 
        {
            RandomGeneration.GenerateDungeon(game, "Content/Dungeons/Dungeon_Base.csv", "Content/Dungeons/Dungeon_Random.csv");

            // Set to random dungeon here
            string dungeonName = "Dungeon_Random.csv";
            string roomFolder = "Content/RandomRooms";

            game.Dungeon = new Dungeon(game, dungeonName);

            game.GameSelectScreenToggle = false;

            game.RoomManager = new(game);

            game.RoomManager.LoadAllRooms(game.Player, roomFolder);

            game.Player = new Player(new Vector2(120 * Constants.UniversalScale, (128 * Constants.UniversalScale) + Constants.HudAndMenuHeight), game.RoomManager,
            game.Dungeon.PlayerStartingItems, game.Dungeon.PlayerStartingHealth, game.Dungeon.PlayerStartingRupees, game.Dungeon.PlayerStartingKeys, game.Dungeon.PlayerStartingBombs);

            

            game.Collision = new(game);

            game.Hud = new Hud(game.Dungeon.DungeonId, game.Dungeon.UseItemKey, game.Dungeon.AttackKey, game);
            game.Menu = new Menu(game.Dungeon.UseItemKey, game);
        }

        public void UnExecute() { }
    }
}

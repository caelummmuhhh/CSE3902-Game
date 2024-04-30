using Microsoft.Xna.Framework;
using MainGame.Controllers;
using MainGame.Players;
using MainGame.Dungeons;
using System.Threading;
using System;
using MainGame.Audio;

namespace MainGame.Commands
{
    public class ResetGameCommand : ICommand
    {
        private readonly Game1 game;
        public ResetGameCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            /*
            AudioManager.ResetSong();

            game.RoomManager = new(game);
            game.Player = new Player(new Vector2(120 * Constants.UniversalScale, (128 * Constants.UniversalScale) + Constants.HudAndMenuHeight), game.RoomManager,
                Array.Empty<int>(), game.Dungeon.PlayerStartingHealth, game.Dungeon.PlayerStartingRupees, game.Dungeon.PlayerStartingKeys, game.Dungeon.PlayerStartingBombs);

            //game.RoomManager.LoadAllRooms(game.Player);

            game.Collision = new(game);

            game.controllers.Clear();
            game.controllers.Add(new KeyboardController(game, game.Player));
            game.controllers.Add(new MouseController(game, game.Player));
            */
        }

        public void UnExecute()
        {
            // Not needed
        }
    }
}

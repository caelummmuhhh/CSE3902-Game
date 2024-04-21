using Microsoft.Xna.Framework;
using MainGame.Controllers;
using MainGame.Players;

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
            game.controllers.Clear();

            //game.Player = new Player(new Vector2(120 * Constants.UniversalScale, (128 * Constants.UniversalScale) + Constants.HudAndMenuHeight), System.Array.Empty<ItemTypes>());

            game.controllers.Add(new KeyboardController(game, game.Player));
            game.controllers.Add(new MouseController(game, game.Player));
        }

        public void UnExecute()
        {
            // Not needed
        }
    }
}

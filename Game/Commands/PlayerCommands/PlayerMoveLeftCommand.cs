using MainGame.Players;
using Microsoft.Xna.Framework;

namespace MainGame.Commands.PlayerCommands
{
    public class PlayerMoveLeftCommand : ICommand
    {
        private readonly Game1 game;
        public PlayerMoveLeftCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (!game.TogglePause)
            {
                game.Player.MoveLeft();
            } else
            {

            }
        }

        public void UnExecute()
        {
            game.Player.Stop();
        }
    }
}


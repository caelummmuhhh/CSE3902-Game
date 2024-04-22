using MainGame.HudAndMenu;

namespace MainGame.Commands
{
    public class PauseMenuCommand : ICommand
    {
        private Game1 game;

        public PauseMenuCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.SetPause();
        }

        public void UnExecute()
        {
            
        }
    }
}

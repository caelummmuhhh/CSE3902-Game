using MainGame.HudAndMenu;

namespace MainGame.Commands
{
    public class PauseMenuCommand : ICommand
    {
        private PlayGameState game;

        public PauseMenuCommand(PlayGameState game)
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

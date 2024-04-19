using MainGame.HudAndMenu;

namespace MainGame.Commands
{
    public class MuteMusicCommand : ICommand
    {
        private Game1 game;

        public MuteMusicCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.AudioManager.MuteSong();
        }

        public void UnExecute()
        {
            
        }
    }
}

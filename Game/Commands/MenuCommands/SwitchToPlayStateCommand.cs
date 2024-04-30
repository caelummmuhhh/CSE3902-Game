using MainGame.Audio;
using MainGame.HudAndMenu;

namespace MainGame.Commands
{
    public class SwitchToPlayStateCommand : ICommand
    {
        private Game1 game;

        public SwitchToPlayStateCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.SetGameState(GameStateType.Play);
        }

        public void UnExecute()
        {
            
        }
    }
}

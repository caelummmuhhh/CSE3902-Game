using MainGame.Audio;
using MainGame.HudAndMenu;

namespace MainGame.Commands
{
    public class SwitchToMenuStateCommand : ICommand
    {
        private Game1 game;

        public SwitchToMenuStateCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.SetGameState(GameStateType.Menu);
        }

        public void UnExecute()
        {
            
        }
    }
}

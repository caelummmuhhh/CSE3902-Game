using MainGame.Audio;
using MainGame.HudAndMenu;

namespace MainGame.Commands
{
    public class NextShaderCommand : ICommand
    {
        private MenuGameState gameState;

        public NextShaderCommand(MenuGameState gameState)
        {
            this.gameState = gameState;
        }

        public void Execute()
        {
            gameState.NextShaderOption();
        }

        public void UnExecute()
        {
            
        }
    }
}

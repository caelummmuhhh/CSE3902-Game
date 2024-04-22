namespace MainGame.Commands.MenuCommands
{
	public class MoveItemSelectLeftCommand : ICommand
    {
        private readonly Game1 game;
        public MoveItemSelectLeftCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Menu.MoveSelectingBoxLeft();
        }

        public void UnExecute() { }
    }
}

namespace MainGame.Commands
{
    public class NextRoomCommand : ICommand
    {
        private Game1 game;

        public NextRoomCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Room = game.Room.GetNextRoom();
        }

        public void UnExecute()
        {
            
        }
    }
}

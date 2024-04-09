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
            game.RoomManager.NextRoom();
        }

        public void UnExecute()
        {
            
        }
    }
}

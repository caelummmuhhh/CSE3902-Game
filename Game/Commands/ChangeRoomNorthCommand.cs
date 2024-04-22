namespace MainGame.Commands
{
    public class ChangeRoomNorthCommand : ICommand
    {
        private Game1 game;

        public ChangeRoomNorthCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.RoomManager.NextRoom(Direction.North);
        }

        public void UnExecute()
        {
            
        }
    }
}

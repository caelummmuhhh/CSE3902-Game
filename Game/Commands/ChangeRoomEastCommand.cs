namespace MainGame.Commands
{
    public class ChangeRoomEastCommand : ICommand
    {
        private Game1 game;

        public ChangeRoomEastCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.RoomManager.NextRoom(Direction.East);
        }

        public void UnExecute()
        {
            
        }
    }
}

namespace MainGame.Commands
{
    public class ChangeRoomWestCommand : ICommand
    {
        private Game1 game;

        public ChangeRoomWestCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.RoomManager.NextRoom(Direction.West);
        }

        public void UnExecute()
        {
            
        }
    }
}

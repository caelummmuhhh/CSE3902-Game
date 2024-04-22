namespace MainGame.Commands
{
    public class ChangeRoomSouthCommand : ICommand
    {
        private Game1 game;

        public ChangeRoomSouthCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.RoomManager.NextRoom(Direction.South);
        }

        public void UnExecute()
        {
            
        }
    }
}

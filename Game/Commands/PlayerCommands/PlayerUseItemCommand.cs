using MainGame.Players;
using System;

namespace MainGame.Commands.PlayerCommands
{
	public class PlayerUseItemCommand : ICommand
    {
        private readonly IPlayer player;
        public PlayerUseItemCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            switch (player.CurrentItem)
            {
                case ItemTypes.Bomb:
                    player.CurrentState.UseBomb(); 
                    break;
                case ItemTypes.Fire: 
                    player.CurrentState.UseFire(); 
                    break;
                case ItemTypes.Boomerang: 
                    player.CurrentState.UseBoomerang(); 
                    break;
                case ItemTypes.Arrow: 
                    player.CurrentState.UseArrow(); 
                    break;
                default:
                    throw new FormatException("Default in PlayerUseItemCommand should not be possible");
            }
        }

        public void UnExecute() { /* not needed */ }
    }
}



using MainGame.Items;

namespace MainGame.Players.PlayerStates
{
	public class PickUpSpecialItemState : IPlayerState
	{
        private readonly IPlayer player;
        private readonly IPickupableItem item;

        public PickUpSpecialItemState(IPlayer player, IPickupableItem item)
		{
            this.player = player;
            this.item = item;
		}

        public void Stop()
        {
            player.CurrentState = player.FacingDirection switch
            {
                Direction.North => new PlayerIdleUpState(player),
                Direction.East => new PlayerIdleRightState(player),
                Direction.South => new PlayerIdleDownState(player),
                Direction.West => new PlayerIdleLeftState(player),
                _ => new PlayerIdleUpState(player)
            };
        }

        public void Update()
        {
            player.Update();
        }

        public void Draw()
        {

        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public void UseSword() { }
        public void TakeDamage(Direction sideHit) { }
        public void UseEquipment() { }
    }
}


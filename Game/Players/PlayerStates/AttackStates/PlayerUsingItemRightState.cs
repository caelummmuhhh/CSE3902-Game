﻿using MainGame.SpriteHandlers;

namespace MainGame.Players.PlayerStates
{
	public class PlayerUsingItemRightState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly int stateDuration;
        private int currentFrame = 0;

        public PlayerUsingItemRightState(IPlayer player)
        {
            this.player = player;
            this.player.FacingDirection = Direction.East;
            this.player.Sprite = SpriteFactory.CreatePlayerInteractingRightSprite();
            stateDuration = Player.UsingItemsSpeed;
            this.player.Inventory.UseEquippedItem(); // actually use the item
        }

        public void Update()
        {
            if (currentFrame == stateDuration)
            {
                player.CurrentState = new PlayerIdleRightState(player);
            }
            player.Sprite.Update();
        }

        public void Draw()
        {
            currentFrame++;
            player.Sprite.Draw(player.Position.X, player.Position.Y, player.SpriteColor);
        }

        public void TakeDamage(Direction sideHit)
            => player.CurrentState = new PlayerKnockedBackState(player, Utils.OppositeDirection(sideHit));

        /* Not useable in this state, therefore not implemented. */
        public void Stop() { }
        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public void UseSword() { }
        public void UseEquipment() { }
    }
}


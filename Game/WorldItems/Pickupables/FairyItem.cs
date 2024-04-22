using Microsoft.Xna.Framework;
using MainGame.Players;
using System;
using MainGame.Audio;

namespace MainGame.WorldItems
{
	public class FairyItem : HealthRecoveryItem
	{
        private readonly int speed = 3;
        private readonly Random random;
        private Direction moveDirection;
        private int directionChangeTimer = 0;

		public FairyItem(Vector2 spawnPosition, IPlayer player)
			: base(spawnPosition, player, ItemTypes.Fairy, 6)
        {
            random = new();
        }

        public override void Update()
        {
            Move();
            base.Update();
        }

        private void Move()
        {
            if (directionChangeTimer <= 0) {
                directionChangeTimer = directionChangeTimer = random.Next(1, 16) * 4;
                ChangeMoveDirection();
            }
            directionChangeTimer--;
            Position = Utils.DirectionalMove(Position, moveDirection, speed);
        }

        public void ChangeMoveDirection()
        {
            Direction newDirection = Utils.GetRandomCardinalAndOrdinalDirection();
            while (newDirection == moveDirection)
            {
                newDirection = Utils.GetRandomCardinalAndOrdinalDirection();
            }
            moveDirection = newDirection;
        }

        public override void PickUp()
        {
            IsPickedUp = true;
            Player.Heal(healAmount);
            AudioManager.PlaySFX("Grab_Item_Medium", 0);
        }
    }
}


using Microsoft.Xna.Framework;
using MainGame.Players;
using System;

namespace MainGame.Items
{
	public class FairyItem : HealthRecoveryItem
	{
        private readonly int speed = 5;
        private readonly Random random;
        private Direction moveDirection;
        private int directionChangeTimer = 0;

		public FairyItem(Vector2 spawnPosition, IPlayer player)
			: base(spawnPosition, player, ItemTypes.Fairy, player.MaxHealth)
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
                moveDirection = Utils.GetRandomCardinalAndOrdinalDirection();
            }
            Position = Utils.DirectionalMove(Position, moveDirection, speed);
        }
    }
}


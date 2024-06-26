﻿using MainGame.Audio;
using Microsoft.Xna.Framework;

namespace MainGame.Enemies
{
	public class GoriyaEnemy : GenericEnemy
	{
        public override int Health { get; protected set; } = 3;
        public override int Damage => 1;
        public Direction FacingDirection { get; set; }
		public override int MovementCoolDownFrame { get; protected set; } = 2;

        public GoriyaEnemy(Vector2 startingPosition)
		{
			Position = startingPosition;
            PreviousPosition = new(Position.X, Position.Y);
            State = new GoriyaMovingState(this);
		}

        public override void Update()
        {
			State.Update();
            base.Update();
        }

        public override void Move()
		{
			State.Move();
		}
	}
}


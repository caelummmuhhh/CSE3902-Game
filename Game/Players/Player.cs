﻿using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Players.PlayerStates;

namespace MainGame.Players
{
	public class Player : IPlayer
	{
        public Vector2 Position;
		public ISprite CurrentSprite;
		public bool IsMoving;
		public static readonly float Speed = 5f;

        private IPlayerState currentState;
        public IPlayerState CurrentState
		{
			get { return currentState; }
			set { currentState = value; }
		}

		private readonly Game game;

		public Player(Game game)
		{
			Position = new Vector2(0, 0);
			currentState = new PlayerIdleState(this, Directions.Up);
			this.game = game;
		}

		public void Update()
		{
			currentState.Update();
		}

		public void Draw()
		{
			currentState.Draw();
		}

		public void MoveUp() { currentState.MoveUp(); }
		public void MoveDown() { currentState.MoveDown(); }
		public void MoveLeft() { currentState.MoveLeft(); }
		public void MoveRight() { currentState.MoveRight(); }
		public void Stop() { currentState.Stop(); }
	}
}


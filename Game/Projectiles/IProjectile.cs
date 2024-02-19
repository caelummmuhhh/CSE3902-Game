using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Players.PlayerStates;

namespace MainGame.Projectiles
{
	public interface IProjectile
	{
		public Vector2 Position { get; }
		public bool IsActive { get; }
		public void Update();
		public void Draw();
	}

	public enum Direction { Up, Down, Left, Right }
}


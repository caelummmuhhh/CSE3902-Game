using System;
using Microsoft.Xna.Framework;
using MainGame.Enemies;
using MainGame.Players;

namespace MainGame.Collision.CollisionHandlers
{
	public class PlayerEnemyCollisionHandler : ICollisionHandler
	{
		public PlayerEnemyCollisionHandler(IPlayer player, IEnemy enemy, Rectangle overlap)
		{

		}

        public void HandleCollision()
        {
        }
    }
}


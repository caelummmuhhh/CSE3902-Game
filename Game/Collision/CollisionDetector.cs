using System.Collections.Generic;
using Microsoft.Xna.Framework;

using MainGame.BlocksAndItems;
using MainGame.Players;
using MainGame.Enemies;
using MainGame.Projectiles;
using MainGame.Rooms;
using MainGame;
using System;
using MainGame.Collision.CollisionHandlers;

namespace MainGame.Collision
{
	public class CollisionDetector
	{
		private List<IBlock> blocks;
		private List<IItem> items;
		private List<IEnemy> enemies;
		private List<IProjectile> playerProjectiles = new();
		private List<IProjectile> enemyProjectiles = new();
        private IHitBox enemyBorder;
        private IHitBox playerBorders;

        private readonly Game1 game;
        private readonly Player player;

		public CollisionDetector(Game1 game)
		{
            this.game = game;
            player = (Player)game.Player;

            IRoom currentRoom = game.RoomManager.CurrentRoom;
            blocks = new List<IBlock>(currentRoom.RoomBlocks);
            items = new List<IItem>(currentRoom.RoomItems);
            enemies = new List<IEnemy>(currentRoom.RoomEnemies);
            playerProjectiles = new List<IProjectile>(player.ProjectilesManager.ActiveProjectiles);

            playerBorders = currentRoom.PlayerBorderHitBox;
            enemyBorder = currentRoom.EnemiesBorderHitBox;
            // TODO: Get enemy projectiles
        }

        public void Update()
        {
            IRoom currentRoom = game.RoomManager.CurrentRoom;
            blocks = new List<IBlock>(currentRoom.RoomBlocks);
            items = new List<IItem>(currentRoom.RoomItems);
            enemies = new List<IEnemy>(currentRoom.RoomEnemies);
            playerProjectiles = new List<IProjectile>(player.ProjectilesManager.ActiveProjectiles);
            playerBorders = currentRoom.PlayerBorderHitBox;
            enemyBorder = currentRoom.EnemiesBorderHitBox;

            DetectAllCollisions();
        }

        public void DetectAllCollisions()
        {
            DetectEnemyCollisions();
            DetectEnemyProjectileCollisions();
            DetectPlayerProjectileCollisions();
            DetectBlockCollisions();
            DetectBorderCollisions();
            DetectItemCollisions();
        }

		public void DetectEnemyCollisions()
		{
			foreach (IEnemy enemy in enemies) {
				foreach (IBlock block in blocks)
				{
					Rectangle overlap = Rectangle.Intersect(enemy.MovementHitBox, block.HitBox);
					if (!overlap.IsEmpty)
					{
                        new EnemyBlockCollisionHandler(enemy, block).HandleCollision();
					}
				}

				foreach (IProjectile playerProjectile in playerProjectiles)
				{
					Rectangle overlap = Rectangle.Intersect(enemy.AttackHitBox, playerProjectile.HitBox);
                    if (!overlap.IsEmpty)
                    {
                        Console.WriteLine("Enemy and Player Projectile");
                        // TODO
                    }
                }

                foreach (Rectangle borderHitBox in enemyBorder.HitBoxes)
                {
                    Rectangle overlap = Rectangle.Intersect(enemy.MovementHitBox, borderHitBox);
                    if (!overlap.IsEmpty)
                    {
                        new EnemyBorderCollisionHandler(enemy, borderHitBox).HandleCollision();
                    }
                }

                if (player.MainHitbox.Intersects(enemy.AttackHitBox))
				{
                    new PlayerEnemyCollisionHandler(player, enemy).HandleCollision();
                    // TODO: no cool down rn
                }

                if (player.SwordHitBox.Intersects(enemy.AttackHitBox))
				{
                    Console.WriteLine("Enemy and Player Sword");
                    // TODO
                }
            }
		}

		public void DetectEnemyProjectileCollisions()
		{
			foreach (IProjectile enemyProjectile in enemyProjectiles)
			{
                foreach (Rectangle borderHitBox in enemyBorder.HitBoxes)
                {
                    Rectangle overlap = Rectangle.Intersect(enemyProjectile.HitBox, borderHitBox);
                    if (!overlap.IsEmpty)
                    {
                        Console.WriteLine("Enemy Projectile and Wall");
                        // TODO
                    }
                }

                if (player.MainHitbox.Intersects(enemyProjectile.HitBox))
                {
                    Console.WriteLine("Enemy Projectile and Player");
                }
            }
        }

		public void DetectPlayerProjectileCollisions()
		{
            foreach (IProjectile playerProjectile in enemyProjectiles)
            {
                foreach (Rectangle borderHitBox in playerBorders.HitBoxes)
                {
                    Rectangle overlap = Rectangle.Intersect(playerProjectile.HitBox, borderHitBox);
                    if (!overlap.IsEmpty)
                    {
                        Console.WriteLine("Player Projectile and Wall");
                    }
                }
            }
        }

        public void DetectBlockCollisions()
        {
			foreach (IBlock block in blocks)
			{
				Rectangle overlap = Rectangle.Intersect(block.HitBox, player.BottomHalfHitBox);
				if (!overlap.IsEmpty)
				{
                    new PlayerBlockCollisionHandler(player, block).HandleCollision();
                }
			}
        }

		public void DetectBorderCollisions()
		{
            foreach (Rectangle borderHitBox in playerBorders.HitBoxes)
            {
                Rectangle overlap = Rectangle.Intersect(player.MainHitbox, borderHitBox);
                if (!overlap.IsEmpty)
                {
                    new PlayerBorderCollisionHandler(player, borderHitBox).HandleCollision();
                }
            }
        }

        public void DetectItemCollisions()
        {
            foreach (IItem item in items)
            {
                Rectangle overlap = Rectangle.Intersect(item.HitBox, player.MainHitbox);
                if (!overlap.IsEmpty)
                {
                    
                }
            }
        }
    }
}

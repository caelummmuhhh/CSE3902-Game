using System.Collections.Generic;
using Microsoft.Xna.Framework;

using MainGame.BlocksAndItems;
using MainGame.Players;
using MainGame.Enemies;
using MainGame.Projectiles;
using MainGame.Rooms;
using MainGame.RoomsAndDoors;
using MainGame;
using MainGame.Collision;
using System;
using MainGame.Collision.CollisionHandlers;

namespace MainGame.Collision
{
	public class CollisionDetector
	{
		private HashSet<Block> blocks;
		private HashSet<Item> items;
		private HashSet<IEnemy> enemies;
		private HashSet<IProjectile> playerProjectiles = new();
		private HashSet<IProjectile> enemyProjectiles = new();

        private readonly Game1 game;
		private HashSet<IHitBox> borders = new();
		private Player player;

		public CollisionDetector(Game1 game)
		{
            this.game = game;
            player = (Player)game.Player;
            blocks = new HashSet<Block>(game.Room.Blocks);
            items = new HashSet<Item>(game.Room.Items);
            enemies = new HashSet<IEnemy>(game.Room.Enemies);
            playerProjectiles = new HashSet<IProjectile>(player.ProjectilesManager.ActiveProjectiles);

            // TODO: Match border hitboxes to actual walls, this is here as a placeholder for now
            borders.Add(new TopFullHorizontalWallHitBox());
			borders.Add(new BottomFullHorizontalWallHitBox());
			borders.Add(new LeftFullVerticalWallHitBox());
			borders.Add(new RightFullVerticalWallHitBox());
        }

        public void Update()
        {
            blocks = new HashSet<Block>(game.Room.Blocks);
            items = new HashSet<Item>(game.Room.Items);
            enemies = new HashSet<IEnemy>(game.Room.Enemies);
            playerProjectiles = new HashSet<IProjectile>(player.ProjectilesManager.ActiveProjectiles);
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
				foreach (Block block in blocks)
				{
					Rectangle overlap = Rectangle.Intersect(enemy.HitBox, block.HitBox);
					if (!overlap.IsEmpty)
					{
                        new EnemyBlockCollisionHandler(enemy, block, overlap).HandleCollision();
                        Console.WriteLine("Enemy and Block");
					}
				}

				foreach (IProjectile playerProjectile in playerProjectiles)
				{
					Rectangle overlap = Rectangle.Intersect(enemy.HitBox, playerProjectile.HitBox);
                    if (!overlap.IsEmpty)
                    {
                        Console.WriteLine("Enemy and Player Projectile");
                    }
                }

                foreach (IHitBox border in borders)
				{
					foreach (Rectangle borderHitBox in border.HitBoxes)
					{
                        Rectangle overlap = Rectangle.Intersect(enemy.HitBox, borderHitBox);
                        if (!overlap.IsEmpty)
                        {
                            new EnemyBorderCollisionHandler(enemy, border, overlap).HandleCollision();
                        }
                    }
                }

				if (player.MainHitbox.Intersects(enemy.HitBox))
				{
                    Console.WriteLine("Enemy and Player");
                }

				if (player.SwordHitBox.Intersects(enemy.HitBox))
				{
                    Console.WriteLine("Enemy and Player Sword");
                }
            }
		}

		public void DetectEnemyProjectileCollisions()
		{
			foreach (IProjectile enemyProjectile in enemyProjectiles)
			{
                foreach (IHitBox border in borders)
                {
                    foreach (Rectangle borderHitBox in border.HitBoxes)
                    {
                        Rectangle overlap = Rectangle.Intersect(enemyProjectile.HitBox, borderHitBox);
                        if (!overlap.IsEmpty)
                        {
                            Console.WriteLine("Enemy Projectile and Wall");
                        }
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
                foreach (IHitBox border in borders)
                {
                    foreach (Rectangle borderHitBox in border.HitBoxes)
                    {
                        Rectangle overlap = Rectangle.Intersect(playerProjectile.HitBox, borderHitBox);
                        if (!overlap.IsEmpty)
                        {
                            Console.WriteLine("Player Projectile and Wall");
                        }
                    }
                }
            }
        }

        public void DetectBlockCollisions()
        {
			foreach (Block block in blocks)
			{
				Rectangle overlap = Rectangle.Intersect(block.HitBox, player.BottomHalfHitBox);
				if (!overlap.IsEmpty)
				{
                    new PlayerBlockCollisionHandler(player, block, overlap).HandleCollision();
                }
			}
        }

		public void DetectBorderCollisions()
		{
            foreach (IHitBox border in borders)
            {
                foreach (Rectangle borderHitBox in border.HitBoxes)
                {
                    Rectangle overlap = Rectangle.Intersect(player.MainHitbox, borderHitBox);
                    if (!overlap.IsEmpty)
                    {
                        Console.WriteLine("Wall and Player");
                    }
                }
            }
        }

        public void DetectItemCollisions()
        {
            foreach (Item item in items)
            {
                Rectangle overlap = Rectangle.Intersect(item.HitBox, player.MainHitbox);
                if (!overlap.IsEmpty)
                {
                    
                }
            }
        }
    }
}

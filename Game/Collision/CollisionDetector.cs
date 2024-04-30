using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

using MainGame.Blocks;
using MainGame.WorldItems;
using MainGame.Players;
using MainGame.Enemies;
using MainGame.Projectiles;
using MainGame.Rooms;
using MainGame.Collision.CollisionHandlers;
using System.Reflection;
using MainGame.Doors;
using System;
using System.Diagnostics;

namespace MainGame.Collision
{
	public class CollisionDetector
	{
		private List<IBlock> blocks;
		private List<IPickupableItem> items;
		private List<IEnemy> enemies;
		private List<IProjectile> playerProjectiles = new();
		private List<IProjectile> enemyProjectiles = new();
        private List<IDoor> doors = new();
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
            items = new List<IPickupableItem>(currentRoom.RoomItems);
            enemies = new List<IEnemy>(currentRoom.RoomEnemies);
            playerProjectiles = currentRoom.PlayerProjectiles;


            playerBorders = currentRoom.PlayerBorderHitBox;
            enemyBorder = currentRoom.EnemiesBorderHitBox;
            //enemyProjectiles = currentRoom.EnemyProjectiles;
            GetAllEnemyProjectiles();
        }

        public void Update()
        {
            IRoom currentRoom = game.RoomManager.CurrentRoom;
            blocks = new List<IBlock>(currentRoom.RoomBlocks);
            items = new List<IPickupableItem>(currentRoom.RoomItems);
            enemies = new List<IEnemy>(currentRoom.RoomEnemies);
            playerProjectiles = currentRoom.PlayerProjectiles;
            playerBorders = currentRoom.PlayerBorderHitBox;
            enemyBorder = currentRoom.EnemiesBorderHitBox;
            //enemyProjectiles = currentRoom.EnemyProjectiles;
            doors.Clear();
            doors.Add(currentRoom.NorthDoor);
            doors.Add(currentRoom.SouthDoor);
            doors.Add(currentRoom.EastDoor);
            doors.Add(currentRoom.WestDoor);
            GetAllEnemyProjectiles();

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
            DetectDoorCollisions();
        }

        public void DetectDoorCollisions()
        {
            foreach(IDoor door in doors)
            {
                Rectangle overlap = Rectangle.Intersect(player.MainHitbox, door.HitBox);
                if (!overlap.IsEmpty)
                {
                    new PlayerDoorCollisionHandler(player, door, game).HandleCollision();
                }
            }
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
                        new EnemyPlayerProjectileCollisionHandler(enemy, playerProjectile).HandleCollision();
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
                }

                if (player.SwordHitBox.Intersects(enemy.AttackHitBox))
				{
                    new EnemyPlayerSwordCollisionHandler(enemy, player).HandleCollision();
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
                        new ProjectileBorderCollisionHandler(enemyProjectile, borderHitBox).HandleCollision();
                    }
                }

                if (player.MainHitbox.Intersects(enemyProjectile.HitBox))
                {
                    new PlayerEnemyProjectileCollisionHandler(player, enemyProjectile).HandleCollision();
                }
            }
        }

		public void DetectPlayerProjectileCollisions()
		{
            foreach (IProjectile playerProjectile in playerProjectiles)
            {
                foreach (Rectangle borderHitBox in enemyBorder.HitBoxes)
                {
                    Rectangle overlap = Rectangle.Intersect(playerProjectile.HitBox, borderHitBox);
                    if (!overlap.IsEmpty)
                    {
                        new ProjectileBorderCollisionHandler(playerProjectile, borderHitBox).HandleCollision();
                    }
                }

                foreach (IDoor door in doors) {
                    Rectangle overlap = Rectangle.Intersect(door.HitBox, playerProjectile.HitBox);
                    if (!overlap.IsEmpty)
                    {
                        new DoorPlayerProjectileCollisionHandler(playerProjectile, door, game).HandleCollision();
                    }
                }

                if (player.MainHitbox.Intersects(playerProjectile.HitBox))
                {
                    new PlayerPlayerProjectileCollisionHandler(player, playerProjectile).HandleCollision();
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
            foreach (IPickupableItem item in items)
            {
                Rectangle overlap = Rectangle.Intersect(item.HitBox, player.MainHitbox);
                if (!overlap.IsEmpty)
                {
                    new PlayerItemCollisionHandler(player, item).HandleCollision();
                }
                if (item.Id == (int)ItemTypes.Fairy)
                {
                    foreach (Rectangle borderHitBox in enemyBorder.HitBoxes)
                    {
                        Rectangle itemBorderOverlap = Rectangle.Intersect(item.HitBox, borderHitBox);
                        if (!itemBorderOverlap.IsEmpty)
                        {
                            new MovingItemBorderCollisionHandler(item, borderHitBox).HandleCollision();
                        }
                    }
                }
            }
        }

        private void GetAllEnemyProjectiles()
        {
            enemyProjectiles.Clear();
            foreach (IEnemy enemy in enemies)
            {
                if (enemy is GoriyaEnemy goriya && goriya.State is GoriyaAttackingState goriyaAttackingState)
                {
                    enemyProjectiles.Add(goriyaAttackingState.Boomerang);
                }
                else if (enemy is AquamentusEnemy aquamentus)
                {
                    foreach (AquamentusAttackProjectiles projectile in aquamentus.ProjectilesManager.ActiveProjectiles)
                    {
                        enemyProjectiles.Add(projectile.UpProjectile);
                        enemyProjectiles.Add(projectile.StraightProjectile);
                        enemyProjectiles.Add(projectile.DownProjectile);
                    }
                }
            }
        }
    }
}

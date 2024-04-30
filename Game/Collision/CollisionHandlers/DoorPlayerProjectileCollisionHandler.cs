using Microsoft.Xna.Framework;
using MainGame.Doors;
using MainGame.Players;
using MainGame.Projectiles;

namespace MainGame.Collision.CollisionHandlers
{
	public class DoorPlayerProjectileCollisionHandler : ICollisionHandler
    {
        private readonly IDoor door;
        private readonly IProjectile projectile;
        private readonly PlayGameState game;

        public DoorPlayerProjectileCollisionHandler(IProjectile projectile, IDoor door, PlayGameState game)
        {
            this.door = door;
            this.game = game;
            this.projectile = projectile;
        }

        public void HandleCollision()
        {
            if (projectile is not BombProjectile || !door.IsLocked) return;

            Direction dir = door.Direction;
            door.Unlock();

            // Unlock door on other side
            Vector2 nextRoom = new(game.RoomManager.currentRoomIndex.X, game.RoomManager.currentRoomIndex.Y);
            if (dir == Direction.North)
            {
                nextRoom.Y = nextRoom.Y - 1 < 0 ? 0 : nextRoom.Y - 1;
                game.RoomManager.AllRooms[game.Dungeon.DungeonLayout[(int)nextRoom.Y][(int)nextRoom.X]].SouthDoor.Unlock();
            }
            else if (dir == Direction.South)
            {
                nextRoom.Y = nextRoom.Y + 1 >= game.Dungeon.DungeonSize - 1 ? game.Dungeon.DungeonSize - 1 : nextRoom.Y + 1;
                game.RoomManager.AllRooms[game.Dungeon.DungeonLayout[(int)nextRoom.Y][(int)nextRoom.X]].NorthDoor.Unlock();
            }
            else if (dir == Direction.West)
            {
                nextRoom.X = nextRoom.X - 1 < 0 ? 0 : nextRoom.X - 1;
                game.RoomManager.AllRooms[game.Dungeon.DungeonLayout[(int)nextRoom.Y][(int)nextRoom.X]].EastDoor.Unlock();
            }
            else if (dir == Direction.East)
            {
                nextRoom.X = nextRoom.X + 1 >= game.Dungeon.DungeonSize - 1 ? game.Dungeon.DungeonSize - 1 : nextRoom.X + 1;
                game.RoomManager.AllRooms[game.Dungeon.DungeonLayout[(int)nextRoom.Y][(int)nextRoom.X]].WestDoor.Unlock();
            }
        }
    }
}

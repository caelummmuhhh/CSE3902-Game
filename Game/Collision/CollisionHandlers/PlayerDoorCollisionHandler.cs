using MainGame.Doors;
using MainGame.Players;
using System.Numerics;

namespace MainGame.Collision.CollisionHandlers
{
    public class PlayerDoorCollisionHandler : ICollisionHandler
    {
        private readonly IDoor door;
        private readonly Game1 game;
        private readonly IPlayer player;

        public PlayerDoorCollisionHandler(IPlayer player, IDoor door, Game1 game) 
        {
            this.door = door;
            this.game = game;
            this.player = player;
        }

        public void HandleCollision()
        {
            Direction dir = door.Direction;

            if (!door.IsLocked)
            {
                game.RoomManager.NextRoom(dir);
                return;
            }

            if (player.Inventory.Keys.Quantity > 0 && door.DoorType is DoorTypes.KeyDoor)
            {
                player.Inventory.Keys.Use();
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
                return;
            }

            player.Position = CollisionUtils.DecoupleRectangle(player.MainHitbox, door.HitBox);
        }
    }
}

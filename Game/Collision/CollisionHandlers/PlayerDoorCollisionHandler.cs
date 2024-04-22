using MainGame.Doors;
using MainGame.Players;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGame.Collision.CollisionHandlers
{
    public class PlayerDoorCollisionHandler : ICollisionHandler
    {
        IDoor door;
        Game1 game;
        public PlayerDoorCollisionHandler(IPlayer player, IDoor door, Game1 game) 
        {
            this.door = door;
            this.game = game;
        }

        public void HandleCollision()
        {
            Direction dir;
            // Determine direction
            if(door.HitBox.Location.X - door.Position.X == 0 && door.HitBox.Location.Y - door.Position.Y != 0)
            {
                dir = Direction.South;
            }else if(door.HitBox.Location.X - door.Position.X == 0 && door.HitBox.Location.Y - door.Position.Y == 0)
            {
                dir = Direction.North;
            }else if(door.HitBox.Location.X - door.Position.X != 0 && door.HitBox.Location.Y - door.Position.Y != 0)
            {
                dir = Direction.East;
            }
            else
            {
                dir = Direction.West;
            }
            game.RoomManager.NextRoom(dir);
            if (door.IsOpen)
            {
                
            }
        }
    }
}

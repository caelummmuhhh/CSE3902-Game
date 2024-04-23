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
        IPlayer player;

        public PlayerDoorCollisionHandler(IPlayer player, IDoor door, Game1 game) 
        {
            this.door = door;
            this.game = game;
            this.player = player;
        }

        public void HandleCollision()
        {
            Direction dir = door.Direction;

            if (door.DoorType is SpriteHandlers.DoorTypes.OpenDoor)
            {
                game.RoomManager.NextRoom(dir);
            }
            else
            {
                if (player.Inventory.Keys.Quantity > 0 && door.DoorType is SpriteHandlers.DoorTypes.KeyDoor)
                {
                    player.Inventory.Keys.Use();
                    door.Unlock();

                    // Unlock door on other side


                }
            }
        }
    }
}

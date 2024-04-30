using Microsoft.Xna.Framework;

namespace MainGame.Doors
{
    public class BlankDoor : IDoor
    {
        public Direction Direction { get; set; }
        public Rectangle HitBox { get; set; }
        public bool IsLocked => true;
        public DoorTypes DoorType { get; set; }
        public Vector2 Position { get; set; }

        // Nothing to do for a blank door

        public void Draw() { }

        public void Unlock() { }

        public void Update() { }
    }
}
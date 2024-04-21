using Microsoft.Xna.Framework;
using MainGame.Enemies;

namespace MainGame.WorldItems
{
    public class EnemyBoundItemDecorator : IPickupableItem
    {
        public Vector2 Position { get => item.Position; set => item.Position = value; }
        public Rectangle HitBox => item.HitBox;
        public string Name => item.Name;
        public int Id => item.Id;

        private readonly IPickupableItem item;
        private readonly IEnemy entity;

        public EnemyBoundItemDecorator(IEnemy enemy, IPickupableItem item)
        {
            this.item = item;
            entity = enemy;
        }

        public void Update()
        {
            if (entity is not null)
            {
                item.Position = entity.Position;
            }
            item.Update();
        }

        public void Draw()
        {
            item.Draw();
        }

        public void PickUp()
        {
            item.PickUp();
        }
    }
}

using Microsoft.Xna.Framework;
using MainGame.Enemies;
using MainGame.Players;

namespace MainGame.Items
{
    public class EnemyBindedItemDecorator : IItem
    {
        public Vector2 Position { get => item.Position; set => item.Position = value; }
        public bool PickedUp { get; set; } = false;
        public bool Active { get; set; }
        public Rectangle HitBox { get => item.HitBox; }

        private readonly IItem item;
        private readonly IEnemy entity;

        public EnemyBindedItemDecorator(IEnemy enemy, IItem item)
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

        public void Collide()
        {
            item.Collide();
        }

        public void ActivateAbility(IPlayer player)
        {
            
        }
    }
}

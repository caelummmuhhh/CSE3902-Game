using Microsoft.Xna.Framework;
using System.Collections.Generic;

using MainGame.Doors;
using MainGame.SpriteHandlers;
using MainGame.Blocks;
using MainGame.WorldItems;
using MainGame.Enemies;
using MainGame.Players;
using MainGame.Particles;
using MainGame.Collision;
using MainGame.Projectiles;
using System.Linq;

namespace MainGame.Rooms
{
    public class GhostRoom : IRoom
    {
        public int RoomId { get; set; }
        public IPlayer RoomPlayer { get; set; }

        public List<IEnemy> RoomEnemies { get; set; } = new();
        public List<IBlock> RoomBlocks { get; set; } = new();
        public List<IPickupableItem> RoomItems { get; set; } = new();
        public List<IPickupableItem> WaitingRoomItems { get; set; } = new();
        public List<IParticle> RoomParticles { get; set; } = new();
        public List<IProjectile> PlayerProjectiles { get; private set; } = new();
        public List<IProjectile> EnemyProjectiles { get; private set; } = new();

        public ISprite RoomText { get; set; }

        public IHitBox EnemiesBorderHitBox { get; set; }
        public IHitBox PlayerBorderHitBox { get; set; }

        public IDoor NorthDoor { get; set; }
        public IDoor WestDoor { get; set; }
        public IDoor EastDoor { get; set; }
        public IDoor SouthDoor { get; set; }

        public Vector2 NorthDoorBaseLocation { get; set; }
        public Vector2 WestDoorBaseLocation { get; set; }
        public Vector2 EastDoorBaseLocation { get; set; }
        public Vector2 SouthDoorBaseLocation { get; set; }

        public List<Vector2> BlockBaseLocations { get; set; } = new();

        public ISprite OuterBorderSprite { get; set; }
        public ISprite InnerBorderSprite { get; set; }
        public ISprite TilesSprite { get; set; }

        public Vector2 Position { get; set; }

        private readonly IRoom baseRoom;
        private bool playedSpawnParticles = false;

        public GhostRoom(IRoom baseRoom)
        {
            this.baseRoom = baseRoom;
            Position = new Vector2(0, Constants.HudAndMenuHeight);
            OuterBorderSprite = baseRoom.OuterBorderSprite;
            InnerBorderSprite = baseRoom.InnerBorderSprite;
            TilesSprite = baseRoom.TilesSprite;

            NorthDoor = DoorUtils.CloneDoor(baseRoom.NorthDoor);
            SouthDoor = DoorUtils.CloneDoor(baseRoom.SouthDoor);
		    EastDoor = DoorUtils.CloneDoor(baseRoom.EastDoor);
		    WestDoor = DoorUtils.CloneDoor(baseRoom.WestDoor);
            RoomBlocks = baseRoom.RoomBlocks;
            BlockBaseLocations = baseRoom.RoomBlocks.Select(block => block.Position).ToList();

            NorthDoorBaseLocation = baseRoom.NorthDoor.Position;
            SouthDoorBaseLocation = baseRoom.SouthDoor.Position;
            EastDoorBaseLocation = baseRoom.EastDoor.Position;
            WestDoorBaseLocation = baseRoom.WestDoor.Position;

            EnemiesBorderHitBox = new AllFullWallHitBox();
            PlayerBorderHitBox = new GenericHitBox();

        }

        public void Update()
        {
            NorthDoor.Position = NorthDoorBaseLocation + Position - new Vector2(0, Constants.HudAndMenuHeight);
            SouthDoor.Position = SouthDoorBaseLocation + Position - new Vector2(0, Constants.HudAndMenuHeight);
            EastDoor.Position = EastDoorBaseLocation + Position - new Vector2(0, Constants.HudAndMenuHeight);
            WestDoor.Position = WestDoorBaseLocation + Position - new Vector2(0, Constants.HudAndMenuHeight);
            NorthDoor.Update();
            SouthDoor.Update();
            WestDoor.Update();
            EastDoor.Update();

            for (int i = 0; i < RoomBlocks.Count; i++)
            {
                RoomBlocks[i].Position = BlockBaseLocations[i] + Position - new Vector2(0, Constants.HudAndMenuHeight);
                RoomBlocks[i].Update();
            }

            for (int i = RoomParticles.Count - 1; i >= 0; i--)
            {
                RoomParticles[i].Update();
                if (!RoomParticles[i].IsActive)
                {
                    RoomParticles.RemoveAt(i);
                }
            }
        }

        public void Draw()
        {
            OuterBorderSprite.Draw(Position.X, Position.Y, Color.White);
            InnerBorderSprite.Draw(Position.X, Position.Y, Color.White);
            TilesSprite.Draw(Position.X, Position.Y, Color.White);

            NorthDoor.Draw();
            SouthDoor.Draw();
            WestDoor.Draw();
            EastDoor.Draw();

            RoomText?.Draw(32 * Constants.UniversalScale, 32 * Constants.UniversalScale + Constants.HudAndMenuHeight, Color.White);

            foreach (IParticle particle in RoomParticles) particle.Draw();
            foreach (IBlock block in RoomBlocks) block.Draw();
        }

        public void ResetToBasePositions()
        {

            for (int i = 0; i < RoomBlocks.Count; i++)
            {
                // since this wasn't deep-copied, whatever changes made in this ghost room needs to be reversed
                RoomBlocks[i].Position = BlockBaseLocations[i];
            }
        }

        public void PlaySpawnParticles()
        {
            if (playedSpawnParticles) return;
            playedSpawnParticles = true;
            foreach (IEnemy enemy in baseRoom.RoomEnemies)
            {
                RoomParticles.Add(ParticleFactory.GetSpawnParticle(enemy.Position));
            }
        }
    }
}
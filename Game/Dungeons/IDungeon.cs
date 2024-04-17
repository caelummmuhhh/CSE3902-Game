using Microsoft.Xna.Framework;
using System.Collections.Generic;

using MainGame.Doors;
using MainGame.SpriteHandlers;
using MainGame.Blocks;
using MainGame.Items;
using MainGame.Enemies;
using MainGame.Players;
using MainGame.Particles;
using MainGame.Collision;

namespace MainGame.Dungeons
{
	public interface IDungeon
	{
		public string DungeonId { get; set; }
		public string UseItemKey { get; set; }
		public string AttackKey { get; set; }
		public int PlayerStartingHealth { get; set; }
		public int PlayerStartingRupees { get; set; }
		public int PlayerStartingKeys { get; set; }
        public int PlayerStartingBombs { get; set; }
		public string[] PlayerStartingItems { get; set; }

        public int[][] DungeonLayout { get; set; }
        public int UnderGroundRoom { get; set; }
		public int DungeonRoomCount { get; set; }

        public void Update();
        public void Draw();
    }
}


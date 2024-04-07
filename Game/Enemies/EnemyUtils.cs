using System;
using System.Linq;
using MainGame.Players;
using Microsoft.Xna.Framework;

namespace MainGame.Enemies
{
    public enum EnemyTypes
    {
        Aquamentus,
        Gel,
        Goriya,
        Keese,
        OldMan,
        SpikeCross,
        Stalfos,
        WallMaster
    }

    public static class EnemyUtils
	{
        public static IEnemy CreateEnemy(EnemyTypes enemy, Vector2 position, IPlayer player)
        {
            return enemy switch
            {
                EnemyTypes.Aquamentus => new AquamentusEnemy(position, player),
                EnemyTypes.Gel => new GelEnemy(position),
                EnemyTypes.Goriya => new GoriyaEnemy(position),
                EnemyTypes.Keese => new KeeseEnemy(position),
                EnemyTypes.OldMan => new OldManEnemy(position),
                EnemyTypes.SpikeCross => new SpikeCrossEnemy(position, player),
                EnemyTypes.Stalfos => new StalfosEnemy(position),
                EnemyTypes.WallMaster => new WallMasterEnemy(position, player),
                _ => null,
            };
        }

        /// <summary>
        /// Tries to create an enemy based on given name.
        /// </summary>
        /// <param name="enemyName">The name of the enemy.</param>
        /// <returns>The ISprite object created based on the given enemy name</returns>
        /// <exception cref="ArgumentException">The enemy name does not match to a enemy.</exception>
        public static IEnemy CreateEnemy(string enemyName, Vector2 position, IPlayer player)
        {
            bool conversionSuccess = Enum.TryParse(enemyName, true, out EnemyTypes enemy);

            if (!conversionSuccess)
            {
                throw new ArgumentException("Unable to parse enemy name string into an enemy.");
            }

            return CreateEnemy(enemy, position, player);
        }

    }
}


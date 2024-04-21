using System;
using MainGame.WorldItems;
using MainGame.Audio;
using MainGame.Players;
using Microsoft.Xna.Framework;

namespace MainGame.Enemies
{
    public enum EnemyTypes
    {
        Aquamentus, Gel, Goriya, Keese, OldMan, SpikeCross, Stalfos, WallMaster
    }

    public enum ItemBindedEnemyTypes
    {
        KeyStalfos
    }

    public static class EnemyUtils
	{
        public static IEnemy CreateEnemy(EnemyTypes enemy, Vector2 position, IPlayer player, AudioManager audioManager)
        {
            return enemy switch
            {
                EnemyTypes.Aquamentus => new AquamentusEnemy(position, audioManager, player),
                EnemyTypes.Gel => new GelEnemy(position, audioManager),
                EnemyTypes.Goriya => new GoriyaEnemy(position, audioManager),
                EnemyTypes.Keese => new KeeseEnemy(position, audioManager),
                EnemyTypes.OldMan => new OldManEnemy(position, audioManager),
                EnemyTypes.SpikeCross => new SpikeCrossEnemy(position, audioManager, player),
                EnemyTypes.Stalfos => new StalfosEnemy(position, audioManager),
                EnemyTypes.WallMaster => new WallMasterEnemy(position, audioManager, player),
                _ => null,
            };
        }

        /// <summary>
        /// Tries to create an enemy based on given name.
        /// </summary>
        /// <param name="enemyName">The name of the enemy.</param>
        /// <returns>The ISprite object created based on the given enemy name</returns>
        /// <exception cref="ArgumentException">The enemy name does not match to a enemy.</exception>
        public static IEnemy CreateEnemy(string enemyName, Vector2 position, IPlayer player, AudioManager audioManager)
        {
            bool conversionSuccess = Enum.TryParse(enemyName, true, out EnemyTypes enemy);

            if (!conversionSuccess)
            {
                throw new ArgumentException("Unable to parse enemy name string into an enemy.");
            }

            return CreateEnemy(enemy, position, player, audioManager);
        }

        public static IEnemy CreateItemBindedEnemy(ItemBindedEnemyTypes itemEnemyType, Vector2 position, out IPickupableItem itemHolder, IPlayer player, AudioManager audioManager)
        {
            IEnemy enemy;
            switch (itemEnemyType)
            {
                case ItemBindedEnemyTypes.KeyStalfos:
                    enemy = CreateEnemy(EnemyTypes.Stalfos, position, player, audioManager);
                    itemHolder = new EnemyBoundItemDecorator(enemy, ItemFactory.CreateItem(ItemTypes.Key, position, player, audioManager));
                    break;
                default:
                    throw new ArgumentException("Unable to parse provided item enemy type.");
            }

            return enemy;
        }

        public static IEnemy CreateItemBindedEnemy(string enemyName, Vector2 position, out IPickupableItem itemHolder, IPlayer player, AudioManager audioManager)
        {
            bool conversionSuccess = Enum.TryParse(enemyName, true, out ItemBindedEnemyTypes enemy);

            if (!conversionSuccess)
            {
                throw new ArgumentException("Unable to parse enemy name string into an enemy.");
            }

            return CreateItemBindedEnemy(enemy, position, out itemHolder, player, audioManager);
        }
    }
}


using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MainGame.Audio
{
    public class AudioManager
    {
        private Game1 Game;
        private Song Song;
        public static readonly Dictionary<string, SoundEffect> SFXMap = new();
        public static readonly Dictionary<string, List<int>> ActiveSFXList = new();

        private int MuteDebounce = 0;
        public AudioManager(Game1 game)
        {
            Game = game;
            Song = game.Content.Load<Song>("Audio/Dungeon_BGM");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(Song);

            LoadAllSFX();
        }
        public void MuteSong()
        {
            if (MuteDebounce <= 0)
            {
                if (MediaPlayer.IsMuted)
                {
                    MediaPlayer.IsMuted = false;
                }
                else
                {
                    MediaPlayer.IsMuted = true;
                }
                MuteDebounce = 10;
            }
        }
        public void PlaySFX(string sfx, int delay)
        {
            if (!ActiveSFXList.ContainsKey(sfx))
            {
                ActiveSFXList[sfx] = new List<int>();
            }
            ActiveSFXList[sfx].Add(delay + Game.TotalGameTime);
        }
        private void LoadAllSFX()
        {
            SFXMap.Add("Arrow_And_Boomerang", Game.Content.Load<SoundEffect>("Audio/LOZ_Arrow_Boomerang"));
            SFXMap.Add("Bomb_Blow", Game.Content.Load<SoundEffect>("Audio/LOZ_Bomb_Blow"));
            SFXMap.Add("Bomb_Drop", Game.Content.Load<SoundEffect>("Audio/LOZ_Bomb_Drop"));
            SFXMap.Add("Boss_Roar", Game.Content.Load<SoundEffect>("Audio/LOZ_Boss_Scream1"));
            SFXMap.Add("Candle", Game.Content.Load<SoundEffect>("Audio/LOZ_Candle"));
            SFXMap.Add("Door_Unlock", Game.Content.Load<SoundEffect>("Audio/LOZ_Door_Unlock"));
            SFXMap.Add("Enemy_Die", Game.Content.Load<SoundEffect>("Audio/LOZ_Enemy_Die"));
            SFXMap.Add("Enemy_Hit", Game.Content.Load<SoundEffect>("Audio/LOZ_Enemy_Hit"));
            SFXMap.Add("Grab_Item_Long", Game.Content.Load<SoundEffect>("Audio/LOZ_Fanfare"));
            SFXMap.Add("Grab_Item_Short", Game.Content.Load<SoundEffect>("Audio/LOZ_Get_Heart"));
            SFXMap.Add("Grab_Item_Medium", Game.Content.Load<SoundEffect>("Audio/LOZ_Get_Item"));
            SFXMap.Add("Grab_Rupee_And_Menu", Game.Content.Load<SoundEffect>("Audio/LOZ_Get_Rupee"));
            SFXMap.Add("Item_Appear", Game.Content.Load<SoundEffect>("Audio/LOZ_Key_Appear"));
            SFXMap.Add("Player_Die", Game.Content.Load<SoundEffect>("Audio/LOZ_Link_Die"));
            SFXMap.Add("Player_Hurt", Game.Content.Load<SoundEffect>("Audio/LOZ_Link_Hurt"));
            SFXMap.Add("Player_Low_Health", Game.Content.Load<SoundEffect>("Audio/LOZ_LowHealth"));
            SFXMap.Add("Secret_Revealed", Game.Content.Load<SoundEffect>("Audio/LOZ_Secret"));
            SFXMap.Add("Projectile_Deflect", Game.Content.Load<SoundEffect>("Audio/LOZ_Shield"));
            SFXMap.Add("Stairs", Game.Content.Load<SoundEffect>("Audio/LOZ_Stairs"));
            SFXMap.Add("Sword_Beam", Game.Content.Load<SoundEffect>("Audio/LOZ_Sword_Shoot"));
            SFXMap.Add("Sword_Attack", Game.Content.Load<SoundEffect>("Audio/LOZ_Sword_Slash"));
        }
        public void Update()
        {
            if (MuteDebounce > 0)
            {
                --MuteDebounce;
            }

            foreach ((string sfx, List<int> delay) in ActiveSFXList)
            {
                List<int> delayCopy = new List<int>(delay);
                foreach (int d in delayCopy)
                {
                    if (d <= Game.TotalGameTime) {
                        SFXMap[sfx].Play();
                        ActiveSFXList[sfx].Remove(d);
                    }
                    if (delay.Count == 0)
                    {
                        ActiveSFXList.Remove(sfx);
                    }
                }
            }
        }
    }
}

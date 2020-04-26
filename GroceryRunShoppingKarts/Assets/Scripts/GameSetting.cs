using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.SceneManagement;

namespace Settingo
{

    public class GameSetting : MonoBehaviour
    {
        public static Setting setting;
        public static string trackname;
        void Awake()
        {
            string jsonfile = File.ReadAllText(Application.dataPath + "/config/settings.json");
            setting = JsonUtility.FromJson<Setting>(jsonfile);
            trackname = SceneManager.GetActiveScene().name;
        }
    }
    [System.Serializable]
    public class Setting
    {
        public float easy_speed;
        public float normal_speed;
        public float hard_speed;
        public int easy_level;
        public int normal_level;
        public int hard_level;
        public Difficulty difficulty = Difficulty.EASY;
        public int track1_scaling;
        public int track2_scaling;
        public int track3_scaling;
        public int track4_scaling;
        public int GetScaling()
        {
            if(GameSetting.trackname == "Track1")
            {
                return track1_scaling;
            }else if(GameSetting.trackname == "Track2")
            {
                return track2_scaling;
            }else if(GameSetting.trackname == "Track3")
            {
                return track3_scaling;
            }else if(GameSetting.trackname == "Track4")
            {
                return track4_scaling;
            }
            else
            {
                return 100;
            }
        }
        public float getSpeedDifficulty()
        {
            return getSpeed(this.difficulty);
        }
        public float getLevelDifficulty()
        {
            return getAILevel(this.difficulty);
        }
        public void SetDifficulty(string diff)
        {
            if(diff.ToLower() == "easy")
            {
                difficulty = Difficulty.EASY;
            }else if (diff.ToLower() == "normal")
            {
                difficulty = Difficulty.NORMAL;
            }else if (diff.ToLower() == "hard")
            {
                difficulty = Difficulty.HARD;
            }
        }
        public float getSpeed(Difficulty diff)
        {
            if (diff == Difficulty.EASY)
            {
                return easy_speed;
            }
            if (diff == Difficulty.NORMAL)
            {
                return normal_speed;
            }
            if (diff == Difficulty.HARD)
            {
                return hard_speed;
            }
            return 0;
        }
        public int getAILevel(Difficulty diff)
        {
            if (diff == Difficulty.EASY)
            {
                return easy_level;
            }
            if (diff == Difficulty.NORMAL)
            {
                return normal_level;
            }
            if (diff == Difficulty.HARD)
            {
                return hard_level;
            }
            return 0;
        }
    }
    public enum Difficulty
    {
        EASY,
        NORMAL,
        HARD
    }
}

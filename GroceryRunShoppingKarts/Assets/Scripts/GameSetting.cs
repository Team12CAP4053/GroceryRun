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
            DontDestroyOnLoad(transform.gameObject);
            setting = new Setting();
            trackname = SceneManager.GetActiveScene().name;
        }
    }
    public class Setting
    {
        public bool paused = false;
        public float easy_speed = 75;
        public float normal_speed = 95;
        public float hard_speed = 110;
        public int easy_level = 1;
        public int normal_level = 3;
        public int hard_level = 5;
        public Difficulty difficulty = Difficulty.EASY;
        public int track1_scaling = 10;
        public int track2_scaling = 50;
        public int track3_scaling = 100;
        public int track4_scaling = 50;
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

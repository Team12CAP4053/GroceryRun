using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityStandardAssets.Vehicles.Car;
namespace Settingo
{

    public class GameSetting : MonoBehaviour
    {
        public static Setting setting;
        void Awake()
        {
            string jsonfile = File.ReadAllText(Application.dataPath + "/config/settings.json");
            setting = JsonUtility.FromJson<Setting>(jsonfile);

            GameObject.FindWithTag("Player").GetComponent<CarController>().setTopSpeed(setting.getSpeedDifficulty());
            GameObject.FindWithTag("Leonardo").GetComponent<CarController>().setTopSpeed(setting.getSpeedDifficulty());
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
        public float getSpeedDifficulty()
        {
            return getSpeed(this.difficulty);
        }
        public float getLevelDifficulty()
        {
            return getAILevel(this.difficulty);
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

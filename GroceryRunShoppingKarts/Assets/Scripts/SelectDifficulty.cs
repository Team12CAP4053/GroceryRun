using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Settingo;
public class SelectDifficulty : MonoBehaviour
{
    private void Start()
    {
        
    }
    public void SetDifficulty(string diff)
    {
        GameSetting.setting.SetDifficulty(diff);
    }
}

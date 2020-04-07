using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.UI;
public class KartLap : MonoBehaviour
{
    public int lapIndex;
    public int checkpointIndex;
    public LapHandle lapHandle;
    public Text lapText;
    public LevelChanger level;
    public Text continueText;
    public Text finishText;
    // Start is called before the first frame update
    void Start()
    {
        lapIndex = 0;
        checkpointIndex = 0;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Checkpoint"))
        {
            if (obj.GetComponent<LapHandle>())
            {
                lapHandle = obj.GetComponent<LapHandle>();
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<CarUserControl>())
        {
                lapText.text = "Lap: " + (lapIndex + 1) + "/" + lapHandle.GetMaxLap();
                if (lapHandle.GetMaxLap() == lapIndex)
                {
                //Debug.Log("Donezasdasdo");
                    if (Input.anyKeyDown)
                    {
                        level.FadeToNextLevel();
                    }
                }
            
            
        }
    }
    public int positionScore()
    {

        return lapIndex * 10 + checkpointIndex;
    }
    public void incrementLap()
    {
        lapIndex++;
    }
}

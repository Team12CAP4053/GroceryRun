using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CheckpointHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public int cpIndex;
    public Text wrongwayText;

    void Start()
    {
        cpIndex = int.Parse(this.name);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<KartLap>())
        {

            KartLap kart = collider.gameObject.GetComponent<KartLap>();
            if (kart.checkpointIndex == cpIndex - 1)
            {
                kart.checkpointIndex = cpIndex;
            }
            else if (kart.checkpointIndex == cpIndex)
            {
                //Remove flashing red thing
                wrongwayText.gameObject.SetActive(false);
            }
            else if(kart.checkpointIndex < cpIndex)
            {
                Debug.Log("Please turn around");
                //Flash red thing on screen
                wrongwayText.gameObject.SetActive(true);
            }
        }
    }
}

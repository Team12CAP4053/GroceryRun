using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;
public class PlayerPosition : MonoBehaviour
{
    public int position;
    public Text place;
    private void Update()
    {
        if(place != null)
        {
            if (place.text != null && this.GetComponent<KartLap>().lapIndex > 2)
            {
                place.text = place.text;
            }
            else
            {
                switch (position)
                {
                    case 1:
                        place.text = position + "st Place";
                        break;
                    case 2:
                        place.text = position + "nd Place";
                        break;
                    case 3:
                        place.text = position + "rd Place";
                        break;
                    case 4:
                        place.text = position + "th Place";
                        break;
                }
            }
        }   
    }
}

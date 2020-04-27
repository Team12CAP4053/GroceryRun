using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine;

public class FoodBullet : MonoBehaviour
{
    public float speed = 100.0f;
    public float lifetime = 3.0f;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = lifetime;
    }

    void Update()
    {
        // Bullet moves forward!
        transform.position += transform.forward * speed * Time.deltaTime;

        // Destroy bullet after timer == 0
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject otherObj = collision.gameObject;
        Debug.Log("Collided with: " + otherObj);

        if (otherObj.GetComponent<CarController>())
        {
           
            if (this.name == "FMGP_PRE_Apple_256(Clone)")
            {
                if (otherObj.GetComponent<KartItem>().currentCost <= 10 && (otherObj.GetComponent<KartItem>().currentCost + 2) < 10)
                {
                    otherObj.GetComponent<KartItem>().currentCost += 2;
                    otherObj.GetComponent<CarController>().slowDownTopSpeed(10f);
                }
                else if ((otherObj.GetComponent<KartItem>().currentCost + 2) > 10)
                {
                    otherObj.GetComponent<KartItem>().currentCost = 10;
                }
            }
            else if (this.name == "SMGP_PRE_Chicken_512(Clone)")
            {
                if (otherObj.GetComponent<KartItem>().currentCost <= 10 && (otherObj.GetComponent<KartItem>().currentCost + 4) < 10)
                {
                    otherObj.GetComponent<KartItem>().currentCost += 4;
                    otherObj.GetComponent<CarController>().slowDownTopSpeed(20f);
                }
                else if ((otherObj.GetComponent<KartItem>().currentCost + 4) > 10)
                {
                    otherObj.GetComponent<KartItem>().currentCost = 10;
                }
            }
            else if (this.name == "Milk 1(Clone)")
            {
                if (otherObj.GetComponent<KartItem>().currentCost <= 10 && (otherObj.GetComponent<KartItem>().currentCost + 5) < 10)
                {
                    otherObj.GetComponent<KartItem>().currentCost += 5;
                    otherObj.GetComponent<CarController>().slowDownTopSpeed(25);
                }
                else if ((otherObj.GetComponent<KartItem>().currentCost + 5) > 10)
                {
                    otherObj.GetComponent<KartItem>().currentCost = 10;
                }
            }
            else if (this.name == "Watermelon(Clone)")
            {
                if (otherObj.GetComponent<KartItem>().currentCost <= 10 && (otherObj.GetComponent<KartItem>().currentCost + 6) < 10)
                {
                    otherObj.GetComponent<KartItem>().currentCost += 6;
                    otherObj.GetComponent<CarController>().slowDownTopSpeed(30f);
                }
                else if ((otherObj.GetComponent<KartItem>().currentCost + 6) > 10)
                {
                    otherObj.GetComponent<KartItem>().currentCost = 10;
                }
            }
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider collider)
    {
        GameObject otherObj = collider.gameObject;
        Debug.Log("Triggered with: " + otherObj);
    }
}
